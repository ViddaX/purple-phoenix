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

			GUI.Box(new Rect(30, 90, 150, 170), "Gadgets");

			if(GUI.Button(new Rect(35, 120, 140, 30), "Conveyor"/*,Menubuttonstyle*/)) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.Conveyor);
				RecipeSelector.show = false;
			}

			if(GUI.Button(new Rect(40,150,140,30), "Lifter")) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.Grabber);
				RecipeSelector.show = false;
			}

			if(GUI.Button(new Rect(40,180,140,30), "Combiner")) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.Combiner);
				RecipeSelector.show = true;
			}

			if(GUI.Button(new Rect(40,230,140,30), "Destroy")) {
				grid.SetMode (Grid.MODE_DELETE);
				RecipeSelector.show = false;
			}
		}
	}
}