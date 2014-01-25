using UnityEngine;
using System.Collections;

public class Cone : MonoBehaviour {
	float playerFOV = 1.0f;//40.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(10,10,10), Color.red,10);
		for(int i = 0; i < playerFOV; i++) {//Raycast every 1 degree in FOV
			float theta = Mathf.Deg2Rad*(-1*playerFOV/2+i);//Direction of vector
            
			float cs = Mathf.Cos(theta);
			float sn = Mathf.Sin(theta);
            
			Vector3 fwdVec = this.transform.up;
            Vector2 rayDir = new Vector2(fwdVec.x * cs - fwdVec.y * sn, fwdVec.x * sn + fwdVec.y * cs);
			RaycastHit2D hitObj = Physics2D.Raycast(this.transform.position, rayDir);
			if(hitObj.transform != null ){
				Debug.Log("hit "+hitObj.transform.name);//"Obj hit @ " + Mathf.Rad2Deg*(theta) + "Degrees!");
			}
			
			Debug.DrawLine(this.transform.position, new Vector3(10*rayDir.x, 10*rayDir.y, 0), Color.red);
		}
	}
   

	// void OnTriggerEnter2D(Collider2D col) {
	// 	//Trigger Enter
	// 	Transform objTransform = col.gameObject.transform;
	// 	Vector3 playerPos = this.transform.position;
	// 	float objAngleAway = Vector3.Angle(this.transform.forward, playerPos - objTransform.position);
	// 	if(objAngleAway > playerFOV/2) Debug.Log("Colliding, not in cone");
	// 	else Debug.Log("IN CONE!!!");
	// }

}