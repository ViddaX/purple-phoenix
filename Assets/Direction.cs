using UnityEngine;

namespace pp {

/// <summary>
/// Compass directions.
/// </summary>
public enum Direction {
	NORTH,
	SOUTH,
	EAST,
	WEST
}

public static class Extensions {
	private static Vector3[] dirs = {new Vector3(1, 0), new Vector3(-1, 0), new Vector3(0, 1), new Vector3(1, 0)};

	public static Vector3 GetVector(this Direction dir) {
		return dirs[(int) dir];
	}
}

}
