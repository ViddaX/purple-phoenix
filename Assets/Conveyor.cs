using UnityEngine;
using System;
namespace pp {
	/// <summary>
	/// A block which transports items.
	/// </summary>
	public class Conveyor : Block {
		public float timeTaken { set; get; }

		public Conveyor() : this(BlockType.CONVEYOR, "conveyor") {
			timeTaken = 0.5f;
		}

		public Conveyor(BlockType type, string prefab) : base(type, prefab) {
			gameObject.AddComponent<ConveyorBehaviour>().p = this;
			height = 0.5f;
		}
	}
}