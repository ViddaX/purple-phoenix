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
			if(goodButton(new Rect(810,130,80,20), "WEST1")) {
				grid.direction = Direction.WEST;

			}
		}
	
	
		bool goodButton(Rect bounds, string caption) {
			GUIStyle btnStyle = GUI.skin.FindStyle("button");
			int controlID = GUIUtility.GetControlID(bounds.GetHashCode(), FocusType.Passive);
			
			bool isMouseOver = bounds.Contains(Event.current.mousePosition);
			bool isDown = GUIUtility.hotControl == controlID;
			
			if (GUIUtility.hotControl != 0 && !isDown) {
				// ignore mouse while some other control has it
				// (this is the key bit that GUI.Button appears to be missing)
				isMouseOver = false;
			}
			
			if (Event.current.type == EventType.Repaint) {
				btnStyle.Draw(bounds, new GUIContent(caption), isMouseOver, isDown, false, false);
			}
			switch (Event.current.GetTypeForControl(controlID)) {
			case EventType.mouseDown:
				if (isMouseOver) {  // (note: isMouseOver will be false when another control is hot)
					GUIUtility.hotControl = controlID;
				}
				break;
				
			case EventType.mouseUp:
				if (GUIUtility.hotControl == controlID) GUIUtility.hotControl = 0;
				if (isMouseOver == bounds.Contains(Event.current.mousePosition)) return true;
				break;
			}
			
			return false;
		}
	
	
	}
}