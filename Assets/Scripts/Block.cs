using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public bool isMoveable;//is this a moveable block
	public Color defaultColor = Color.white;
	bool isSeen = false;//is this current being seen

	int seenMax = 30;//how long it should stay visible until its back to normal
	int seenCounter = 0;//counter for being seen
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//fix the rotation
		if(isMoveable){
			this.transform.rotation = Quaternion.Euler(Vector3.zero);
		}

		if(seenCounter > 0){//if its no longer being seen, set back to normal
			seenCounter --;
			colorFadeOut();
		}else{
			
		}
	}

	void colorFadeOut(){
		this.transform.renderer.material.color = Color.Lerp(defaultColor, Color.blue, (float)seenCounter/seenMax);
	}
	void colorFadeIn(){
		this.transform.renderer.material.color = Color.Lerp(Color.blue, defaultColor, (float)seenCounter/seenMax);
	}
	
	//seing seen by player 1
	void Player1Looking(){
	    this.transform.renderer.material.color = Color.blue;
	    isSeen = true;
	    seenCounter = seenMax;
	}

	void Player2Looking(){
	    this.transform.renderer.material.color = Color.yellow;
	}
}
