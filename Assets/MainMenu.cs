using UnityEngine;
using System.Collections;
namespace pp2{
	public class MainMenu : MonoBehaviour {

		void OnGUI() {
			GUI.Box(new Rect(630,150,110,150), "Main Menu");
		

		if(GUI.Button(new Rect(640,175,80,20), "Start Game")){
				Application.LoadLevel(1);
		}


		if(GUI.Button(new Rect(640,200,80,20), "Level 2")) {
			Application.LoadLevel(2);
		}

		}
	}
}
