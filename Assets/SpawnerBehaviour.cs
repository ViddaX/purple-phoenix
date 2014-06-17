using UnityEngine;

namespace pp {

	public class SpawnerBehaviour : MonoBehaviour {
		public Spawner p { set; get; }
		
		public void Update() {
			if (Time.time < p.nextSpawn || !p.running)
				return;
			
			// Time to spawn an item
			if (p.nextItem != ItemType.NONE && p.nextBlock != null) {
				Item item = Spawner.Spawn(p.nextItem);
				p.ResetSpawnTimer();

				p.items.Enqueue(item);
			}
		}
	}

}