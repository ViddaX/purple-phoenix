using System.Collections;
using UnityEngine;
namespace pp
{
	public class BuildingMenu : MonoBehaviour
	{
		public GUIStyle style;
		public GUISkin Skin;
		public Texture image;
		private bool selected;
		
		void OnGUI ()
		{
			Util.ScaleGUI ();
			GUI.skin = Skin;
			GameObject obj = GameObject.Find ("Plane");
			Grid grid = obj.GetComponent<Grid> ();
			
			
			GUI.TextArea (new Rect (20, 20, 100, 50), "Money: $" + grid.Money.ToString (), style);
			
			// GUI.DrawTexture (new Rect (70, 120, 100,100 ), aTexture, ScaleMode.ScaleToFit, true, 10.0f);
			
			GUI.Box (new Rect (30, 90, 150, 210), "Gadgets");
			GUI.SetNextControlName ("a");
			
			if (GUI.Button (new Rect (35, 120, 140, 30), "Conveyor")) {
				GUI.FocusControl ("a");
				grid.SetMode (Grid.MODE_MODIFY, BlockType.Conveyor);
				RecipeSelector.show = false;
				SplitterMenu.show = false;
				BuilderMenu.show = false;
			}
			
			GUI.SetNextControlName ("b");
			if (GUI.Button (new Rect (40, 150, 140, 30), "Grabber")) {
				GUI.FocusControl ("b");
				grid.SetMode (Grid.MODE_MODIFY, BlockType.Grabber);
				RecipeSelector.show = false;
				SplitterMenu.show = false;
				BuilderMenu.show = false;
			}
			
			
			GUI.SetNextControlName ("c");
			if (GUI.Button (new Rect (40, 180, 140, 30), "Combiner")) {
				GUI.FocusControl ("c");
				grid.SetMode (Grid.MODE_MODIFY, BlockType.Combiner);
				RecipeSelector.show = true;
				SplitterMenu.show = false;
				BuilderMenu.show = false;
			}
			
			GUI.SetNextControlName ("d");
			if (GUI.Button (new Rect (40, 210, 140, 30), "Splitter")) {
				GUI.FocusControl ("d");
				grid.SetMode (Grid.MODE_MODIFY, BlockType.Splitter);
				RecipeSelector.show = false;
				BuilderMenu.show = false;
				SplitterMenu.show = true;
			}
			
			GUI.SetNextControlName ("e");
			if (GUI.Button (new Rect (40, 240, 140, 30), "Destroy")) {
				GUI.FocusControl ("e");
				grid.SetMode (Grid.MODE_DELETE);
				RecipeSelector.show = false;
				SplitterMenu.show = false;
				BuilderMenu.show = false;
			}
			GUI.SetNextControlName ("f");
			if (GUI.Button (new Rect (40, 270, 140, 30), "Builder")) {
				GUI.FocusControl ("f");
				grid.SetMode (Grid.MODE_MODIFY, BlockType.Builder);
				RecipeSelector.show = false;
				SplitterMenu.show = false;
				BuilderMenu.show = true;
			}
		}
		
	}
}
