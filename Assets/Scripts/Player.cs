using UnityEngine;

public class Player : MonoBehaviour {
	
	[HideInInspector] public float speed = 10000f;
	[HideInInspector] public float halfWidth = 0.5f;
	
	[HideInInspector] protected string vertKeys;
	[HideInInspector] protected string horzKeys;
	
	[HideInInspector] protected Vector3 spawnTransform;
	
	public virtual void Start() {
		spawnTransform = transform.position;
	}
	
	public virtual void Update () {
		if (GameManager.animating || GameManager.gameOver) { return; }
		
		float vertInput = Input.GetAxisRaw(vertKeys);
		float horzInput = Input.GetAxisRaw(horzKeys);
		
		if (vertInput != 0) {
			rigidbody.AddRelativeForce(transform.up * Input.GetAxis (vertKeys) * speed * Time.deltaTime);
		}
		if (horzInput != 0) {
			rigidbody.AddRelativeForce(transform.right * Input.GetAxis (horzKeys) * speed * Time.deltaTime);
		}
	}
	
	public virtual void Die() {
	}
	
	public virtual void Respawn() {
		transform.position = spawnTransform;
		rigidbody.velocity = Vector3.zero;
	}
	
}