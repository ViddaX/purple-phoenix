using UnityEngine;
using System; 

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

		public Spawner() : this(BlockType.Spawner) {
		}

		public Spawner(BlockType type) : base(type) {
			gameObject.AddComponent<SpawnerBehaviour>().p = this;
		}

		public void Start() {
			SelectNextItem();

			ResetSpawnTimer();
			mRunning = true;
		}

		public void Stop() {
			mRunning = false;
		}

		public void ResetSpawnTimer() {
			mNextSpawn = Time.time + spawnDelay;
		}

		public Item Spawn() {
			Item i = Item.NewItem(nextItem);
			SelectNextItem();
			return i;
		}

		public void SelectNextItem() {
			Array all = Enum.GetValues(typeof(ItemType));
			nextItem = (ItemType) all.GetValue(1 + Util.rng.Next(all.Length - 2));
		}
	}

}