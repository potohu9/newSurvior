using UnityEngine;
using System.Collections;

public class enemyHPScript : MonoBehaviour {
	GameObject canvas;
	public GameObject trget;
	public bool tag = false;
	Camera camera;
	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("enemyCanvas");
		transform.parent = canvas.transform;
		transform.localPosition = new Vector3 (0, 0, 0);

		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(trget!=null){
			Vector3 ObjectPoint = trget.transform.position;

			Vector3 screenPostion = camera.WorldToScreenPoint(ObjectPoint);

			Vector3 pos = new Vector3(screenPostion.x-492, (Screen.height-screenPostion.y)*-1+350, 0);

			transform.localPosition =pos;
		}
	}

	public void setTarget(GameObject t){
		//trget = GameObject.Find (t);
		trget = t;
		tag = true;
	}
}
