using UnityEngine;

public class PlayerTwo : Player {
	
	public virtual void Update() {
		// these are false unless one of keys is pressed
		isLeft = false;
		isRight = false;
		isUp = false;
		isDown = false;
		
		movingDir = moving.None;
		
		// keyboard input
		if(Input.GetKey(KeyCode.LeftArrow)) {
			isLeft = true;
			facingDir = facing.Left;
		}
		if (Input.GetKey(KeyCode.RightArrow) && isLeft == false) {
			isRight = true;
			facingDir = facing.Right;
		}
		
		if (Input.GetKey(KeyCode.UpArrow)) {
			isUp = true;
		}
		if(Input.GetKey(KeyCode.DownArrow) && isUp == false) {
			isDown = true;
		}
						
		UpdateMovement();
	}
	
	protected override void constrainToHalf() {
		if (thisTransform.position.x - halfWidth - absVel2X <= 0) {
			if(facingDir == facing.Left || movingDir == moving.Left) {
				blockedLeft = true;
				vel2.x = 0f;
				thisTransform.position = new Vector3(0 + halfWidth, thisTransform.position.y, 0f);
			}
		}
	}
	
}
