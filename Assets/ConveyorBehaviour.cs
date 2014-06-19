using UnityEngine;
using System;

namespace pp {

	public class ConveyorBehaviour : MonoBehaviour {
		private const int maxItems = 1;
		private GameObject belt;
		private Item lastAffected;
		private Vector3 from;
		private Vector3 to;
		private int stage;
		public float lerpStart;
		public Conveyor p { set; get; }
		public int materialIndex = 0;
		public Texture[] textures;
		public float changeInterval = 0.33F;
		private string textureName = "_MainTex";
		
		Vector2 uvOffset = Vector2.zero;
		public void FixedUpdate() {
			UpdateItems();
		}

		protected void UpdateItems() {
			int count = p.items.Count;
			if (count >= maxItems + 1) { // throw something off if we get too full
				p.items[maxItems].Fall(p.gameObject.transform.forward);
				p.items.RemoveAt(maxItems);
			} else if (count == 0) {
				return;
			}
			
			Item affected = p.items [0];
			if (lastAffected != affected) {
				stage = 0;
				SetupAnimation(affected.worldPosition, p.worldPosition);
				lastAffected = affected ;
			}
			
			float progress = Math.Min((Time.time - lerpStart) / p.timeTaken, 1.0f);
			if (progress >= 1.0f) { // Reached center, go in p.direction
				Vector3 dir3 = p.direction.GetDirectionVector();
				if (stage == 1) {
					dir3.Scale(new Vector3(p.size.x / 2, 0, p.size.x / 2));
					SetupAnimation(p.worldPosition, p.worldPosition + dir3);
				} else {
					Block next = p.grid.Get((int) dir3.x + p.coords.x, (int) dir3.z + p.coords.y);
					if (next != null && (next is Conveyor || next is Splitter)) {
						next.OnEnter(affected); // Pass along the item
					} else {
						affected.Fall(p.gameObject.transform.forward);
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
			this.from.y = p.worldPosition.y + 0.35f;
			this.to.y = this.from.y;
		}
	
		void Start(){
			belt = p.gameObject.transform.FindChild("Cube").gameObject;
			belt.renderer.enabled = true;
		}
		void LateUpdate()
		{
			uvOffset.y = p.grid.conveyorTextureY;
		
			if( belt.renderer.enabled )
			{
			
				belt.renderer.materials[ materialIndex ].SetTextureOffset( textureName, uvOffset );

			}

		}
	}

}