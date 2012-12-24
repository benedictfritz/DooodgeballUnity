using UnityEngine;

public class PlayerOne : Player {
	
	public virtual void Update() {
		// these are false unless one of keys is pressed
		isLeft = false;
		isRight = false;
		isUp = false;
		isDown = false;
		
		movingDir = moving.None;
		
		// keyboard input
		if(Input.GetKey(KeyCode.A)) {
			isLeft = true;
			facingDir = facing.Left;
		}
		if (Input.GetKey(KeyCode.D) && isLeft == false) {
			isRight = true;
			facingDir = facing.Right;
		}
		
		if (Input.GetKey(KeyCode.W)) {
			isUp = true;
		}
		if(Input.GetKey(KeyCode.S) && isUp == false) {
			isDown = true;
		}
						
		UpdateMovement();
	}
	
}
