using UnityEngine;
using System.Collections;

public class Poison : MonoBehaviour {
	
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
		if (this.transform.localScale.x > 0.1f) {
			this.transform.localScale -= new Vector3(.002f,.002f,.002f);
		} else {
			sender.SendMessage("removeFromTail", originalSize);
			//remove object
// 			this.transform.localScale = new Vector3(originalSize,originalSize,originalSize);
// 			this.transform.position = new Vector3(Random.Range(-20,20),Random.Range(-20,20));
			Destroy(this.gameObject);
		}
		
	}
}
