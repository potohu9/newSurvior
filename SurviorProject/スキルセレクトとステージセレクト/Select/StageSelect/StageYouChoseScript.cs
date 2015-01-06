using UnityEngine;
using System.Collections;

public class StageYouChoseScript : MonoBehaviour {

	private SetStageManagerScript script;
	private GameObject manager;
	
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("setStage");
		script = manager.GetComponent<SetStageManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void push(){
		script.setStage = this.name;
	}
}
