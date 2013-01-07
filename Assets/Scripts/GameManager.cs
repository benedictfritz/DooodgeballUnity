using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static ScoreManager scoreManager;
	public static Player player1;
	public static Player player2;
	public static ArrayList balls;
	
	public static bool animating = false;
	
	void Start() {
		scoreManager = gameObject.GetComponent<ScoreManager>();
		player1 = GameObject.Find("player1").GetComponent<PlayerOne>();
		player2 = GameObject.Find("player2").GetComponent<PlayerTwo>();
		
		balls = new ArrayList();
		balls.Add(GameObject.Find("ball1").GetComponent<Ball>());
		balls.Add(GameObject.Find("ball2").GetComponent<Ball>());
		balls.Add(GameObject.Find("ball3").GetComponent<Ball>());
		balls.Add(GameObject.Find("ball4").GetComponent<Ball>());
		balls.Add(GameObject.Find("ball5").GetComponent<Ball>());
	}
}