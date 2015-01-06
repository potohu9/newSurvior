using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTextScript : MonoBehaviour {

	public string skillName;
	private GameObject manager;
	private SetSkillManagerScript script;

	public SkillScript skillText;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("SetSkill");
		script = manager.GetComponent<SetSkillManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(script.setSukill!=null){
			GameObject skillObj = GameObject.Find(script.setSukill);
			skillText = skillObj.GetComponent<SkillScript>();

			Text myText = GetComponent<Text>();
			myText.text = skillText.explanationText;

		}
	}
}
