
namespace pp {

	public struct Vector2i {
		public int x;
		public int y;
		public static Vector2i zero { get { return new Vector2i(0, 0); } }

		public Vector2i(int x, int y) {
			this.x = x;
			this.y = y;
		}
	}

}
