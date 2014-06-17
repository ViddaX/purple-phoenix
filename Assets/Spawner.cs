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

		public Spawner() : this(BlockType.SPAWNER, "spawner") {
		}

		public Spawner(BlockType type,string prefab) : base(type,prefab) {
			gameObject.AddComponent<SpawnerBehaviour>().p = this;
		}

		public void Start() {
			ResetSpawnTimer();
			mRunning = true;
		}

		public void Stop() {
			mRunning = false;
		}

		public void ResetSpawnTimer() {
			mNextSpawn = Time.time + spawnDelay;
		}

		public static Item Spawn(ItemType type) {
			switch (type) {
			case ItemType.IRON_SHEET:
				return new IronSheet();
			default:
				return null;
			}
		}
	}

}