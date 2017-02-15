using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public Image Stick; // stick Image
	public GameObject character;
	public Animator ani;

	private Vector3 orignPos = Vector3.zero; // origin position of stick
	private float StickRadius =0.0f;


	void Awake()
	{
		
	}
	// Use this for initialization
	void Start () {
		orignPos = Stick.transform.position;

		StickRadius = Stick.rectTransform.sizeDelta.x;


	}
	// Drag
	public void OnDrag()
	{
		if (Stick == null)
			return;
		
		//Touch touch = Input.GetTouch (0);
//		if(Stick != null)
//		{
//			//터치한 위치로 조이스틱 움직임 
//			Stick.rectTransform.position = touch.position;
//		}
		Vector3 mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);

		//터치한 곳과, 조이스틱 처음 위치를 기준으로, 이동한 방향을 구해둔다. 
		//캐릭터 이동에 사용한다. 
		Vector3 dir = (mousePos - orignPos).normalized;
		Vector3 mv_dir =  new Vector3 (dir.x, 0.0f, dir.y);

		//Vector3 dir = (orignPos - new Vector3(touch.position.x,touch.position.y,orignPos.z)).normalized;
		//Vector3 mv_dir = new Vector3 (dir.x, 0.0f, dir.y);
		//터치한 부분이 조이스틱의 원래 위치 기준으로 얼마나 움직였나 체크한다. 
		//차후, 조이스틱 영역을 벗어나면 , 못 벗어나게 처리등에 사용할 수 있다. 
		float touchAreaRadius = Vector3.Distance(orignPos,mousePos);

		//float touchAreaRadius = Vector3.Distance(orignPos, new Vector3(touch.position.x,touch.position.y,orignPos.z));
		//Debug.Log("touchAreaRadius : "+touchAreaRadius);

		if (touchAreaRadius > StickRadius) {
			// 반경 넘어 간 경 우 
			Stick.rectTransform.position = orignPos + (dir * StickRadius);
		} else 
		{
			//Stick.rectTransform.position = touch.position;
			Stick.rectTransform.position = mousePos;
		}

		character.transform.Translate (mv_dir * 2.0f*character.GetComponent<CarAction> ().mvSpeed * Time.deltaTime);

		ani.ResetTrigger ("idle");
		ani.SetTrigger ("walk");
		



	}

	public void OnEndDrag()
	{
		//드래그가 끝나면, 터치가 끝난 것임으로, 조이스틱을 원 위치로 이동 시킨다.
		if(Stick != null)
		{
			Stick.rectTransform.position = orignPos;
			ani.ResetTrigger ("walk");
			ani.SetTrigger ("idle");
		}
	}


	// Update is called once per frame
	void Update () {
		//print (Stick.rectTransform.position);
	}
}
