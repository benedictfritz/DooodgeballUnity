using UnityEngine;
using System.Collections;

public class BallHolder : MonoBehaviour {
	
	public Transform ballHolderObject;
	public string grabKey;
	[HideInInspector] public bool holdingSomething;
	[HideInInspector] public Transform holdingObject;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton(grabKey)) {
			if (holdingSomething) {
				holdingObject.position = ballHolderObject.position;
				holdingObject.rigidbody.velocity = Vector3.zero;
			}
		}
		else {
			holdingSomething = false;
			holdingObject = null;
		}
	}
	
	void OnCollisionEnter(Collision thing) {
		if (thing.collider.transform.tag == "ball"
			&& Input.GetButton(grabKey)) {
			holdingSomething = true;
			holdingObject = thing.collider.transform;	
		}
	}
	
}
