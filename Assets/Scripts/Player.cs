using UnityEngine;

public class Player : MonoBehaviour {
	
	protected Transform thisTransform;
	
	[HideInInspector] public enum facing { Right, Left }
	[HideInInspector] public facing facingDir;
	
	[HideInInspector] public enum moving { Right, Left, None }
	[HideInInspector] public moving movingDir;
	
	[HideInInspector] public bool isLeft;
	[HideInInspector] public bool isRight;
	[HideInInspector] public bool isUp;
	[HideInInspector] public bool isDown;
	
	[HideInInspector] public bool blockedRight;
	[HideInInspector] public bool blockedLeft;
	[HideInInspector] public bool blockedUp;
	[HideInInspector] public bool blockedDown;
	
	private RaycastHit hitInfo;
	private float halfWidth = 0.6f;
	[HideInInspector] public float rayDistUp = 0.2f;
	protected int borderMask = 1 << 8;
	
	private float absVel2X;
	private float absVel2Y;
	
	private float moveVel = 10f;
	private Vector3 vel2;
	private Vector3 vel;
	
	public virtual void Awake() {
		thisTransform = transform;
	}
	
	public virtual void Start() {
		// do initialization stuff here
	}
	
	public virtual void UpdateMovement() {
		vel.x = 0;
		if(isRight) { vel.x = moveVel; }
		if(isLeft) { vel.x = -moveVel; }
		
		vel.y = 0;
		if(isUp) { vel.y = moveVel; }
		if(isDown) { vel.y = -moveVel; }
		
		// apply movement 
		vel2 = vel * Time.deltaTime;
		
		UpdateRaycasts();
		
		thisTransform.position += new Vector3(vel2.x,vel2.y,0f);
	}
	
	void UpdateRaycasts() {
		blockedRight = false;
		blockedLeft = false;
		blockedUp = false;
		blockedDown = false;
				
		absVel2X = Mathf.Abs(vel2.x);
		absVel2Y = Mathf.Abs(vel2.y);
		
		// blocked up
		if (Physics.Raycast(thisTransform.position, Vector3.up, out hitInfo, rayDistUp+absVel2Y, borderMask)) {
			// snap against border
			thisTransform.position = new Vector3(thisTransform.position.x, hitInfo.point.y - halfWidth, 0f);
			blockedUp = true;
			if (vel2.y > 0) { vel2.y = 0f; }
		}
		
		// blocked on right
		if (Physics.Raycast(thisTransform.position, Vector3.right, out hitInfo, halfWidth+absVel2X, borderMask)) {
			if(facingDir == facing.Right || movingDir == moving.Right) {
				blockedRight = true;
				vel2.x = 0f;
				thisTransform.position = new Vector3(hitInfo.point.x - halfWidth, hitInfo.point.y, 0f);
			}
		}
		// test crossing the midpoint border
		else if (thisTransform.position.x + halfWidth + absVel2X >= 0) {
			if(facingDir == facing.Right || movingDir == moving.Right) {
				blockedRight = true;
				vel2.x = 0f;
				thisTransform.position = new Vector3(0 - halfWidth, thisTransform.position.y, 0f);
			}
		}
		
		// blocked on left
		if(Physics.Raycast(thisTransform.position, -Vector3.right, out hitInfo, halfWidth+absVel2X, borderMask)) {
			if(facingDir == facing.Left || movingDir == moving.Left) {
				blockedLeft = true;
				vel2.x = 0f;
				thisTransform.position = new Vector3(hitInfo.point.x + halfWidth, hitInfo.point.y, 0f);
			}
		}
		
		// blocked down
		if (Physics.Raycast(thisTransform.position, Vector3.down, out hitInfo, rayDistUp+absVel2Y, borderMask)) {
			thisTransform.position = new Vector3(thisTransform.position.x, hitInfo.point.y + halfWidth, 0f);
			blockedDown = true;
			if (vel2.y < 0) { vel2.y = 0f; }
		}
	}
	
}