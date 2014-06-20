using System.Collections;
using UnityEngine;
namespace pp
{
	public class BuildingMenu : MonoBehaviour
	{
		public GUIStyle style;
		public GUISkin Skin;
		public Texture image;
		public static bool inGame;
		private bool selected;
	 	public GameObject _menuCamera = null;
		public GameObject _mainCamera = null;

		//private Vector3 to = new Vector3(-194.7f,194.9f,-121.6f);
		
		void OnGUI ()
		{
			GameObject _menuCamera = GameObject.Find("Menu Camera");
			GameObject _mainCamera = GameObject.Find("Main Camera");
			Util.ScaleGUI ();
			GUI.skin = Skin;
			GameObject obj = GameObject.Find ("Plane");
			Grid grid = obj.GetComponent<Grid> ();
			
			if (inGame == false) {
								GUI.Box (new Rect (700, 260, 350, 520), "Main Menu");
		
								if (GUI.Button (new Rect (820, 370, 120, 50), "Start Game")) {
										_menuCamera.camera.enabled = false;
										_mainCamera.camera.enabled = true;
								//		_menuCamera.transform.position = Vector3.Lerp(_menuCamera.transform.position, to, 10*Time.deltaTime);
										inGame = true;
								}
			
			
								if (GUI.Button (new Rect (820, 410, 120, 50), "Quit Game")) {
										Application.Quit ();
								}

			} else {
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
}