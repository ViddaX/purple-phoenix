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

			GUI.Box(new Rect(30, 90, 150, 210), "Gadgets");

			if(GUI.Button(new Rect(35, 120, 140, 30), "Conveyor"/*,Menubuttonstyle*/)) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.Conveyor);
				RecipeSelector.show = false;
			}

			if(GUI.Button(new Rect(40,150,140,30), "Grabber")) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.Grabber);
				RecipeSelector.show = false;
			}

			if(GUI.Button(new Rect(40,180,140,30), "Combiner")) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.Combiner);
				RecipeSelector.show = true;
			}

			if(GUI.Button(new Rect(40,210,140,30), "Splitter")) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.Splitter);
				RecipeSelector.show = false;
			}

			if(GUI.Button(new Rect(40,240,140,30), "Builder")) {
				grid.SetMode(Grid.MODE_MODIFY, BlockType.Builder);
				RecipeSelector.show = false;
			}

			if(GUI.Button(new Rect(40,270,140,30), "Destroy")) {
				grid.SetMode (Grid.MODE_DELETE);
				RecipeSelector.show = false;
			}
		}
	}
}