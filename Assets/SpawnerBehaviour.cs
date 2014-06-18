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
				item.worldPosition = p.worldPosition;

				// Apply a random rotation
				item.gameObject.transform.Rotate(Vector3.up, (float) rng.NextDouble() * 360.0f);

				p.ResetSpawnTimer();
				p.OnEnter(item);
			}
		}
	}

}