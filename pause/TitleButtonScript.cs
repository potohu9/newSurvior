using UnityEngine;
using System.Collections;

public class TitleButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//renderer.enabled = false;
	}

	public void nextScene()
	{
		if(Time.timeScale == 0.0f) {
			Time.timeScale = 1.0f;
			Application.LoadLevel("titleScene");
		}
	}

	// Update is called once per frame
	void Update () {
		/*
		int a = Time.timeScale;
		if (a <= 0.0) {
			renderer.enabled = true;
		}else {
			renderer.enabled = false;
		}
		*/
	
	}
}
