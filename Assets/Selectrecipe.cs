using UnityEngine;
using System.Collections;
namespace pp {
public class Selectrecipe : MonoBehaviour {
		public static bool BuildComb;
	void OnGUI () {
						GameObject obj = GameObject.Find ("Plane");
						Grid grid = obj.GetComponent<Grid> ();

						if (BuildComb == true) {
								GUI.Box (new Rect (110, 10, 100, 175), "Recipe");
		
								if (GUI.Button (new Rect (120, 40, 80, 20), "Seat")) {
									RecipeFactory.NewRecipe(ItemType.Seat);
								}
		
								if (GUI.Button (new Rect (120, 70, 80, 20), "Wheel")) {
								RecipeFactory.NewRecipe(ItemType.Wheel);
								}
		
								if (GUI.Button (new Rect (120, 100, 80, 20), "Car body")) {
								RecipeFactory.NewRecipe(ItemType.Car_body);
								}
								if (GUI.Button (new Rect (120, 130, 80, 20), "Window")) {
								RecipeFactory.NewRecipe(ItemType.Window);
								}
								if (GUI.Button (new Rect (120, 160, 80, 20), "Car")) {
								RecipeFactory.NewRecipe(ItemType.Car);
								}
						}
				}
}
}
