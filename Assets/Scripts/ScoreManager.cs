using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	public static int player1Score = 0;
	public static int player2Score = 0;
	
	public OTTextSprite player1ScoreText;
	public OTTextSprite player2ScoreText;
	
	public void Update() {
		player1ScoreText.text = player1Score.ToString();
		player2ScoreText.text = player2Score.ToString();
	}
	
	public static void IncreaseScore(string player) {
		if (player.Equals("player1")) { player1Score++; }
		else if (player.Equals("player2")) { player2Score++; }
	}
}

