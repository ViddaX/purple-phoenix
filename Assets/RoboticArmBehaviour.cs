using UnityEngine;
using System.Collections;
namespace pp{
	public class RoboticArmBehaviour : MonoBehaviour {
			private GameObject Liftobject;
			private Item  LiftItem;
			private float RotationSpeed =10 ;
			private Transform Target;
			private Quaternion LookRot;
			private Vector3 _direction;
			public RoboticArm p { get; set;}
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			if (p.from.items.Count == 0) {
				return;
			} else if (LiftItem == null) {

				LiftItem = p.items[0];
				p.from.OnExit(LiftItem);
				Liftobject = LiftItem.gameObject;
				Liftobject.transform.position = p.gameObject.transform.position;
				_direction = (p.to.worldPosition - p.gameObject.transform.position).normalized;
				LookRot=Quaternion.LookRotation(_direction);

				p.gameObject.transform.rotation = Quaternion.Slerp(p.gameObject.transform.rotation, LookRot, Time.deltaTime * RotationSpeed);
				p.to.OnEnter(LiftItem);
			}
		}
	}
}