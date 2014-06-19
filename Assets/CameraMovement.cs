using UnityEngine;
using System;

namespace pp {

	public class CameraMovement : MonoBehaviour {
		private const float moveSpeed = 0.05f;
		private const float floatiness = 0.85f;
		private const float cutoff = 0.02f;
		private const float maxZoomIn = 5.0f;
		private const float maxZoomOut = 1.5f;
		private float startY;
		public GameObject target;
		private Vector3 max;
		private Vector3 min;
		private Vector3 vel;

		public void Awake() {
			this.startY = transform.position.y;
			this.max = target.renderer.bounds.max;
			this.min = target.renderer.bounds.min;
		}

		public void FixedUpdate() {
			// Apply velocity
			vel *= floatiness;
			if (vel.sqrMagnitude < cutoff * cutoff)
				vel = Vector3.zero;

			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
				vel.x -= moveSpeed;
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
				vel.x += moveSpeed;
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
				vel.z += moveSpeed;
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
				vel.z -= moveSpeed;
			if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
				vel.y += moveSpeed * 4;
			if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
				vel.y -= moveSpeed * 4;

			// Constrain movement
			Vector3 pos = transform.position + vel;
			pos.x = Util.Clamp(pos.x, min.x, max.x);
			pos.y = Util.Clamp(pos.y, startY - maxZoomIn, startY + maxZoomOut);
			pos.z = Util.Clamp(pos.z, min.z - 10.0f, max.z - 10.0f);

			transform.position = pos;
		}

	}

}
