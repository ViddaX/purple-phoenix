using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour {
	private const float moveSpeed = 0.25f;
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
		vel.y *= floatiness*20;
		vel.z *= floatiness;
		if (Math.Abs(vel.x) < cutoff || Math.Abs (vel.y) < cutoff )
			vel.x = 0;
			vel.y = 0;
			vel.z = 0;
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			vel.x -= moveSpeed;
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			vel.x += moveSpeed;
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			vel.z += moveSpeed;
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			vel.z -= moveSpeed;
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			vel.y+= moveSpeed*4;
			
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			vel.y-= moveSpeed*4;
		}
		Vector3 pos = transform.position + vel;
		pos.x = Math.Max(Math.Min (pos.x, max.x), min.x);
		pos.z = Math.Max(Math.Min (pos.z, max.z), min.z);
		transform.position = pos;
	}
}
