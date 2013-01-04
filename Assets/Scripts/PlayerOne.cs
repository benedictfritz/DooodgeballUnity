using UnityEngine;

public class PlayerOne : Player {
	
	void Start() {
		vertKeys = "VerticalWASD";
		horzKeys = "HorizontalWASD";
	}
	
	public override void Update() {
		base.Update();
		
		if (transform.position.x + halfWidth >= 0) {
			transform.position = new Vector3(-halfWidth, transform.position.y, transform.position.z);
			rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
		}
	}
	
}
