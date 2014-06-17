using UnityEngine;
using System.Collections;

namespace pp
{
		public class RoboticArm : Block
		{
				public Block from { get; set; }

				public Block to { get; set; }

				public RoboticArm (Block b1, Block b2) : this(BlockType.GRABBER,"RoboticArm")
				{
						from = b1;
						to = b2;
				}
	
				public RoboticArm (BlockType type, string prefab) : base(type, prefab)
				{
						gameObject.AddComponent<RoboticArmBehaviour> ().p = this;
		
				}
		}
}