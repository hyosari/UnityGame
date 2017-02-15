using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RunningButton : MonoBehaviour {

	public GameObject character;
	public Canvas canvas;

	public float chSpeed=10.0f;
	public float downSpeed=10.0f;


	private float orignSpeed;
	void Awake(){
		this.gameObject.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		orignSpeed = character.GetComponent<CarAction> ().mvSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void moveUp()
	{
		
		character.GetComponent<CarAction> ().mvSpeed += 10;
		canvas.GetComponent<RunningBar> ().moveDown (orignSpeed);
		this.gameObject.SetActive (false);
	}
		

}
