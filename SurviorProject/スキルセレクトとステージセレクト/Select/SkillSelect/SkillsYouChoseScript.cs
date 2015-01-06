using UnityEngine;
using System.Collections;

public class SkillsYouChoseScript : MonoBehaviour {

	private SetSkillManagerScript script;
	private GameObject manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("SetSkill");
		script = manager.GetComponent<SetSkillManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void push(){
		script.setSukill = this.name;
	}
}
