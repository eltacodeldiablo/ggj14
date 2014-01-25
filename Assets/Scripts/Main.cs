using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    public GameObject player;
	public float accelerationModifier = 0.001f;//A larger number means a faster acceleration
	public float beginMoveThreshold = 1.5f;
	public float endMoveThreshold = .1f;
    public float vel = 3f;


    private bool isScrolling = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 playerDist = player.transform.position - this.transform.position;
		if (playerDist.magnitude > beginMoveThreshold) {
		    isScrolling = true;
		} else if(playerDist.magnitude < endMoveThreshold){
		    isScrolling = false;
		}

		if(isScrolling){
		    cameraScroll(playerDist);
		}
	}
	
	void cameraScroll(Vector2 playerDist){
		Vector2 newCameraPos2d = Vector2.Lerp(
			this.transform.position,
			player.transform.position,
			Time.deltaTime * vel);
		Vector3 newCameraPos = new Vector3(
			newCameraPos2d.x,
			newCameraPos2d.y,
			this.transform.position.z);
		this.transform.position = newCameraPos;
	}
}
