using UnityEngine;
using System;
using System.Collections.Generic;

namespace pp {

	/// <summary>
	/// The game grid which players add and remove blocks from. This behavior must
	/// be attached to a plane.
	/// </summary>
	public class Grid : MonoBehaviour {
		private const int gridLayerMask = 1 << 8; // Grid is on layer 8
		private const int gridWidth = 30;
		private const int gridHeight = 16;
		private Block[,] blocks = new Block[gridWidth, gridHeight];
		public ItemType Recipe;
		public float Money = 1000;
		// Selection parameters
		private const int MODE_MODIFY = 1; // Add or remove a block
		private const int MODE_SELECT_TARGET = 2; // Select a block target

		private int mode = MODE_MODIFY;
		private Queue<Block> targets = new Queue<Block>(); // List of targets for RobotArm
		public ItemType recipe { set; get; } // Recipe for new combiners
		public Direction direction { set; get; }
		private BlockType mSpawnType;
		public BlockType spawnType { 
			set {
				mSpawnType = value;
				mode = MODE_MODIFY;
				useMark = false;
			}
			get {
				return mSpawnType;
			}
		}

		// Ghost parameters
		private Marker marker;
		private bool useMark;
		public Vector2i mark { set; get; }

		public Grid() {
			direction = Direction.EAST;
			spawnType = BlockType.CONVEYOR;
		}

		public void Awake() {
			// Add a single spawner
			Spawner spawner = new Spawner();
			spawner.nextItem = ItemType.IRON_SHEET;
			Set(4, 10, spawner);
			spawner.Start();

			marker = new Marker();
		}

		public void Update() {
			// Find the hovered grid tile
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			bool success = Physics.Raycast (ray, out hit, 1000.0f, gridLayerMask);
			
			if (success) {
				Vector2i hitGrid = WorldToGrid(hit.point);

				// Move mark
				if (useMark) {
					marker.worldPosition = GridToWorld(mark);
				} else {
					marker.worldPosition = Vector3.zero;
				}

				if (GUIUtility.hotControl == 0 && Input.GetMouseButtonDown (0)) {
					if (mode == MODE_MODIFY) {
						OnModify(hitGrid);
					} else {
						OnSelectTarget(hitGrid);
					}
				}
			}
		}

		public void Set(Vector2i pos, Block block) {
			Set(pos.x, pos.y, block);
		}

		public void Set(int x, int y, Block block) {
			block.worldPosition = GridToWorld(x, y);
			block.coords = new Vector2i(x, y);
			block.grid = this;
			blocks[x, y] = block;
			
			// Calculate direction
			block.direction = direction;
		}

		public bool Remove(int x, int y) {
			Block b = Get(x, y);
			if (b != null) {
				b.Destroy();
				blocks[x, y] = null;
				return true;
			}
			return false;
		}

		public bool Remove(Vector2i pos) {
			return Remove(pos.x, pos.y);
		}

		public Block Get(int x, int y) {
			if (x < 0 || x >= gridWidth)
				return null;
			if (y < 0 || y >= gridHeight)
				return null;
			
			return blocks[x, y];
		}

		public Block Get(Vector2i pos) {
			return Get(pos.x, pos.y);
		}

		public void OnModify(Vector2i pos) {
			Block existing = Get(pos.x, pos.y);
			if (existing == null && spawnType == BlockType.GRABBER) {
				mode = MODE_SELECT_TARGET;
				useMark = true;
				mark = pos;
				return;
			}

			if (existing != null) {
				// Rotate the block?
				if (existing.blockType == spawnType) {
					existing.Rotate(true);
					return;
				}

				Alerts.ShowMessage("Cannot place - something is blocking the way!");
				return;
			}

			Block created = CreateBasicBlock(spawnType);
			if (created != null)
				Set(pos.x, pos.y, created);
		}

		public void OnSelectTarget(Vector2i pos) {
			if (spawnType != BlockType.GRABBER)
				throw new ArgumentException();

			Block selected = Get(pos.x, pos.y);
			if (selected != null) {
				if (targets.Contains(selected)) {
					Alerts.ShowMessage("You cannot select the same block twice.");
				} else if (selected.blockType != BlockType.CONVEYOR) {
					Alerts.ShowMessage("You can only pick up objects from a conveyor belt.");
				} else {
					// Add a block target
					targets.Enqueue(selected);
					if (targets.Count == 2) {
						Set((int) mark.x, (int) mark.y, new RoboticArm(targets.Dequeue(), targets.Dequeue()));
						mode = MODE_MODIFY;
						useMark = false;
					}
				}
			} else {
				Alerts.ShowMessage("Select a conveyor to pick up from.");
			}
		}

		public Block CreateBasicBlock(BlockType type) {
			switch (type) {
				case BlockType.CONVEYOR:
					return new Conveyor();
				case BlockType.COMBINER:
					// return new Combiner(RecipeFactory.NewRecipe(recipe));
				default:
					return null;
			}
		}

		public Vector3 GetPlaneOrigin() {
			Vector3 corner = transform.position;
			corner.x -= GetPlaneWidth() / 2;
			corner.z -= GetPlaneHeight() / 2;
			return corner;
		}

		public float GetPlaneWidth() {
			return transform.collider.bounds.size.x;
		}

		public float GetPlaneHeight() {
			return transform.collider.bounds.size.z;
		}

		public float GetTileHeight() {
			return GetPlaneHeight() / gridHeight;
		}

		public float GetTileWidth() {
			return GetPlaneWidth() / gridWidth;
		}

		public Vector3 GridToWorld(Vector2i pos) {
			return GridToWorld(pos.x, pos.y);
		}

		public Vector3 GridToWorld(int x, int y) {
			Vector3 world = GetPlaneOrigin();
			world.x += ((float) x * GetTileWidth()) + (GetTileWidth() / 2.0f);
			world.y += 0.2f;
			world.z += ((float) y * GetTileHeight()) + (GetTileHeight() / 2.0f);
			return world;
		}

		public Vector2i WorldToGrid(Vector3 world) {
			Vector3 offset = world - GetPlaneOrigin (); // Offset from bottom left
			
			int x = (int)((offset.x / GetPlaneWidth ()) * gridWidth);
			int y = (int)((offset.z / GetPlaneHeight ()) * gridHeight);
			
			return new Vector2i(x, y);
		}
	}

}
