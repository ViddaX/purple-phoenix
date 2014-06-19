using System;

namespace pp {

	public class BlockType {
		public static readonly BlockType Spawner = new BlockType("spawner");
		public static readonly BlockType Conveyor = new BlockType(10, "conveyor");
		public static readonly BlockType Grabber = new BlockType(100, "RoboticArm");
		public static readonly BlockType Combiner = new BlockType(50, "combiner");

		public readonly int price;
		public readonly string prefab;

		public BlockType(string prefab) {
			this.prefab = prefab;
			this.price = Int32.MaxValue;
		}

		public BlockType(int price, string prefab) {
			this.price = price;
			this.prefab = prefab;
		}
	}

}
