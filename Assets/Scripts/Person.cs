using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	public float speed = 2.0f;
	public float actionRange = 1.2f;
	
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		//wasd movement
		//action button for this player
		checkAction();

		// Debug.Log(Input.GetAxis("L_XAxis_1") + " " + Time.deltaTime + " " + speed);
		float x = Input.GetAxis("L_XAxis_1") * Time.deltaTime * speed;
		float y = Input.GetAxis("L_YAxis_1") * Time.deltaTime * speed * -1;
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
		float rtx = Input.GetAxis("R_XAxis_1");
		float rty = -1*Input.GetAxis("R_YAxis_1");

		//change the angle
		float angle = Mathf.Atan2(rty, rtx) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 90));
	}

	void checkAction(){
		if (Input.GetKeyDown ("space")){//action
			//print("space pressed");

			Vector3 fwdVec = this.transform.up;
			RaycastHit2D hitObj = Physics2D.Raycast(this.transform.position, fwdVec, 2);
			if(hitObj.transform != null){
				hitObj.transform.gameObject.SendMessage("Activate");
			}

			Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(fwdVec.x*actionRange,fwdVec.y*actionRange,0), Color.blue, 20);

		}
	}
	//2d trigger
	void OnTriggerEnter2D(Collider2D c){
		if(c.collider.tag == "Lever"){
			print("touched lever");
		}
		//Debug.Log(c.tag);
	}

}
