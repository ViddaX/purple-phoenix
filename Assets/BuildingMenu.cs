using UnityEngine;
using System.Collections;
namespace pp{
	public class BuildingMenu : MonoBehaviour {
		
		void OnGUI () {
			GameObject obj = GameObject.Find ("Plane");
			Grid grid =	obj.GetComponent<Grid>();

			GUI.Box(new Rect(10,10,100,150), "Gadgets");

			if(GUI.Button(new Rect(20,40,80,20), "Conveyor")) {
				grid.spawnType = BlockType.CONVEYOR;
				Selectrecipe.BuildComb = false;
			}

			if(GUI.Button(new Rect(20,70,80,20), "Lifter")) {
				grid.spawnType = BlockType.GRABBER;
				Selectrecipe.BuildComb = false;
			}

			if(GUI.Button(new Rect(20,100,80,20), "Combiner")) {
				grid.spawnType = BlockType.COMBINER;
				Selectrecipe.BuildComb = true;
			}
		}
	}
}