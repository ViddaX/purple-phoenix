using UnityEngine;

namespace pp {

	/// <summary>
	/// An object which can appear on a conveyor belt.
	/// </summary>
	public abstract class Item : Entity {
		protected ItemType type;
		public ItemType itemType { get { return type; } }
		public GameObject GameObject { set; get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="pp.Item"/> class.
		/// </summary>
		/// <param name="type">The item's type</param>
		/// <param name="prefab">The prefab used to create the game object</param>
		public Item(ItemType type, string prefab) : base(prefab) {
			this.type = type;
		}
		
		/// <summary>
		/// Determines whether this item can combine with the specified type.
		/// </summary>
		/// <returns><c>true</c> if this item can combine with other; otherwise, <c>false</c>.</returns>
		/// <param name="type">The other item's type</param>
		public abstract bool CanCombine(ItemType type);

		/// <summary>
		/// Combines with the specified item.
		/// </summary>
		/// <param name="item">The other item</param>
		public abstract Item Combine(Item item);
	}

}