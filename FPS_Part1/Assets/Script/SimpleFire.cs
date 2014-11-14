using UnityEngine;
using System.Collections;

public class SimpleFire : MonoBehaviour {
	public GameObject sys;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			Fire();
		}
	}
	void Fire()
	{
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit info;
		if (Physics.Raycast (ray, out info)) {
			GameObject obj = info.collider.gameObject;
			Rigidbody ro = obj.rigidbody;
			if(ro != null){
				obj.rigidbody.AddForceAtPosition(ray.direction*100.0f,info.point);                      
			}
			GameObject explode = (GameObject)Instantiate(sys,info.point,Quaternion.LookRotation(info.normal));
			Destroy(explode,1.0f);
			HitScript scpt = obj.GetComponent<HitScript>();
			if(scpt != null){
				scpt.onHit();
			}
		}
	}
}
