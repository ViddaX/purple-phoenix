using UnityEngine;
using System;

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
			try {
				this.gameObject = (GameObject) UnityEngine.Object.Instantiate(Resources.Load(prefab));
			} catch (Exception) {
				Debug.LogWarning("Missing prefab " + prefab + ", falling back to default");
				this.gameObject = (GameObject) UnityEngine.Object.Instantiate(Resources.Load("items/IronSheet"));
			}
		}

		public virtual void Destroy() {
			GameObject.Destroy(gameObject);
		}
	}

}