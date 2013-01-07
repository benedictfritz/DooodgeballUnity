using UnityEngine;
using System.Collections;

public class BallHolder : MonoBehaviour {
	
	public Transform ballHolderObject;
	public string grabKey;
	public Player player;
	[HideInInspector] public float throwSpeed = 10000000;
	[HideInInspector] public bool holdingSomething;
	[HideInInspector] public Transform holdingObject;
	
	[HideInInspector] private bool throwing = false;
	[HideInInspector] private int throwCount = 4;
	[HideInInspector] private int throwCounter = 0;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton(grabKey) && holdingSomething) {
			holdingObject.position = ballHolderObject.position;
			holdingObject.rigidbody.velocity = Vector3.zero;
		}
		else if (Input.GetButtonUp(grabKey) && holdingSomething) {
			throwing = true;
			holdingSomething = false;
		}
		else {
			holdingSomething = false;
		}
	}
	
	void FixedUpdate() {
		if (throwing) {
			if (player.name.Equals("player1")) {
				holdingObject.rigidbody.AddRelativeForce(transform.right * throwSpeed);
			}
			else if (player.name.Equals("player2")) {
				holdingObject.rigidbody.AddRelativeForce(transform.right * -1 * throwSpeed);
			}
			
			throwCounter++;
			if (throwCounter > throwCount) {
				throwCounter = 0;
				holdingObject = null;
				throwing = false;
			}
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
