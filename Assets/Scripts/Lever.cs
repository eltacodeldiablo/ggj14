using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {
	public GameObject affectedObject;//the action that this lever will affect
	bool isActivated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isActivated){
			this.transform.renderer.material.color = Color.green;
		}else{
			this.transform.renderer.material.color = Color.gray;
		}
	}
	//seing seen by player 1
	void Player1Looking(){
	    
	}
	//toggles activation of this object
	void Activate(){
		isActivated = !isActivated;
		print("lever activated: "+isActivated);
	}
}
