using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {
	Canvas canvas;
	public Time timer;
	private float timeS;
	
	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas>();
		canvas.renderMode = RenderMode.World;
		timeS = 0;
		timeS = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float timeN = Time.time;
		if(timeN-timeS >= 1){
			canvas.renderMode = RenderMode.Overlay;
		}
	}
}
