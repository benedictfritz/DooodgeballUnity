using UnityEngine;

public class Player : MonoBehaviour {
	
	[HideInInspector] public float speed = 5000;
	
	[HideInInspector] protected string vertKeys;
	[HideInInspector] protected string horzKeys;
	
	void Update () {
		float vertInput = Input.GetAxisRaw(vertKeys);
		float horzInput = Input.GetAxisRaw(horzKeys);
		
		if (vertInput != 0) {
			rigidbody.AddRelativeForce(transform.up * Input.GetAxis (vertKeys) * speed * Time.deltaTime);
		}
		if (horzInput != 0) {
			rigidbody.AddRelativeForce(transform.right * Input.GetAxis (horzKeys) * speed * Time.deltaTime);
		}
	}
	
}