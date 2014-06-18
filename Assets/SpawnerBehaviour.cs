using UnityEngine;
using System;

namespace pp {

	public class SpawnerBehaviour : MonoBehaviour {
		private System.Random rng = new System.Random();
		public Spawner p { set; get; }
		
		public void Update() {
			if (Time.time < p.nextSpawn || !p.running)
				return;
			
			// Time to spawn an item
			if (p.nextItem != ItemType.NONE) {
				Item item = Spawner.Spawn(p.nextItem);

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