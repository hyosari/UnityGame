using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

	public List<GameObject> StartPos;
	public float responTime = 0.1f;

	private Vector3 StartPos_Vec;
	//generate rotation
	private Quaternion north = Quaternion.Euler(new Vector3(0.0f,90.0f,0.0f));
	private Quaternion south = Quaternion.Euler(new Vector3(0.0f,270.0f,0.0f));

	// Use this for initialization
	void Start () {
		StartCoroutine ("cor_generate");

	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator cor_generate()
	{
		StartPos_Vec = StartPos [Random.Range (0, StartPos.Count)].transform.position;
		yield return new WaitForSeconds (responTime);
		GEN_CAR ();
		StartCoroutine ("cor_generate");
	}

	void GEN_CAR()
	{
		GameObject obj = NewObjectPool.current.GetPooledObject ();
		if (obj == null)
			return;
		obj.transform.position = StartPos_Vec;
		if (obj.transform.position.x > 0.0f) {
			obj.transform.rotation = north;
		} else 
		{
			obj.transform.rotation = south;
		}
		//print (obj.transform.position);
		obj.SetActive (true);
	}
}
