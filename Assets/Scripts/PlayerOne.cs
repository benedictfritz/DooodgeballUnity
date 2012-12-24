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
	
	protected override void constrainToHalf() {
		if (thisTransform.position.x + halfWidth + absVel2X >= 0) {
			if(facingDir == facing.Right || movingDir == moving.Right) {
				blockedRight = true;
				vel2.x = 0f;
				thisTransform.position = new Vector3(0 - halfWidth, thisTransform.position.y, 0f);
			}
		}
	}
	
}
