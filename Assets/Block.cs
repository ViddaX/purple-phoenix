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
		public Block nextBlock { set; get; }
		public Queue<Item> items { set; get; }
		public Direction direction { set; get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Block"/> class.
		/// </summary>
		/// <param name="prefab">The prefab identifier used to create the game object</param>
		public Block(BlockType type, string prefab) : base(prefab) {
			this.items = new Queue<Item>();
			this.direction = Direction.NORTH;
			this.mBlockType = type;
		}

		/// <summary>
		/// Called when an item enters this block.
		/// </summary>
		/// <param name="o">The item</param>
		public virtual void OnEnter(Item item) {
			this.items.Enqueue(item);
		}

		/// <summary>
		/// Called when an item leaves this block.
		/// </summary>
		/// <param name="item">The item</param>
		public virtual void OnExit(Item item) {
			this.items.Dequeue();
		}

		public void SetPosition(Vector3 pos) {
			gameObject.transform.position = pos;
		}
	}

}