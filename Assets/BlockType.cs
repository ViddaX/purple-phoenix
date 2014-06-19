using System;

namespace pp {

	public class BlockType {
		public static readonly BlockType Spawner = new BlockType("spawner");
		public static readonly BlockType Conveyor = new BlockType(10, "conveyor");
		public static readonly BlockType Grabber = new BlockType(100, "RoboticArm");
		public static readonly BlockType Combiner = new BlockType(50, "spawner");
		public static readonly BlockType Splitter = new BlockType(25, "spawner");
		public static readonly BlockType Builder = new BlockType(50, "spawner");

		public readonly int price;
		public readonly string prefab;
		public readonly bool modifiable;

		public BlockType(string prefab) {
			this.prefab = prefab;
			this.price = Int32.MaxValue;
			this.modifiable = false;
		}

		public BlockType(int price, string prefab) {
			this.price = price;
			this.prefab = prefab;
			this.modifiable = true;
		}
	}

}
