using UnityEngine;
using System.Collections.Generic;

namespace pp {
	public class Alerts : MonoBehaviour {
		public static float DEFAULT_DURATION = 2.0f;
		private static Queue<AlertMessage> messages = new Queue<AlertMessage>();
		private static AlertMessage cur;
		private static float messageEnd;

		public static void ShowMessage(AlertMessage message) {
			if (!message.repeatable && messages.Contains(message))
				return;

			messages.Enqueue(message);
		}

		public static void ShowMessage(string message, float duration, bool repeatable) {
			ShowMessage(new AlertMessage(message, duration, repeatable));
		}

		public static void ShowMessage(string message) {
			ShowMessage(message, DEFAULT_DURATION, false);
		}

		public void OnGUI() {
			if (cur == null) {
				if (messages.Count > 0) {
					cur = messages.Dequeue();
					messageEnd = Time.time + cur.duration;
				}
			} else {
				float w = 300;
				float h = 150;
				GUI.Label(new Rect((Screen.width / 2) - (w / 2), (Screen.height / 2) - (h / 2), w, h), cur.message);

				if (Time.time > messageEnd)
					cur = null;
			}
		}
	}

	public class AlertMessage {
		public string message;
		public float duration;
		public bool repeatable;

		public AlertMessage(string message, float duration, bool repeatable) {
			this.message = message;
			this.duration = duration;
			this.repeatable = repeatable;
		}

		public override bool Equals (object obj)
		{
			if (!(obj is AlertMessage)) return false;
			return this.message == ((AlertMessage) obj).message;
		}

		public override int GetHashCode ()
		{
			return this.message.GetHashCode();
		}
	}
}