using UnityEngine;
using System.Collections;
namespace pp{
	public class DirectionSelector : MonoBehaviour {
		
		void OnGUI () {
			GameObject obj = GameObject.Find ("Plane");
			Grid grid =	obj.GetComponent<Grid>();
			
			GUI.Box(new Rect(800,10,100,150), "Select Direction");
			
			if(GUI.Button(new Rect(810,40,80,20), "Right")) {
				grid.direction = Direction.NORTH;
			}
			
			if(GUI.Button(new Rect(810,70,80,20), "Down")) {
				grid.direction = Direction.EAST;
			}
			
			if(GUI.Button(new Rect(810,100,80,20), "Left")) {
				grid.direction = Direction.SOUTH;
			}
			if(GUI.Button(new Rect(810,130,80,20), "Up")) {
				// Fuck you josh I hope your eyes bleed to death!!!!! :@
				grid.direction = Direction.WEST;

			}
		}
	
	

	
	
	}
}