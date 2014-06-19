using UnityEngine;
using System;

namespace pp {

	public static class Util {
		public static readonly System.Random rng = new System.Random();

		public static float GetRotationAngle(this Direction dir) {
			switch (dir) {
			case Direction.NORTH:
				return 90.0f;
			case Direction.EAST:
				return 180.0f;
			case Direction.SOUTH:
				return 270.0f;
			case Direction.WEST:
				return 0.0f;
			default:
				throw new NotImplementedException();
			}
		}

		public static float Clamp(float f, float min, float max) {
			return Math.Min(Math.Max (f, min), max);
		}

		public static void ScaleGUI() {
			//set up scaling
			float rx = Screen.width / 1680.0f;
			float ry = Screen.height / 1050.0f;
			GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3 (rx, ry, 1)); 
		}

		public static Vector3 GetDirectionVector(this Direction dir) {
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
				Debug.Log (dir);
				throw new NotImplementedException();
			}
		}
	}

}
