using UnityEngine;

public class Ball : MonoBehaviour {
	
	public OTAnimatingSprite ballSprite;
	
	[HideInInspector] private bool deadly;
	
	public virtual void Update () {
		updateDeadliness();
		updateSprite();
	}
	
	private void updateDeadliness() {
		float speed = (Mathf.Abs(rigidbody.velocity.x) + Mathf.Abs(rigidbody.velocity.y));
		deadly = (speed > 10);
	}
	
	private void updateSprite() {
		if (deadly) { ballSprite.Play("deadly"); }
		else { ballSprite.Play("safe"); }
	}
	
}