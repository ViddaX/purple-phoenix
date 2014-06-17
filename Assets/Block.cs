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
		public Vector2 coords { set; get; }
		public Grid grid { set; get; }
		private Direction mDirection;
		public Direction direction {
			set {
				mDirection = value;
				gameObject.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), Util.GetRotationAngle(mDirection));
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
		public Block(BlockType type, string prefab) : base(prefab) {
			this.items = new List<Item>();
			this.mBlockType = type;
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
	}

}