﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    

    public void PlayGame() {
		Debug.Log ("Start is done");
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
	}
	public void QuitGame() {
		Debug.Log ("Quit is done");
		Application.Quit();
	}
}
