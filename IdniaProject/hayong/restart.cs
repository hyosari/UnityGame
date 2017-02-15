using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	void Start()
	{
		Screen.orientation = ScreenOrientation.Portrait;
	}

	public void RestartButtonOnClick() {
		SceneManager.LoadScene("main");
	}
	public void ExitButtonOnClick()
	{
		Application.Quit ();
	}
}
