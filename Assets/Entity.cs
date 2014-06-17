using UnityEngine;

namespace pp {

	/// <summary>
	/// A game object.
	/// </summary>
	public abstract class Entity {
		public GameObject gameObject { set; get; }
		public Vector3 worldPosition { 
			set {
				gameObject.transform.position = value;
			}
			get {
				return gameObject.transform.position;
			}
		}
		public virtual Vector3 size {
			get {
				return gameObject.renderer.bounds.size;
			}
		}

		public Entity(string prefab) {
			this.gameObject = (GameObject) Object.Instantiate(Resources.Load(prefab));
		}

		public virtual void Destroy() {
			GameObject.Destroy(gameObject);
		}
	}

}