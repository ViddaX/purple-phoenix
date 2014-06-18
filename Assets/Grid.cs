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

		// Selection parameters
		private const int MODE_MODIFY = 1; // Add or remove a block
		private const int MODE_SELECT_TARGET = 2; // Select a block target
		private int mode = MODE_MODIFY;
		private Queue<Block> targets = new Queue<Block>(); // List of targets for RobotArm
		public Recipe currentRecipe { set; get; } // Recipe for new combiners
		public Vector2 mark { set; get; }
		public Direction direction { set; get; }
		private BlockType mSpawnType;
		public BlockType spawnType { 
			set {
				mSpawnType = value;
				mode = MODE_MODIFY;
			}
			get {
				return mSpawnType;
			}
		}

		public Grid() {
			// FIXME Testing code
			currentRecipe = new Recipe(ItemType.IRON_SHEET, new RecipePiece(ItemType.IRON_SHEET, 3));
			direction = Direction.EAST;
		}

		public void Awake() {
			// Add a single spawner
			Spawner spawner = new Spawner();
			spawner.nextItem = ItemType.IRON_SHEET;
			Set(4, 4, spawner);

			spawner.Start();
		}

		public void Update() {
			if (GUIUtility.hotControl == 0) {
								if (!Input.GetMouseButtonDown (0)) 
										return;

								// Find the selected grid tile
								Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
								RaycastHit hit;
								bool success = Physics.Raycast (ray, out hit, 1000.0f, gridLayerMask);

								if (!success) 
										return;

								Vector3 offset = hit.point - GetPlaneOrigin (); // Offset from bottom left

								int x = (int)((offset.x / GetPlaneWidth ()) * gridWidth);
								int y = (int)((offset.z / GetPlaneHeight ()) * gridHeight);

								if (mode == MODE_MODIFY) {
										OnModify (x, y);
								} else {
										OnSelectTarget (x, y);
								}
						}
		}

		public void Set(int x, int y, Block block) {
			Block existing = Get(x, y);
			if (existing != null)
				existing.Destroy();

			block.worldPosition = GridToWorld(x, y);
			block.coords = new Vector2(x, y);
			block.grid = this;
			blocks[x, y] = block;

			// Calculate direction
			block.direction = direction;
		}

		public void Remove(int x, int y) {
			Block b = Get(x, y);
			if (b != null) {
				b.Destroy();
				blocks[x, y] = null;
			}
		}

		public Block Get(int x, int y) {
			if (x < 0 || x >= gridWidth)
				return null;
			if (y < 0 || y >= gridHeight)
				return null;

			return blocks[x, y];
		}

		public Block Get(Vector2 v) {
			return Get((int) v.x, (int) v.y);
		}

		public void OnModify(int x, int y) {
			if (spawnType == BlockType.GRABBER) {
				mode = MODE_SELECT_TARGET;
				mark = new Vector2(x, y);
				return;
			}

			Block created = CreateBasicBlock(spawnType);
			if (created != null)
				Set(x, y, created);
		}

		public void OnSelectTarget(int x, int y) {
			if (spawnType != BlockType.GRABBER)
				throw new ArgumentException();

			Block selected = Get(x, y);
			if (selected != null) {
				targets.Enqueue(selected);
				if (targets.Count == 2)
					Set((int) mark.x, (int) mark.y, new RoboticArm(targets.Dequeue(), targets.Dequeue()));
			} else {
				mode = MODE_MODIFY;
				targets.Clear();
				// TODO 'No block selected' Error message
			}
		}

		public Block CreateBasicBlock(BlockType type) {
			switch (type) {
				case BlockType.CONVEYOR:
					return new Conveyor();
				case BlockType.COMBINER:
					return new Combiner(currentRecipe);
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

		public Vector3 GridToWorld(int x, int y) {
			Vector3 world = GetPlaneOrigin();
			world.x += (x * GetTileWidth()) + (GetTileWidth() / 2);
			world.y += 0.2f;
			world.z += (y * GetTileHeight()) + (GetTileHeight() / 2);
			return world;
		}
	}

}
