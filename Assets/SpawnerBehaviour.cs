using UnityEngine;

namespace pp {

	public class SpawnerBehaviour : MonoBehaviour {
		public Spawner p { set; get; }
		
		public void Update() {
			if (Time.time < p.nextSpawn || !p.running)
				return;
			
			// Time to spawn an item
			if (p.nextItem != ItemType.NONE && p.nextBlock != null) {
				if (p.item != null)
					p.nextBlock.item = p.item;
				p.item = p.Spawn(p.nextItem);
			}
		}
	}

}