using UnityEngine;
using System.Collections;

namespace pp
{
	public class BuilderMenu : MonoBehaviour
	{
		public static bool show;
		public GUISkin Skin;

		
		void OnGUI ()
		{
			GameObject obj = GameObject.Find ("Plane");
			Grid grid = obj.GetComponent<Grid> ();
			GUI.skin = Skin;
			if (show == true) {
				GUI.Box (new Rect (200, 70, 130, 195), "Projects");
				
				
				if (GUI.Button (new Rect (210, 100, 110, 30), new GUIContent("Car", "Car"))) {
					grid.project = ProjectType.CAR;
				}
				if (GUI.Button (new Rect (210, 130, 110, 30), new GUIContent("Motor bike", "Motor bike"))) {
					grid.project = ProjectType.BIKE;
				}
			}
			
		}
	}
}