using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;

	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (gameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}
	void Pause (){
		pauseMenuUI.SetActive (true);
		gameIsPaused = true;
		Time.timeScale = 0f;
		Cursor.lockState = CursorLockMode.Confined;
	}
	public void Resume (){
		pauseMenuUI.SetActive (false);
		gameIsPaused = false;
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.Locked;
	}
	public void LoadMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (0);
	}
	public void QuitGame (){
		Debug.Log("QUIT!");
		Application.Quit ();
	}
}
