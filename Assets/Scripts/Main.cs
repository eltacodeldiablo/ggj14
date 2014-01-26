using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public GameObject foodPrefab;
    public int numFood = 30;
	public float accelerationModifier = 0.001f;//A larger number means a faster acceleration
	public float beginMoveThreshold = 1.5f;
	public float endMoveThreshold = .1f;
    public float vel = 3f;
    public float zoomSpeed = 11f;
    private const int originalOrthographicSize = 5;
    private bool isScrolling = false;

	// Use this for initialization
	void Start () {
		populateWithFood();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 player1Dist = player1.transform.position - this.transform.position;
		Vector2 player2Dist = player2.transform.position - this.transform.position;

		float maxPlayerDist = Mathf.Max(player1Dist.magnitude,player2Dist.magnitude);

		if (maxPlayerDist > beginMoveThreshold) {
		    isScrolling = true;
		} else if(maxPlayerDist < endMoveThreshold){
		    isScrolling = false;
		}

		if(isScrolling){
		    cameraScroll();
			cameraResize();
		}
	}
	
	void cameraScroll(){
		Vector2 newCameraPos2d = Vector2.Lerp(
			this.transform.position,
			(player1.transform.position + player2.transform.position)/2,
			Time.deltaTime * vel);

		Vector3 newCameraPos = new Vector3(
			newCameraPos2d.x,
			newCameraPos2d.y,
			this.transform.position.z);
		this.transform.position = newCameraPos;
	}

	void cameraResize() {
		float diffInPlayerDist = (player1.transform.position - player2.transform.position).magnitude;

		if (diffInPlayerDist + 6 > camera.orthographicSize) {
			camera.orthographicSize = Mathf.Min(Mathf.Lerp(camera.orthographicSize, diffInPlayerDist + 4, Time.deltaTime * zoomSpeed),20);
		} else if (diffInPlayerDist > originalOrthographicSize && diffInPlayerDist < camera.orthographicSize - 6) {
			camera.orthographicSize = Mathf.Max(Mathf.Lerp(diffInPlayerDist - 2, camera.orthographicSize, Time.deltaTime * zoomSpeed),
				originalOrthographicSize);
		}
	}

	void populateWithFood() {
		for(int i = 0; i < numFood; i++){
		    Instantiate(foodPrefab, createRandomVector(), Quaternion.Euler(Vector3.zero));
		}
	}
	
	Vector2 createRandomVector(){
	    return new Vector2(Random.Range(-16,18),Random.Range(-30,5));
	}
}
