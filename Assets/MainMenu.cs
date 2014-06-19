using UnityEngine;
using System.Collections;
namespace pp2{
	public class MainMenu : MonoBehaviour {
		public GUIStyle style;
		public GUISkin Skin;
		void OnGUI() {
			GUI.skin = Skin;

			GUI.Box(new Rect(630,150,110,100), "Main Menu");
		

			if(GUI.Button(new Rect(640,175,80,20), "Start Game")){
				Application.LoadLevel(1);
			}


			if(GUI.Button(new Rect(640,200,80,20), "Quit Game")) {
				Application.Quit ();
			}

		}
	}
}
