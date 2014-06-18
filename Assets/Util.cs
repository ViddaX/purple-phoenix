using UnityEngine;
using System;

namespace pp {

	public static class Util {
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

		public static string GetPrefabName(BlockType type) {
			switch (type) {
			case BlockType.COMBINER:
				return "spawner";
			case BlockType.CONVEYOR:
				return "conveyor";
			case BlockType.GRABBER:
				return "RoboticArm";
			case BlockType.SPAWNER:
				return "spawner";
			default:
				throw new NotImplementedException();
			}
		}
	}

}
