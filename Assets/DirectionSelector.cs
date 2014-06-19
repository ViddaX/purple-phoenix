using UnityEngine;
using System.Collections;
namespace pp{
	public class DirectionSelector : MonoBehaviour {
		public GUISkin Skin;
		void OnGUI () {
			Util.ScaleGUI();

			float top = 300;

			GameObject obj = GameObject.Find ("Plane");
			Grid grid =	obj.GetComponent<Grid>();
			GUI.skin = Skin;
			GUI.Box(new Rect(30, top,150,130), "Direction");

			if(GUI.Button(new Rect(80, top + 30,60,30), "Up")) {
				grid.direction = Direction.WEST;
				
			}

			if(GUI.Button(new Rect(35, top + 60,60,30), "Left")) {
				grid.direction = Direction.SOUTH;
			}

			if(GUI.Button(new Rect(120, top + 60,60,30), "Right")) {
				grid.direction = Direction.NORTH;
			}
			
			if(GUI.Button(new Rect(80, top + 90,60,30), "Down")) {
				grid.direction = Direction.EAST;
			}
		}
	
	

	
	
	}
}