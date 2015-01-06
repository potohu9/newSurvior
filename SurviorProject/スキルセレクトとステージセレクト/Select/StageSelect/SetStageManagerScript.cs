using UnityEngine;
using System.Collections;

public class SetStageManagerScript : MonoBehaviour {

	public string setStage;

	// Use this for initialization
	void Start () {
		setStage="Attack_up";
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
