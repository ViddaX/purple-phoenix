using UnityEngine;
using System.Collections;
namespace pp{
public class RoboticArm : Block {
		
		public RoboticArm(Block b1, Block b2) : this(BlockType.GRABBER,"RoboticArm") {
		
	}
	
		public RoboticArm(BlockType type,string prefab) : base(type, prefab) {
			gameObject.AddComponent<RoboticArmBehaviour>().p = this;
		
	}
}
}