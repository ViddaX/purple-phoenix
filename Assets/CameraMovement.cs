using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour {
	private const float moveSpeed = 0.05f;
	private const float floatiness = 0.85f;
	private const float cutoff = 0.02f;
	public GameObject target;
	private Vector3 max;
	private Vector3 min;
	private Vector3 vel;

	public void Awake() {
		this.max = target.renderer.bounds.max;
		this.min = target.renderer.bounds.min;
	}

	public void FixedUpdate() {
		// Apply velocity
		vel.x *= floatiness;
		if (Math.Abs(vel.x) < cutoff)
			vel.x = 0;

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			vel.x -= moveSpeed;
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			vel.x += moveSpeed;

		Vector3 pos = transform.position + vel;
		pos.x = Math.Max(Math.Min (pos.x, max.x), min.x);

		transform.position = pos;
	}
}
