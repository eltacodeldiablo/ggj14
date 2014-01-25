using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	public float speed = 2.0f;
	
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		//wasd movement
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		this.transform.Translate(x, y, 0, Space.World); //global axis

		//look at mouse position
		//The distance between the camera and object
		// Vector3 mouse_pos = Input.mousePosition;
        // Vector3 object_pos = Camera.main.WorldToScreenPoint(this.transform.position);
		// mouse_pos.x = mouse_pos.x - object_pos.x;
		// mouse_pos.y = mouse_pos.y - object_pos.y;
		// mouse_pos.z = Camera.main.transform.position.z - this.transform.position.z;
		// float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

		//controller inputs
		float rtx = Input.GetAxis("RightH");
		float rty = -1*Input.GetAxis("RightV");

		//change the angle
		float angle = Mathf.Atan2(rty, rtx) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 90));
	}
}
