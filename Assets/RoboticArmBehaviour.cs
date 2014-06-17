using UnityEngine;
using System.Collections;

namespace pp
{
	public class RoboticArmBehaviour : MonoBehaviour
	{
		private Item item;
		private float rotSpeed = 3.0f;

		public RoboticArm p { get; set; }

		// Update is called once per frame
		void Update ()
		{
			Vector3 target;
			if (item != null)
				target = p.to.worldPosition;
			else
				target = p.from.worldPosition;

			Vector3 to = target - p.worldPosition;
			
			float dot = Vector3.Dot(p.gameObject.transform.right, to.normalized);
			if (dot > 0.99) {
				if (item == null) {
					if (p.from.items.Count == 0)
						return;

					item = p.from.items [0];
					p.from.OnExit (item);
					item.worldPosition = p.worldPosition;
				} else {
					p.to.OnEnter (item);
					item = null;
				}
			} else {
				p.gameObject.transform.Rotate (Vector3.up, rotSpeed);
			}
		}
	}
}