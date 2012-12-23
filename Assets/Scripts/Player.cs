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
	
	private float moveVel = 10f;
	private Vector3 vel2;
	private Vector3 vel;
	
	public virtual void Awake() {
		thisTransform = transform;
	}
	
	public virtual void Start() {
		// do initialization stuff here
	}
	
	// the update loop will be pulled into subclasses
	// that will then call the superclass' UpdateMovement()
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
	
	public virtual void UpdateMovement() {
		vel.x = 0;
		if(isRight) { vel.x = moveVel; }
		if(isLeft) { vel.x = -moveVel; }
		
		vel.y = 0;
		if(isUp) { vel.y = moveVel; }
		if(isDown) { vel.y = -moveVel; }
		
		UpdateRaycasts();
		
		// apply movement 
		vel2 = vel * Time.deltaTime;
		thisTransform.position += new Vector3(vel2.x,vel2.y,0f);
	}
	
	void UpdateRaycasts() {
		// need to implement this for collisions
	}
	
}