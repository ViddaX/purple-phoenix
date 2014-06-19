using UnityEngine;
using System.Collections;
namespace pp{
	public class BuildingMenu : MonoBehaviour {
		public GUIStyle style;
		public GUISkin Skin;
		void OnGUI () {
			Util.ScaleGUI();

			GameObject obj = GameObject.Find ("Plane");
			Grid grid =	obj.GetComponent<Grid>();
			GUI.skin = Skin;

			GUI.TextArea (new Rect (20, 20, 100, 50), "Money: $" + grid.Money.ToString(), style);
			//	GUI.DrawTexture (new Rect (70, 120, 100,100 ), aTexture, ScaleMode.ScaleToFit, true, 10.0f);

			GUI.Box(new Rect(30, 90, 170, 170), "Gadgets");

			if(GUI.Button(new Rect(35, 120, 160, 30), "Conveyor"/*,Menubuttonstyle*/)) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.CONVEYOR);
				Selectrecipe.BuildComb = false;
			}

			if(GUI.Button(new Rect(40,150,160,30), "Lifter")) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.GRABBER);
				Selectrecipe.BuildComb = false;
			}

			if(GUI.Button(new Rect(40,180,160,30), "Combiner")) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.COMBINER);
				Selectrecipe.BuildComb = true;
			}

			if(GUI.Button(new Rect(40,230,160,30), "Destroy")) {
				grid.SetMode (Grid.MODE_DELETE);
				Selectrecipe.BuildComb = false;
			}
		}
	}
}