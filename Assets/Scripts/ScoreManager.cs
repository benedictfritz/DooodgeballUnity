using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	public static int player1Score = 0;
	public static int player2Score = 0;
	
	public static void IncreaseScore(string player) {
		if (player.Equals("player1")) {
			player1Score++;
			Debug.Log("Player 1: " + player1Score);
		}
		else if (player.Equals("player2")) {
			player2Score++;
			Debug.Log("Player 2: " + player2Score);
		}
	}
}

