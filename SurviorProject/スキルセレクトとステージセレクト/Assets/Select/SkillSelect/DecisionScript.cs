using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DecisionScript : MonoBehaviour {

	private SetSkillManagerScript script;
	private Button botton;
	public bool flag = false;

	// Use this for initialization
	void Start () {
		GameObject manager = GameObject.Find("SetSkill");
		script = manager.GetComponent<SetSkillManagerScript>();

		botton = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		string skill1 = script.skill1;
		string skill2 = script.skill2;
		string skill3 = script.skill3;
		if(script.skill1!=null && script.skill2!=null && script.skill3!=null){
			//押せる
			botton.interactable = true;
			flag = true;
		} else {
			//押せない
			botton.interactable = false;
			flag=false;
		}
	}

	public void push(){
		//マネジャからスキル名を貰う
		string skill1 = script.skill1;
		string skill2 = script.skill2;
		string skill3 = script.skill3;
		if(script.skill1!=null && script.skill2!=null && script.skill3!=null){
			//シーン転移

		}
	}
}
