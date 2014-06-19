using UnityEngine;
using System.Collections;

namespace pp
{
		public class RecipeSelector : MonoBehaviour
		{
			public static bool show;
			public GUISkin Skin;
		private string hover = "";

			void OnGUI ()
			{
				GameObject obj = GameObject.Find ("Plane");
				Grid grid = obj.GetComponent<Grid> ();
				GUI.skin = Skin;
				if (show == true) {
					GUI.Box (new Rect (200, 70, 130, 195), "Recipe");


				if (GUI.Button (new Rect (210, 100, 110, 30), new GUIContent("Seat", "Seat"))) {
						grid.recipe = ItemType.Seat;
					}
				if (GUI.Button (new Rect (210, 130, 110, 30), new GUIContent("Wheel", "Wheel"))) {
						grid.recipe = ItemType.Wheel;
					}
				if (GUI.Button (new Rect (210, 160, 110, 30), new GUIContent("Car Body", "Car_Body"))) {
						grid.recipe = ItemType.CarBody;
					}
				if (GUI.Button (new Rect (210, 190, 110, 30), new GUIContent("Window", "Window"))) {
						grid.recipe = ItemType.Window;
					}
			
				}
					hover = GUI.tooltip; 
					Displayrecipe (hover);
		
		}
	
		void Displayrecipe(string hover)
		{
			switch (hover) {
			case "Seat":
				GUI.Box (new Rect (350, 70, 130, 195), "2xLeather \n 1xCotton");
				break;
			case "Wheel":
				GUI.Box (new Rect (350, 70, 130, 195), "1xRubber \n 1xAluminium");
				break;
			case "Car_Body":
				GUI.Box (new Rect (350, 70, 130, 195), "8xSteel");
				break;
			case "Window":
				GUI.Box (new Rect (350, 70, 130, 195), "1xGlass");
				break;
			case "Car":
				GUI.Box (new Rect (350, 70, 130, 195), "4xWheel\n 1xCar Body \n4xWindow");
				break;
			}
		}

	}
}
