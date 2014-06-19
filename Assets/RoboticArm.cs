using UnityEngine;
using System.Collections;

namespace pp
{
	public class RoboticArm : Block {
		public Block from { get; set; }
		public Block to { get; set; }

		public RoboticArm (Block from, Block to) : this(BlockType.Grabber) {
			this.from = from;
			this.to = to;
		}

		public RoboticArm (BlockType type) : base(type) {
			gameObject.AddComponent<RoboticArmBehaviour> ().p = this;
		}
	}
}