using UnityEngine;
using System.Collections.Generic;
namespace pp {

	/// <summary>
	/// An object which can appear on a conveyor belt.
	/// </summary>
	public abstract class Item : Entity {
		private const float fallFadeDelay = 4.0f;
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
			gameObject.AddComponent<Rigidbody>();
			gameObject.AddComponent<BoxCollider>();

			gameObject.rigidbody.isKinematic = true;
		}

		public void Fall(Vector3 towards) {
			gameObject.rigidbody.isKinematic = false;

			towards.Scale(new Vector3(180.0f + (50.0f * (float) rng.NextDouble()),
			                          0.0f,
			                          200.0f + (50.0f * (float) rng.NextDouble())));
			towards.y = 180.0f;
			gameObject.rigidbody.AddForce(towards, ForceMode.Acceleration);

			GameObject.Destroy(gameObject, fallFadeDelay);
		}
	}

}