using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public void Update() {
		if (Input.GetButtonDown("player_one_grab") 
			|| Input.GetButtonDown("player_two_grab")) {
			Application.LoadLevel("Game");
		}
	}
	
}

