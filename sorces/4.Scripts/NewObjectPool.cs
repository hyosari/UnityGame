using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectPool : MonoBehaviour {

	public static NewObjectPool current; //Static 

	public List<GameObject> PoolobjList;
	public GameObject Play_Obj;


	public int PoolAmount = 10;

	public List<GameObject> PoolObjs;



	void Awake()
	{
		//static variable 
		current = this;
	}

	// Use this for initialization
	void Start () {
		PoolObjs = new List<GameObject> ();

		for(int i = 0; i < PoolAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(PoolobjList[Random.Range(0,PoolobjList.Count)]);
			obj.transform.parent = Play_Obj.transform; //paraent object initialize

			obj.SetActive(false);
			PoolObjs.Add(obj);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{		
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < PoolObjs.Count; i++)
		{
			if (!PoolObjs [i].activeInHierarchy) 
			{
				return PoolObjs[i];
			}
		}
		return null;
	}
}
