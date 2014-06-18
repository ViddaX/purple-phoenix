using UnityEngine;
using System.Collections;
namespace pp {
public class Selectrecipe : MonoBehaviour {
		public static bool BuildComb;
		public GUISkin Skin;
	void OnGUI () {
						GameObject obj = GameObject.Find ("Plane");
						Grid grid = obj.GetComponent<Grid> ();
						GUI.skin = Skin;
						if (BuildComb == true) {
								GUI.Box (new Rect (110, 10, 100, 175), "Recipe");
		
								if (GUI.Button (new Rect (120, 40, 80, 20), "Seat")) {
									grid.Recipe = ItemType.Seat;
								}
								if (GUI.Button (new Rect (120, 70, 80, 20), "Wheel")) {
								grid.Recipe = ItemType.Wheel;
								}
								if (GUI.Button (new Rect (120, 100, 80, 20), "Car body")) {
								grid.Recipe = ItemType.Car_body;
								}
								if (GUI.Button (new Rect (120, 130, 80, 20), "Window")) {
								grid.Recipe = ItemType.Window;
								}
								if (GUI.Button (new Rect (120, 160, 80, 20), "Car")) {
								grid.Recipe = ItemType.Car;
								}
						}
				}
		}
}
