using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	public float speed;
	
	// Use this for initialization
	void Start () {
	   speed = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		//wasd movement
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		this.transform.Translate(x, y, 0, Space.World); //global axis

		//look at mouse position
		Vector3 mouse_pos = Input.mousePosition;
		//The distance between the camera and object
		mouse_pos.z = Camera.main.transform.position.z - this.transform.position.z;
		Vector3 object_pos = Camera.main.WorldToScreenPoint(this.transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 90));
	}
}
