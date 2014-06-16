using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour {
	private const float zoomSpeedMul = 5.0f;
	private const float maxZoomIn = 0.5f;
	private const float maxZoomOut = 10.0f;
	private float startY;
	private Vector3 offset;

	public void Awake() {
		startY = transform.position.y;
	}

	public void Update () {
		float deltaZoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeedMul;

		Vector3 pos = transform.position;
		pos.y = Math.Max(Math.Min(startY + maxZoomOut, transform.position.y - deltaZoom), startY + maxZoomIn);
		transform.position = pos;
	}
}
