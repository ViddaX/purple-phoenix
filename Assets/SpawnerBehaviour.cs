using UnityEngine;
using System;

namespace pp {

	public class SpawnerBehaviour : MonoBehaviour {
		private System.Random rng = new System.Random();
		public Spawner p { set; get; }
		
		public void Update() {
			if (Time.time < p.nextSpawn || !p.running)
				return;

			Vector3 dir = p.direction.GetDirectionVector();
			Block next = p.grid.Get (p.coords.x + (int) dir.x, p.coords.y + (int) dir.z);
			if (next == null || !(next is Conveyor))
				return;

			// Time to spawn an item
			if (p.nextItem != ItemType.None) {
				Item item = p.Spawn();

				Vector3 spawnPos = p.worldPosition;
				spawnPos.y += 0.4f;
				item.worldPosition = spawnPos;

				// Apply a random rotation
				item.gameObject.transform.Rotate(Vector3.up, (float) rng.NextDouble() * 360.0f);

				p.ResetSpawnTimer();
				p.OnEnter(item);
			}
		}
	}

}