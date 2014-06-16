using UnityEngine;
using System.Collections;

namespace pp {

	/// <summary>
	/// A physical game block.
	/// </summary>
	public abstract class Block {
		protected Grid grid;
		protected Block next;
		protected Item item;
		protected float height;

		private GameObject obj;
		public GameObject gameObject { 
			set { obj = value; this.height = gameObject.collider.bounds.max.y / 2; }
			get { return obj; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Block"/> class.
		/// </summary>
		/// <param name="next">The next block in the belt</param>
		/// <param name="o">The block's physical object</param>
		public Block(Grid grid, Block next) {
			this.grid = grid;
			this.next = next;
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

		/// <summary>
		/// Called when this block is removed.
		/// </summary>
		public virtual void OnDestroy() {
			GameObject.Destroy(gameObject);
		}

		public void SetPosition(Vector3 pos) {
			gameObject.transform.position = pos;
		}
	}

}