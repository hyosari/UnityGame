using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour {

	public GameObject car; 
	public float delay=5.0f;
	//public GameObject[] cars;

	//generate rotation
	private Quaternion north = Quaternion.Euler(new Vector3(0.0f,90.0f,0.0f));
	private Quaternion south = Quaternion.Euler(new Vector3(0.0f,270.0f,0.0f));

	/// <summary>
	///  Queue to store instances 
	/// </summary>
	private Queue idleQue = new Queue();

	void Awake()
	{

	}

	// Use this for initialization
	void Start () {
		StartCoroutine(CarCreate(delay));
		/*for (int i = 0; i < 5; i++) 
		{
			//idleQue.Enqueue (cars [Random.Range (0, cars.Length)]);
			idleQue.Enqueue(MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+ new Vector3 (50.0f, 0.5f, 5.0f), north).SetActive(false));
			idleQue.Enqueue(MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (-50.0f, 0.5f, 7.0f), south).SetActive(false));
		}*/

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator CarCreate(float delayTime)
	{

		MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+ new Vector3 (50.0f, 0.5f, 5.0f), north);
		yield return new WaitForSeconds (Random.Range(0.0f,delayTime));
		MonoBehaviour.Instantiate (car, this.GetComponentInParent<Transform>().position+new Vector3 (-50.0f, 0.5f, 7.0f), south);
		yield return new WaitForSeconds (Random.Range(0.0f,delayTime));
		StartCoroutine (CarCreate(delayTime));
	}

	public void CarActiveFalse(GameObject car, int position)
	{
			idleQue.Enqueue (car);

	}
}


