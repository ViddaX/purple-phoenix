using UnityEngine;

namespace pp {
	
	public class Marker : Entity {
		public Marker() : base("selection") {
			Color color = gameObject.renderer.material.color;
			color.a = 0.35f;

			gameObject.renderer.material.color = color;
		}
	}

}