using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficAction : MonoBehaviour {

	public float mvSpeed= 30.0f;
	public float linewidth=5.0f;
	public float linchSpeed= 1.0f;
	//reference component
	private Rigidbody rbody;
	private Transform tr;
	private float dvSpeed = 0.0f;

	void Awake()
	{
		rbody = this.GetComponent<Rigidbody> ();
		rbody.centerOfMass = new Vector3 (0.0f, -0.5f, 0.0f);
		tr = this.GetComponent<Transform> ();
		dvSpeed = Random.Range(mvSpeed*0.5f,mvSpeed);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		tr.Translate (Vector3.back * dvSpeed * Time.deltaTime);
		if (tr.localPosition.x > 50.0f || tr.localPosition.x < -50.0f) 
		{
			CarDestroy ();
		}
	
	}

	void CarDestroy()
	{
		StopAllCoroutines ();
		Destroy (this.gameObject);
	}
}
