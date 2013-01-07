using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public OTAnimatingSprite ballSprite;
	
	[HideInInspector] private bool deadly;
	[HideInInspector] protected Vector3 spawnTransform;
	
	public virtual void Start() {
		spawnTransform = transform.position;
	}
	
	/*
	 * Update
	 */
	
	public virtual void Update () {
		UpdateDeadliness();
		UpdateSprite();
	}
	
	private void UpdateDeadliness() {
		float speed = (Mathf.Abs(rigidbody.velocity.x) + Mathf.Abs(rigidbody.velocity.y));
		deadly = (speed > 10);
	}
	
	private void UpdateSprite() {
		if (deadly) { ballSprite.Play("deadly"); }
		else { ballSprite.Play("safe"); }
	}
	
	
	/*
	 * Collision
	 */
	
	void OnCollisionEnter(Collision thing) {
		bool hitPlayer = thing.collider.transform.tag == "player";
		if (hitPlayer && deadly) {
			Player player = (Player) thing.gameObject.GetComponent("Player");
			player.Die();
			player.Respawn();
		}
	}
	
	/*
	 * Respawn
	 */
	
	public virtual void Respawn() {
		transform.position = spawnTransform;
		rigidbody.velocity = Vector3.zero;
	}
	
}