using UnityEngine;
using System;

namespace pp {

	public static class Util {
		public static float GetRotationAngle(this Direction dir) {
			switch (dir) {
			case Direction.EAST:
				return 0.0f;
			case Direction.NORTH:
				return 90.0f;
			case Direction.WEST:
				return 180.0f;
			case Direction.SOUTH:
				return 270.0f;
			default:
				throw new NotImplementedException();
			}
		}

		public static float Clamp(float f, float min, float max) {
			return Math.Min(Math.Max (f, min), max);
		}
	}

}
