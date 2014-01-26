using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	public float speed = 2.0f;
	public float actionRange = 1.2f;
	public bool useController = true;
	public GameObject poisonPrefab;
	
	private float foodEaten = 0;
	private float poisonEaten = 0;
		
	private float previousAngle;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		checkAction();
		float angle, x, y, rtx, rty;
		angle = 0f;

		previousAngle = angle;
		if(!useController) {
			//wasd movement
		x = Input.GetAxis("HorizontalKeyboard") * Time.deltaTime * speed;
			y = Input.GetAxis("VerticalKeyboard") * Time.deltaTime * speed * -1;
			this.transform.Translate(x, y, 0, Space.World); //global axis
			rtx = Input.GetAxis("HorizontalKeyboard");
			rty = -1*Input.GetAxis("VerticalKeyboard");
			// Debug.Log(Input.GetAxis("L_XAxis_1") + " " + Time.deltaTime + " " + speed);
			Vector3 mouse_pos = Input.mousePosition;
	        Vector3 object_pos = Camera.main.WorldToScreenPoint(this.transform.position);
			mouse_pos.x = mouse_pos.x - object_pos.x;
			mouse_pos.y = mouse_pos.y - object_pos.y;
			mouse_pos.z = Camera.main.transform.position.z - this.transform.position.z;

			angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

		} else {
			x = Input.GetAxis("L_XAxis_" + this.tag.Substring(this.tag.Length-1,1)) * Time.deltaTime * speed;
			y = Input.GetAxis("L_YAxis_" + this.tag.Substring(this.tag.Length-1,1)) * Time.deltaTime * speed * -1;
			rtx = Input.GetAxis("R_XAxis_" + this.tag.Substring(this.tag.Length-1,1));
			rty = -1*Input.GetAxis("R_YAxis_" + this.tag.Substring(this.tag.Length-1,1));
			this.transform.Translate(x, y, 0, Space.World); //global axis

			//change the angle
			angle = Mathf.Atan2(rty, rtx) * Mathf.Rad2Deg;
		}
		if(rtx == 0 && rty == 0)
			GameObject.Find("P" + this.tag.Substring(this.tag.Length-1,1) + "Cone").GetComponent<MeshRenderer>().enabled = false;
		else{
			this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle - 90));
			GameObject.Find("P" + this.tag.Substring(this.tag.Length-1,1) + "Cone").GetComponent<MeshRenderer>().enabled = true;
		}
	}

	void checkAction(){
		if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick 1 button 0") || Input.GetKeyDown("joystick 2 button 0")) {//action
			//print("space pressed");
			Vector3 fwdVec = this.transform.up;
			RaycastHit2D hitObj = Physics2D.Raycast(this.transform.position, fwdVec, 2);
			if(hitObj.transform != null && hitObj.transform.gameObject.tag == "Lever"){
				hitObj.transform.gameObject.SendMessage("Activate");
				// Debug.DrawLine(this.transform.position, new Vector2(hitObj.point.x, hitObj.point.y), Color.blue, 20);
			}else{
				// Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(fwdVec.x*actionRange,fwdVec.y*actionRange,0), Color.blue, 20);
			}
		} else if (Input.GetKeyDown("joystick 1 button 2") || Input.GetKeyDown("joystick 2 button 2")) {
		    Debug.Log("button2");
		    createPoison();   
		}
	}
	
	void createPoison() {
	    float maxSize = 1.75f;
	    Debug.Log("foodeaten: " + foodEaten);
	    if (foodEaten > maxSize) {
	        GameObject newCandy = Instantiate(poisonPrefab, this.transform.position, Quaternion.Euler(Vector3.zero)) as GameObject;
		    float randDimension = Random.Range(1f,maxSize);
		    newCandy.transform.localScale = new Vector3(randDimension,randDimension,randDimension);
		    foodEaten -= randDimension;
	    }
	}
	//2d trigger
	void OnTriggerEnter2D(Collider2D c){
		if(c.collider.tag == "Lever"){
			print("touched lever");
		}
		//Debug.Log(c.tag);
	}

	void addToTail(float ogSize) {
	    foodEaten += ogSize; //# of blocks/size/dimensions?
		this.transform.GetComponentInChildren<ParticleSystem>().startLifetime += ogSize/10f;
	}
	
	void removeFromTail(float ogSize) {
	    poisonEaten += ogSize; //# of blocks/size/dimensions?
		this.transform.GetComponentInChildren<ParticleSystem>().startLifetime -= ogSize/10f;
	}

}
