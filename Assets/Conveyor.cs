using UnityEngine;

namespace pp {
	/// <summary>
	/// A block which transports items.
	/// </summary>
	public class Conveyor : Block {
		public float timeTaken { set; get; }
		public float entered { set; get; }

		public Conveyor() : this("conveyor") {
			timeTaken = 0.5f;
		}

		public Conveyor(string prefab) : base(prefab) {
			gameObject.AddComponent<ConveyorBehaviour>().p = this;
			height = 0.5f;
		}

		public override void OnEnter(Item item) {
			base.OnEnter(item);
			entered = Time.time;
		}
	}
}