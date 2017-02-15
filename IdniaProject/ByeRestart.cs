using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ByeRestart : MonoBehaviour {

	void Start()
	{
		Screen.orientation = ScreenOrientation.Portrait;
	}

	public void Button() {
		SceneManager.LoadScene("Start_3");
	}
	public void ExitButton(){
		Application.Quit ();
	}
}
