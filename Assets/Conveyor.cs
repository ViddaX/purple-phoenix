using UnityEngine;

namespace pp {
	/// <summary>
	/// A block which transports items.
	/// </summary>
	public class Conveyor : Block {
		private float timeTaken = 1000;
		private float entered;

		public Conveyor(Grid grid, Block next) : base(grid, next) {
			gameObject = (GameObject) Object.Instantiate(grid.conveyorPrefap);
		}

		public override void OnEnter(Item item) {
			base.OnEnter(item);
			entered = Time.time;
		}

		public void FixedUpdate() {
			// Lerp from here to next block in the chain
			if (item != null && next != null) {
				Vector3 me = gameObject.transform.position;
				me.y += height;

				Vector3 them = next.gameObject.transform.position;
				them.y += height;

				item.GameObject.transform.position = Vector3.Lerp(me, them, (Time.time - entered / timeTaken));
			}
		}
	}

}