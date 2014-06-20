using UnityEngine;
using System.Collections.Generic;
using System;

namespace pp {

	/// <summary>
	/// An object which can appear on a conveyor belt.
	/// </summary>
	public class Item : Entity {
		private const float fallFadeDelay = 2.0f;
		private System.Random rng = new System.Random();
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
			if (gameObject.rigidbody == null)
				gameObject.AddComponent<Rigidbody>();
			if (gameObject.collider == null)
				gameObject.AddComponent<BoxCollider>();

			gameObject.rigidbody.isKinematic = true;
		}

		public void Fall(Vector3 towards) {
			gameObject.rigidbody.isKinematic = false;

			towards.Scale(new Vector3(4.8f + (1.5f * (float) rng.NextDouble()),
			                          0.0f,
			                          3.0f + (1.5f * (float) rng.NextDouble())));
			towards.y = 2.5f;

			if (gameObject.rigidbody != null) {
				gameObject.rigidbody.AddForce(towards, ForceMode.VelocityChange);
			}

			GameObject.Destroy(gameObject, fallFadeDelay);
		}

		public static Item NewItem(ItemType type) {
			// Use the enum name for prefab
			return new Item(type, "items/" + Enum.GetName(typeof(ItemType), type));
		}
	}

}