using UnityEngine;
using System.Collections;

namespace pp {

	/// <summary>
	/// A physical game block.
	/// </summary>
	public abstract class Block : Entity {
		public float height { set; get; }
		public Block nextBlock { set; get; }
		public Item item { set; get; }
		public Direction direction { set; get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Block"/> class.
		/// </summary>
		/// <param name="prefab">The prefab identifier used to create the game object</param>
		public Block(string prefab) : base(prefab) {
			this.direction = Direction.NORTH;
		}

		/// <summary>
		/// Called when an item enters this block.
		/// </summary>
		/// <param name="o">The item</param>
		public virtual void OnEnter(Item item) {
			this.item = item;
		}

		/// <summary>
		/// Called when an item leaves this block.
		/// </summary>
		/// <param name="item">The item</param>
		public virtual void OnExit(Item item) {
			this.item = null;
		}

		public void SetPosition(Vector3 pos) {
			gameObject.transform.position = pos;
		}
	}

}