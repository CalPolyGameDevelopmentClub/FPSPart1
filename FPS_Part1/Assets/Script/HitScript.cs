using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {
	Color normColor;
	// Use this for initialization
	void Start () {
		normColor = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onHit(){
		StartCoroutine ("hitRoutine");

	}
	IEnumerator hitRoutine(){
		this.renderer.material.color = new Color (255, 0, 0);
		yield return new WaitForSeconds(0.25f);
		this.renderer.material.color = normColor;
	}
}
