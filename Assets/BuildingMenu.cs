using UnityEngine;
using System.Collections;
namespace pp{
	public class BuildingMenu : MonoBehaviour {
		public GUIStyle style;
		public GUISkin Skin;
		void OnGUI () {
			GameObject obj = GameObject.Find ("Plane");
			Grid grid =	obj.GetComponent<Grid>();
			GUI.skin = Skin;
			GUI.Box(new Rect(10,10,110,150), "Gadgets");

			if(GUI.Button(new Rect(20,40,100,20), "Conveyor"/*,Menubuttonstyle*/)) {
				grid.spawnType = BlockType.CONVEYOR;
				Selectrecipe.BuildComb = false;
			}

			if(GUI.Button(new Rect(20,70,100,20), "Lifter")) {
				grid.spawnType = BlockType.GRABBER;
				Selectrecipe.BuildComb = false;
			}

			if(GUI.Button(new Rect(20,100,100,20), "Combiner")) {
				grid.spawnType = BlockType.COMBINER;
				Selectrecipe.BuildComb = true;
			}
		

			GUI.TextArea (new Rect (10, 185, 100, 50),""+grid.Money,style);
		//	GUI.DrawTexture (new Rect (70, 120, 100,100 ), aTexture, ScaleMode.ScaleToFit, true, 10.0f);
		}
	}
}