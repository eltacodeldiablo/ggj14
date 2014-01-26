using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button(new Rect(50,100,100,50),"Begin!"))
			Application.LoadLevel(0);
		if (GUI.Button(new Rect(200,100,100,50),"Credits"))
			Debug.Log("Show Credits");
	}
}
