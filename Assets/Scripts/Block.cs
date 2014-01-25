using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//fix the rotation
		this.transform.rotation = Quaternion.Euler(Vector3.zero);
	}
	
	void Player1Looking(){
	    this.transform.renderer.material.color = Color.blue;
	}
	void Player2Looking(){
	    this.transform.renderer.material.color = Color.yellow;
	}
}
