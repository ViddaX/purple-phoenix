using UnityEngine;
using System;
namespace pp {
	/// <summary>
	/// A block which transports items.
	/// </summary>
	public class Conveyor : Block {
		public float timeTaken { set; get; }

		public Conveyor() : this(BlockType.CONVEYOR) {
			timeTaken = 0.25f;
		}

		public Conveyor(BlockType type) : base(type) {
			gameObject.AddComponent<ConveyorBehaviour>().p = this;
			height = 0.5f;
		}
	}
}