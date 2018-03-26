using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour {
	public static bool gameEnded { get; private set; }
	public GameObject endScreen;
	public static GameObject gameOver;

	public static void EndGame() {
		if (!gameEnded) {
			gameEnded = true;
			gameOver.SetActive(gameEnded);
		}
	}

	void Start() {
		gameEnded = false;
		gameOver = endScreen;
	}

	void Update() {
		if (gameEnded && Input.GetAxis("Jump") > 0)
			ResetGame();
		gameOver.SetActive(gameEnded);
	}

	void ResetGame() { 
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
