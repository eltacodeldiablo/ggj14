using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {
	bool isActivated = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//toggles activation of this object
	public void Activate(){
		isActivated = !isActivated;

		this.renderer.enabled = isActivated;
		this.rigidbody2D.active = isActivated;
	}
}
