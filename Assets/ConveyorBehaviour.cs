using UnityEngine;
using System;

namespace pp {

	public class ConveyorBehaviour : MonoBehaviour {
		private Item lastAffected;
		private Vector3 from;
		private Vector3 to;
		private int stage;
		public float lerpStart;
		public Conveyor p { set; get; }
		
		public void FixedUpdate() {
			if (p.items.Count == 0) 
				return;

			Item affected = p.items [0];
			if (lastAffected != affected) {
				stage = 0;
				SetupAnimation(affected.worldPosition, p.worldPosition);
				lastAffected = affected ;
			}

			float progress = Math.Min((Time.time - lerpStart) / p.timeTaken, 1.0f);
			if (progress >= 1.0f) { // Reached center, go in p.direction
				Vector3 dir3 = GetDirectionVector(p.direction);
				if (stage == 1) {
					dir3.Scale(new Vector3(p.size.x / 2, 0, p.size.x / 2));
					SetupAnimation(p.worldPosition, p.worldPosition + dir3);
				} else {
					Block next = p.grid.Get(p.coords + new Vector2(dir3.x, dir3.z));
					if (next != null) {
						next.OnEnter(affected); // Pass along the item
					} else {
						affected.Destroy();
						// TODO Fall off conveyor belt
					}
					p.OnExit(affected);

					// Reset for next item
					affected = null;
					stage = 0;
				}
			} else {
				if (affected != null && progress > 0.0f)
					affected.worldPosition = Vector3.Lerp(from, to, progress);
			}
		}

		private void SetupAnimation(Vector3 from, Vector3 to) {
			stage++;
			lerpStart = Time.time;
			this.from = from;
			this.to = to;

			// Constrain Y axis
			from.y = p.worldPosition.y;
			to.y = p.worldPosition.y;
		}

		private Vector3 GetDirectionVector(Direction dir) {
			switch (dir) {
			case Direction.NORTH:
				return new Vector3(1.0f, 0.0f);
			case Direction.EAST:
				return new Vector3(0.0f, 0.0f, -1.0f);
			case Direction.SOUTH:
				return new Vector3(-1.0f, 0.0f);
			case Direction.WEST:
				return new Vector3(0.0f, 0.0f, 1.0f);
			default:
				throw new NotImplementedException();
			}
		}
	}

}