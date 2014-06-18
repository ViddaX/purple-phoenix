using UnityEngine;
using System.Collections;
namespace pp{
	public class DirectionSelector : MonoBehaviour {
		public GUISkin Skin;
		void OnGUI () {
			GameObject obj = GameObject.Find ("Plane");
			Grid grid =	obj.GetComponent<Grid>();
			GUI.skin = Skin;
			GUI.Box(new Rect(1400,10,150,150), "Select Direction");
			
			if(GUI.Button(new Rect(1420,40,80,20), "Right")) {
				grid.direction = Direction.NORTH;
			}
			
			if(GUI.Button(new Rect(1420,70,80,20), "Down")) {
				grid.direction = Direction.EAST;
			}
			
			if(GUI.Button(new Rect(1420,100,80,20), "Left")) {
				grid.direction = Direction.SOUTH;
			}
			if(GUI.Button(new Rect(1420,130,80,20), "Up")) {
				// Fuck you josh I hope your eyes bleed to death!!!!! :@
				grid.direction = Direction.WEST;

			}
		}
	
	

	
	
	}
}