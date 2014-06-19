using UnityEngine;
using System.Collections.Generic;

namespace pp {

	/// <summary>
	/// A physical game block.
	/// </summary>
	public abstract class Block : Entity {
		private BlockType mBlockType;
		public BlockType blockType { get { return mBlockType; } }
		public float height { set; get; }
		public List<Item> items { set; get; }
		public Vector2i coords { set; get; }
		public Grid grid { set; get; }
		private float rotation;
		private Direction mDirection;
		public Direction direction {
			set {
				mDirection = value;

				float newRot = Util.GetRotationAngle(mDirection);
				gameObject.transform.Rotate(Vector3.up, newRot - rotation);
				rotation = newRot;
			}
			get {
				return mDirection;
			}
		}
		public override Vector3 size {
			get { return new Vector3(grid.GetTileWidth(), 0, grid.GetTileWidth()); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Block"/> class.
		/// </summary>
		/// <param name="prefab">The prefab identifier used to create the game object</param>
		public Block(BlockType type) : base(type.prefab) {
			this.items = new List<Item>();
			this.mBlockType = type;

			gameObject.AddComponent<Rigidbody>();
			gameObject.AddComponent<BoxCollider>();
			gameObject.rigidbody.isKinematic = true;
		}

		/// <summary>
		/// Called when an item enters this block.
		/// </summary>
		/// <param name="o">The item</param>
		public virtual void OnEnter(Item item) {
			this.items.Add(item);
		}

		/// <summary>
		/// Called when an item leaves this block.
		/// </summary>
		/// <param name="item">The item</param>
		public virtual Item OnExit(Item item) {
			this.items.Remove(item);
			return item;
		}

		public override void Destroy () {
			foreach (Item i in items)
				i.Destroy();

			base.Destroy();
		}

		public bool Empty() {
			return items.Count == 0;
		}

		public void Rotate(bool clockwise) {
			int dir = clockwise ? -1 : 1;
			int newDir = (int) direction + dir;

			if (newDir < 0)
				newDir = 3;
			if (newDir > 3)
				newDir = 0;

			direction = (Direction) newDir;
		}
	}

}