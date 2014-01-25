using UnityEngine;
using System.Collections;

public class Cone : MonoBehaviour {
	public float playerFOV = 40.0f;
	public float viewDist = 4f;
	public float degBtwnRays = 1f;
    public GameObject player;

	private Vector3[] newVertices;
    private Vector2[] newUV;
    private int[] newTriangles;

    void Start() {
        Mesh mesh = new Mesh();
        this.gameObject.AddComponent("MeshFilter");
        this.gameObject.AddComponent("MeshRenderer");
        GetComponent<MeshFilter>().mesh = mesh;
        
		newVertices = new Vector3[Mathf.FloorToInt((playerFOV/degBtwnRays)+1)];
        newUV = new Vector2[newVertices.Length];
        newTriangles = new int[(newVertices.Length-1)*3];

        // Debug.Log(newVertices.Length + " " + newUV.Length + " " + newTriangles.Length);

        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
    }
	
	// Update is called once per frame
	void Update () {
	    //RAYCAST VIEW CONE
		//green if not hitting
		player.transform.renderer.material.color = Color.green;
		
		//MESH INIT
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear();
        newVertices[0] = this.transform.position;
        // Debug.Log(newVertices.Length);
        newUV[0] = new Vector2(newVertices[0].x, newVertices[0].y);
        
		for(float i = 0f; i < playerFOV; i+=degBtwnRays) {//Raycast every 1 degree in FOV
			//RAYCAST INIT
			int intI = Mathf.FloorToInt(i);
			float theta = Mathf.Deg2Rad*(-1*playerFOV/2+i);//Direction of vector
			float cs = Mathf.Cos(theta);
			float sn = Mathf.Sin(theta);
            
			Vector3 fwdVec = this.transform.up;
            Vector2 rayDir = new Vector2(fwdVec.x * cs - fwdVec.y * sn, fwdVec.x * sn + fwdVec.y * cs);
            
			RaycastHit2D hitObj = Physics2D.Raycast(this.transform.position, rayDir,viewDist);

			if(hitObj.transform != null){
				//red if hitting an object
				player.transform.renderer.material.color = Color.red;
				//Send a message to the obj hit to do it's thing
				hitObj.transform.gameObject.SendMessage(player.transform.gameObject.tag+"Looking");
				
				//Add to new Mesh vert at point of contact
				newVertices[intI+1] = new Vector3(hitObj.point.x,hitObj.point.y,0);
				newUV[intI+1] = new Vector2(newVertices[intI+1].x, newVertices[intI+1].y);
			}
			else{
			    //Otherwise add vert at farthest view distance
			    newVertices[intI+1] = this.transform.position + new Vector3(
			        viewDist*rayDir.x,
					viewDist*rayDir.y,
					0);
				newUV[intI+1] = new Vector2(newVertices[intI+1].x, newVertices[intI+1].y);
			}
			//Add new triangle to mesh only if there are a least 2 verts
    		if(i > 0){
    			// Debug.Log(newTriangles.Length);
    			// Debug.Log(intI);
    			newTriangles[intI*3] = 0;
                newTriangles[intI*3+1] = (intI+1)-1;//Please keep the (i+1) for clarity's sake
                newTriangles[intI*3+2] = intI+1;
    		}
    		
			//draw red lines
			Debug.DrawLine(
				this.transform.position,
				this.transform.position + new Vector3(
					viewDist*rayDir.x,
					viewDist*rayDir.y,
					0),
				Color.red);
				
		this.transform.position = player.transform.position;
	    
		}
        //MODIFY MESH;
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
	}
   
}