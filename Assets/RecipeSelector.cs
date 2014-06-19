using UnityEngine;
using System.Collections;

namespace pp
{
		public class RecipeSelector : MonoBehaviour
		{
			public static bool show;
			public GUISkin Skin;

			void OnGUI ()
			{
				GameObject obj = GameObject.Find ("Plane");
				Grid grid = obj.GetComponent<Grid> ();
				GUI.skin = Skin;
				if (show == true) {
					GUI.Box (new Rect (200, 70, 130, 195), "Recipe");

					if (GUI.Button (new Rect (210, 100, 110, 30), "Seat")) {
						grid.Recipe = ItemType.Seat;
					}
					if (GUI.Button (new Rect (210, 130, 110, 30), "Wheel")) {
						grid.Recipe = ItemType.Wheel;
					}
					if (GUI.Button (new Rect (210, 160, 110, 30), "Car body")) {
						grid.Recipe = ItemType.Car_body;
					}
					if (GUI.Button (new Rect (210, 190, 110, 30), "Window")) {
						grid.Recipe = ItemType.Window;
					}
					if (GUI.Button (new Rect (210, 220, 110, 30), "Car")) {
						grid.Recipe = ItemType.Car;
					}
				}
			}
		}
}
