using UnityEngine;
using System;

namespace pp {

	public class ConveyorBehaviour : MonoBehaviour {
		public Conveyor p { set; get; }
		
		public void FixedUpdate() {
			if (p.nextBlock == null || p.items.Count == 0) 
				return;

			// Lerp from here to next block in the chain
			Item item = p.items.Peek();
			Vector3 me = p.gameObject.transform.position;
			Vector3 them = p.nextBlock.gameObject.transform.position;
			them.y = me.y;

			float progress = Math.Min((Time.time - p.lerpStart) / p.timeTaken, 1.0f);
			item.gameObject.transform.position = Vector3.Lerp(me, them, progress);

			if (progress >= 1.0f) {
				if (p.nextBlock != null) { // Pass along the item
					p.nextBlock.OnEnter(item);
					p.OnExit(item);
				}
			}
		}
	}

}