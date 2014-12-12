using UnityEngine;
using System.Collections;

public class RetryButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	public void nextScene()
	{

		Time.timeScale = 1.0f;
		Application.LoadLevel("test");
	}
	// Update is called once per frame
	void Update () {

	}
}
