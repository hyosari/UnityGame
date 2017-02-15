using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RunningBar : MonoBehaviour {

	public Image fillImage;
	public float fulltime=2.0f;
	public float downtime = 10.0f;
	public Slider slid;
	public Button runButton;
	public Color ZeroColor = Color.green;
	public Color FullColor = Color.red;
	public GameObject character;

	private float maxFill = 1000.0f;
	private bool btnVis = false;



	void Awake()
	{
		slid.value = 0.0f;
		runButton.gameObject.SetActive (btnVis);
		StartCoroutine ("UpRunningBar");
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public IEnumerator UpRunningBar()
	{
		if (slid.value == maxFill) {
			btnVis = true;
			runButton.gameObject.SetActive (btnVis);
			StopCoroutine ("UpRunningBar");
			yield break;

		}
		else 
		{

			slid.value += fulltime;
			fillImage.color = Color.Lerp (ZeroColor, FullColor, slid.value / maxFill);
			yield return new WaitForSeconds (1.0f);
			StartCoroutine ("UpRunningBar");
		}
	}

	public void moveDown(float originSpeed)
	{

		StartCoroutine (DownRunningBar(originSpeed));
	}

	public IEnumerator DownRunningBar(float originSpeed)
	{
		if (slid.value == 0) {
			btnVis = true;
			character.GetComponent<CarAction> ().mvSpeed = originSpeed;
			StartCoroutine ("UpRunningBar");
			StopCoroutine (DownRunningBar(originSpeed));
			yield break;
		} else 
		{

			slid.value -= downtime;
			fillImage.color = Color.Lerp (ZeroColor, FullColor, slid.value / maxFill);
			yield return new WaitForSeconds (1.0f);
			StartCoroutine (DownRunningBar(originSpeed));
		}
			
	}
}
