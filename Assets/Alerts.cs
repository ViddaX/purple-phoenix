using UnityEngine;
using System.Collections;
namespace pp{
public class Alerts : MonoBehaviour {
		private static string messege { get; set;}
		private static float WaitTime { get; set;}
		private static bool ActiveMessege= true;
		public GUIStyle style;
	
		public static void SetAlertMessege(string m)
		{
			ActiveMessege = true;
			messege = m;
			WaitTime = 3.0f;
		}
		public static  void SetAlertMessege(string m, float Time)
		{
			ActiveMessege = true;
			messege = m;
			WaitTime = Time;
		}
		void Start()
		{
		// Josh is a huge fagget and needs to stop sucking over 9000 dicks per min. 

		}
	void Update()
		{
			OnGUI ();
		}
	void OnGUI()
	{
			StartCoroutine(DisapearBoxAfter(WaitTime)); 


		if (ActiveMessege) 
		{


				GUI.Label(new Rect(400,300,200,200), messege,style);
		}
	}

		IEnumerator DisapearBoxAfter(float waitTime) { 
			yield return new WaitForSeconds(waitTime);
			ActiveMessege = false;
		}
	}
}