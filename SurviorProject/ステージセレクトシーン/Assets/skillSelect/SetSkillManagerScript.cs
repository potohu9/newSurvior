using UnityEngine;
using System.Collections;

public class SetSkillManagerScript : MonoBehaviour {

	public string setSukill;

	public string skill1;
	public string skill2;
	public string skill3;

	// Use this for initialization
	void Start () {
		setSukill = "Attack_up";
		skill1 = null;
		skill2 = null;
		skill3 = null;

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
