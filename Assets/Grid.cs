﻿using UnityEngine;
using System;

namespace pp {

	/// <summary>
	/// The game grid which players add and remove blocks from. This behavior must
	/// be attached to a plane.
	/// </summary>
	public class Grid : MonoBehaviour {
		private const int gridLayerMask = 1 << 8; // Grid is on layer 8
		private const int gridWidth = 30;
		private const int gridHeight = 16;
		private const float tileOffsetY = 0.2f;
		private Block[,] blocks = new Block[gridWidth, gridHeight];
		private Block lastPlaced;
		public BlockType selected;

		public void Awake() {
			// Add a single spawner
			Spawner spawner = new Spawner();
			spawner.nextItem = ItemType.IRON_SHEET;
			Set(4, 4, spawner);

			spawner.Start();
		}

		public void Update() {
			if (!Input.GetMouseButton(0)) 
				return;

			// Find the selected grid tile
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			bool success = Physics.Raycast(ray, out hit, 1000.0f, gridLayerMask);

			if (!success) 
				return;

			Vector3 offset = hit.point - GetPlaneOrigin(); // Offset from bottom left

			int x = (int) ((offset.x / GetPlaneWidth()) * gridWidth);
			int y = (int) ((offset.z / GetPlaneHeight()) * gridHeight);

			if (Get(x, y) != null)
				return; // Already something there

			switch (selected) {
			case BlockType.CONVEYOR:
				Set(x, y, new Conveyor());
				break;
			case BlockType.GRABBER:
				break;
			case BlockType.COMBINER:
				// Test code
				Combiner combiner = new Combiner(new Recipe(ItemType.IRON_SHEET, new RecipePiece(ItemType.IRON_SHEET, 3)));
				Set(x, y, combiner);
				break;
			}
		}

		public void Set(int x, int y, Block block) {
			Block existing = Get(x, y);
			if (existing != null)
				existing.Destroy();

			block.SetPosition(GridToWorld(x, y));
			blocks[x, y] = block;

			// Testing code
			if (lastPlaced != null) {
				lastPlaced.nextBlock = block;
			}
			lastPlaced = block;
		}

		public void Remove(int x, int y) {
			Block b = Get(x, y);
			if (b != null) {
				b.Destroy();
				blocks[x, y] = null;
			}
		}

		public Block Get(int x, int y) {
			return blocks[x, y];
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
			world.y += tileOffsetY;
			world.z += (y * GetTileHeight()) + (GetTileHeight() / 2);
			return world;
		}
	}

}
