using UnityEngine;

namespace pp {

	/// <summary>
	/// A block that spawns raw materials.
	/// </summary>
	public class Spawner : Conveyor {
		private const float spawnDelay = 1.5f;
		private float mNextSpawn;
		private bool mRunning;
		public float nextSpawn { get { return mNextSpawn; } }
		public bool running { get { return mRunning; } }
		public ItemType nextItem { set; get; }

		public Spawner() : this("spawner") {
		}

		public Spawner(string prefab) : base(prefab) {
			gameObject.AddComponent<SpawnerBehaviour>().p = this;
		}

		public void Start() {
			ResetSpawnTimer();
			mRunning = true;
		}

		public void Stop() {
			mRunning = false;
		}

		private void ResetSpawnTimer() {
			mNextSpawn = Time.time + spawnDelay;
		}

		public Item Spawn(ItemType type) {
			ResetSpawnTimer();

			switch (type) {
			case ItemType.IRON_SHEET:
				return new IronSheet();
			default:
				return null;
			}
		}
	}

}