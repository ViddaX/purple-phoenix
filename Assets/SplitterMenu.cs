using UnityEngine;
using System.Collections;
namespace pp {
public class SplitterMenu : MonoBehaviour {

	public static bool show;
	public GUISkin Skin;
	
	
	void OnGUI ()
	{
		GameObject obj = GameObject.Find ("Plane");
		Grid grid = obj.GetComponent<Grid> ();
		GUI.skin = Skin;
		if (show == true) {
			GUI.Box (new Rect (200, 70, 175, 300), "Select Sensor Type");
			
			
				if (GUI.Button (new Rect (220, 100, 120, 30), new GUIContent("Transparent", "Transparent"))) {
					grid.ItemProperty = ItemProperty.Transparent;
			}
				if (GUI.Button (new Rect (220, 130, 110, 30), new GUIContent("Metal", "Metal"))) {
					grid.ItemProperty = ItemProperty.Metal;
			}
				if (GUI.Button (new Rect (220, 160, 110, 30), new GUIContent("Heavy", "Heavy"))) {
					grid.ItemProperty = ItemProperty.Heavy;
			}
				if (GUI.Button (new Rect (220, 190, 110, 30), new GUIContent("Light", "Light"))) {
					grid.ItemProperty = ItemProperty.Light;
			}
				if (GUI.Button (new Rect (220, 220, 110, 30), new GUIContent("Small", "Small"))) {
					grid.ItemProperty = ItemProperty.Small;
			}
				if (GUI.Button (new Rect (220, 250, 110, 30), new GUIContent("Thin", "Thin"))) {
					grid.ItemProperty = ItemProperty.Thin;
			}
				if (GUI.Button (new Rect (220, 280, 110, 30), new GUIContent("Thick", "Thick"))) {
					grid.ItemProperty = ItemProperty.Thick;
			}
				if (GUI.Button (new Rect (220, 310, 110, 30), new GUIContent("Irregular", "IrregularShape"))) {
					grid.ItemProperty = ItemProperty.IrregularShape;
			}
				if (GUI.Button (new Rect (220, 340, 110, 30), new GUIContent("Circular", "Circular"))) {
					grid.ItemProperty = ItemProperty.Circular;
			}
			
		}
		
		
}
	}
}