using UnityEngine;
using System.Collections;

public class ChaseCamera : MonoBehaviour {

	private GameObject obj;

	// Use this for initialization
	void Start () {
		obj = GameObject.Find ("unitychan");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (obj.transform.position.x, transform.position.y, obj.transform.position.z - 2.5f);

		transform.position = pos;
	}
}
