using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWideObjects : MonoBehaviour {

	public GameObject car;
	public int dir;  /// dir == 0 -> north , dir==1 -> south
	public float delay = 3.0f;

	public ArrayList cars= new ArrayList();


	/// <summary>
	/// The direction.  
	/// </summary>
	private Quaternion north = Quaternion.Euler(new Vector3(0.0f,90.0f,0.0f));
	private Quaternion south = Quaternion.Euler(new Vector3(0.0f,270.0f,0.0f));

	/// <summary>
	///  Queue to store instances 
	/// </summary>
	private Queue idleQue = new Queue();


	// Use this for initialization
	void Start () {











		StartCoroutine(WideCreate(delay,dir));
	}
	
	// Update is called once per frame
	void Update () {
		
	}




	IEnumerator WideCreate(float delay, int dir)
	{
		///<summary>
		/// dir == 0 -> north , dir==1 -> south
		/// </summary>
		if (dir == 0) {
			MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (50.0f, 0.5f, 13.5f), north);
			yield return new WaitForSeconds (Random.Range (0.0f, delay));
			MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (50.0f, 0.5f, 15.24f), north);
			yield return new WaitForSeconds (Random.Range (0.0f, delay));
			MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (50.0f, 0.5f, 17.06f), north);
			yield return new WaitForSeconds (Random.Range (0.0f, delay));
			MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (50.0f, 0.5f, 18.89f), north);
			StartCoroutine(WideCreate(delay,dir));
		} 
		else
		{
			MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (-50.0f, 0.5f, 13.5f), south);
			yield return new WaitForSeconds (Random.Range (0.0f, delay));
			MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (-50.0f, 0.5f, 15.24f), south);
			yield return new WaitForSeconds (Random.Range (0.0f, delay));
			MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (-50.0f, 0.5f, 17.06f), south);
			yield return new WaitForSeconds (Random.Range (0.0f, delay));
			MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (-50.0f, 0.5f, 18.89f), south);
			StartCoroutine(WideCreate(delay,dir));
		}

	}
}
