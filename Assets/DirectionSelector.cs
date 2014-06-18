using UnityEngine;
using System.Collections;
namespace pp{
	public class DirectionSelector : MonoBehaviour {
		
		void OnGUI () {
			GameObject obj = GameObject.Find ("Plane");
			Grid grid =	obj.GetComponent<Grid>();
			
			GUI.Box(new Rect(800,10,100,150), "Select Direction");
			
			if(GUI.Button(new Rect(810,40,80,20), "NORTH")) {
				grid.direction = Direction.NORTH;
			}
			
			if(GUI.Button(new Rect(810,70,80,20), "EAST")) {
				grid.direction = Direction.EAST;
			}
			
			if(GUI.Button(new Rect(810,100,80,20), "SOUTH")) {
				grid.direction = Direction.SOUTH;
			}
			if(GUI.Button(new Rect(810,130,80,20), "WEST")) {
				grid.direction = Direction.WEST;

			}
		}
	
	

	
	
	}
}