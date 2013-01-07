using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	public int gamesToWinSet;
	public int setsToWin;
	
	public static int player1GameScore = 0;
	public static int player2GameScore = 0;
	public OTTextSprite player1GameScoreText;
	public OTTextSprite player2GameScoreText;
	
	public static int player1SetScore = 0;
	public static int player2SetScore = 0;
	public OTTextSprite player1SetScoreText;
	public OTTextSprite player2SetScoreText;
	
	public OTAnimatingSprite loseAnnouncer;
	
	public void Start() {
		player1GameScore = 0;
		player1GameScoreText.text = player1GameScore.ToString();
		player2GameScore = 0;
		player2GameScoreText.text = player2GameScore.ToString();
		
		player1SetScore = 0;
		player1SetScoreText.text = player1SetScore.ToString();
		player2SetScore = 0;
		player2SetScoreText.text = player2SetScore.ToString();
	}
	
	public void IncreaseScore(string player) {
		if (player.Equals("player1")) {
			player1GameScore++;
			player1GameScoreText.text = player1GameScore.ToString();
		}
		else if (player.Equals("player2")) {
			player2GameScore++;
			player2GameScoreText.text = player2GameScore.ToString();
		}
		
		if (player1GameScore >= gamesToWinSet) {
			if (player1SetScore + 1 == setsToWin) {
				StartCoroutine(ShowGameOverLoser("player2"));
			}
			else {
				StartCoroutine(ShowGameLoser("player2"));
			}
		}
		else if (player2GameScore >= gamesToWinSet) {
			if (player2SetScore + 1 == setsToWin) {
				StartCoroutine(ShowGameOverLoser("player2"));
			}
			else {
				StartCoroutine(ShowGameLoser("player1"));
			}
		}
	}
	
	private IEnumerator ShowGameLoser(string player) {
		GameManager.animating = true;
		
		loseAnnouncer.renderer.enabled = true;
		
		if (player.Equals("player1")) { loseAnnouncer.Play("player1_drink"); }
		else if (player.Equals("player2")) { loseAnnouncer.Play("player2_drink"); }
		
		yield return new WaitForSeconds(3f);
		loseAnnouncer.renderer.enabled = false;
		
		GameManager.animating = false;
		
		GameManager.player1.Respawn();
		GameManager.player2.Respawn();
		foreach (Ball ball in GameManager.balls) { ball.Respawn(); }
		
		if (player2GameScore > player1GameScore) {
			player2SetScore++;
			player2SetScoreText.text = player2SetScore.ToString();	
		}
		else {
			player1SetScore++;
			player1SetScoreText.text = player1SetScore.ToString();
		}
		
		player1GameScore = 0;
		player1GameScoreText.text = player1GameScore.ToString();
		player2GameScore = 0;
		player2GameScoreText.text = player2GameScore.ToString();
	}
	
	private IEnumerator ShowGameOverLoser(string player) {
		GameManager.animating = true;
		
		loseAnnouncer.renderer.enabled = true;
		
		if (player.Equals("player1")) { loseAnnouncer.Play("player1_loses"); }
		else if (player.Equals("player2")) { loseAnnouncer.Play("player2_loses"); }
		
		if (player2GameScore > player1GameScore) {
			player2SetScore++;
			player2SetScoreText.text = player2SetScore.ToString();	
		}
		else {
			player1SetScore++;
			player1SetScoreText.text = player1SetScore.ToString();
		}
		player1GameScore = 0;
		player1GameScoreText.text = player1GameScore.ToString();
		player2GameScore = 0;
		player2GameScoreText.text = player2GameScore.ToString();
		
		yield return new WaitForSeconds(3f);
		
		GameManager.animating = false;		
		GameManager.gameOver = true;
	}
}

