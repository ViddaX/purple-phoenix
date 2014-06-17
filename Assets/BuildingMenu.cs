using UnityEngine;
using System.Collections;
namespace pp{
	public class BuildingMenu : MonoBehaviour {
		
		void OnGUI () {
			
			// Make a background box
			GUI.Box(new Rect(10,10,100,90), "Build Menu");
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(20,40,80,20), "Conveyor")) {
				GameObject obj = GameObject.Find ("Plane");
				Grid grid =	obj.GetComponent<Grid>();
				grid.buildcase = 1;
			}
			
			// Make the second button.
			if(GUI.Button(new Rect(20,70,80,20), "Robotic Arm")) {
				GameObject obj = GameObject.Find ("Plane");
				Grid grid =	obj.GetComponent<Grid>();
				grid.buildcase = 2;
			}
		}
	}
}