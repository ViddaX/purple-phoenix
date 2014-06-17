using UnityEngine;

namespace pp {

	/// <summary>
	/// A game object.
	/// </summary>
	public abstract class Entity {
		public GameObject gameObject { set; get; }

		public Entity(string prefab) {
			this.gameObject = (GameObject) Object.Instantiate(Resources.Load(prefab));
		}

		public virtual void Destroy() {
			GameObject.Destroy(gameObject);
		}
	}

}