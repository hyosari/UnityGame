using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcolor : MonoBehaviour {

	///public Texture[] textures;
	private int idx;
	private Color[] colors = new Color[6];


	// Use this for initialization
	void Start () {
		///<summary>
		/// Texture 로 바꾸기 
		/// </summary>
		//idx = Random.Range (0, textures.Length);
		//GetComponentsInChildren<MeshRenderer> () [0].materials[0].mainTexture = textures[idx];

		colors [0] = Color.cyan;
		colors [1] = Color.red;
		colors [2] = Color.green;
		colors [3] = Color.yellow;
		colors [4] = Color.magenta;
		colors [5] = Color.gray;

		idx = Random.Range (0, colors.Length);
		GetComponentsInChildren<MeshRenderer> () [0].materials [0].color = colors [idx];


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
