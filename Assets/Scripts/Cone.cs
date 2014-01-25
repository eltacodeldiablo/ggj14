using UnityEngine;
using System.Collections;

public class Cone : MonoBehaviour {
	public float playerFOV = 40.0f;
	public float viewDist = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//raycast view cone
		//green if not hitting
		this.transform.renderer.material.color = Color.green;

		for(int i = 0; i < playerFOV; i++) {//Raycast every 1 degree in FOV
			float theta = Mathf.Deg2Rad*(-1*playerFOV/2+i);//Direction of vector
            
			float cs = Mathf.Cos(theta);
			float sn = Mathf.Sin(theta);
            
			Vector3 fwdVec = this.transform.up;
            Vector2 rayDir = new Vector2(fwdVec.x * cs - fwdVec.y * sn, fwdVec.x * sn + fwdVec.y * cs);
			LayerMask mask = 1;
			RaycastHit2D hitObj = Physics2D.Raycast(this.transform.position, rayDir,viewDist);
			if(hitObj.transform != null ){
				//red if hitting an object
				this.transform.renderer.material.color = Color.red;
				//Send a message to the obj hit to do it's thing
				hitObj.transform.gameObject.SendMessage(this.tag+"Looking");
			}

			Debug.DrawLine(this.transform.position,this.transform.position + new Vector3(viewDist*rayDir.normalized.x, viewDist*rayDir.normalized.y, 0), Color.red);
		}

	}
   
}