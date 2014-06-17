using UnityEngine;
using System;

namespace pp {

	public class ConveyorBehaviour : MonoBehaviour {
		public Conveyor p { set; get; }
		
		public void FixedUpdate() {
			// Lerp from here to next block in the chain
			if (p.item != null && p.nextBlock != null) {
				Vector3 me = p.gameObject.transform.position;
				Vector3 them = p.nextBlock.gameObject.transform.position;
				them.y = me.y;

				float progress = Math.Min((Time.time - p.entered) / p.timeTaken, 1.0f);
				p.item.gameObject.transform.position = Vector3.Lerp(me, them, progress);

				if (progress >= 1.0f) {
					if (p.nextBlock != null) { // Pass along the item
						p.nextBlock.OnEnter(p.item);
						p.OnExit(p.item);
					}
				}
			}
		}
	}

}