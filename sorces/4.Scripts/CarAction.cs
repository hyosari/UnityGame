using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarAction : MonoBehaviour {

	//Speed variable 
	public float mvSpeed = 50.0f;
	public float upSpeed = 50.0f;



	//reference Component
	private Rigidbody rbody;
	private Transform tr;
	private Animator ani;
	private AudioSource audioDie;


	//keyboard Input 
	private float fb,ud;

	//main camera Pivot gameObject
	public Transform camPivot;


	//location initialization 
	private Vector3 currPos = Vector3.zero;
	private Quaternion currRot = Quaternion.identity;


	void Awake()
	{
		rbody = GetComponent<Rigidbody> ();
		tr = GetComponent<Transform> ();
		rbody.centerOfMass = new Vector3 (0.0f, 2.0f, 0.0f);

		audioDie = GetComponent<AudioSource> ();

		ani = GetComponent<Animator> ();


		Camera.main.GetComponent<SmoothFollow> ().target = camPivot;

		currPos = tr.position;
		currRot = tr.rotation;
		ani.SetTrigger ("idle");

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		fb = Input.GetAxis ("Horizontal");
		ud = Input.GetAxis ("Vertical");

		tr.Translate (Vector3.right * upSpeed * fb * Time.deltaTime);
		tr.Translate (Vector3.forward * mvSpeed * ud * Time.deltaTime);

		if (ud >= 0.1f || ud <= -0.1f) {
			ani.ResetTrigger ("idle");
			//ani.ResetTrigger ("side");
			ani.SetTrigger ("walk");
		} else if (fb >= 0.1f || fb <= -0.1f) {
			ani.ResetTrigger ("idle");
			ani.SetTrigger ("walk");
			//ani.SetTrigger ("side");
		} else 
		{
			ani.ResetTrigger ("walk");
			//ani.ResetTrigger ("side");
			ani.SetTrigger ("idle");
		}



	}
	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == "car") 
		{
			ani.ResetTrigger ("walk");
			ani.ResetTrigger ("idle");
			//ani.ResetTrigger ("side");
			ani.SetTrigger ("die");
			audioDie.Play ();
			Invoke ("LoadNextSense", 2.0f);
		}
			

	}

	void LoadNextSense()
	{
		SceneManager.LoadScene("die");
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Goal_Box")) 
		{
			SceneManager.LoadScene("last");
		}
		if (col.CompareTag ("End_Box")) 
		{
			SceneManager.LoadScene("die");
		}
	}

		
}
