using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {

	public float mvSpeed= 30.0f;


	//reference component
	private Rigidbody rbody;
	private Transform tr;
	private float dvSpeed = 0.0f;
	private Vector3 startPosition;

	void Awake()
	{
		rbody = this.GetComponent<Rigidbody> ();
		rbody.centerOfMass = new Vector3 (0.0f, -0.5f, 0.0f);
		tr = this.GetComponent<Transform> ();

	}

	// Use this for initialization
	void Start () {
		dvSpeed = Random.Range(mvSpeed*0.8f,mvSpeed);
		startPosition = tr.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
			
		tr.Translate (Vector3.back * dvSpeed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("End_Box")) 
		{
			gameObject.SetActive (false);
		}
	}

}
