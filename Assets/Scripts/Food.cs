using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	private float originalSize;

	// Use this for initialization
	void Start () {
		originalSize = this.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Eaten(GameObject sender) {
		//TODO shrink
		if (this.transform.localScale.x > 0.06f) {
			this.transform.localScale -= new Vector3(.002f,.002f,.002f);
		} else {
			sender.SendMessage("addToTail", originalSize);
			//remove object
			Destroy(this.gameObject);
		}
		
	}
}
