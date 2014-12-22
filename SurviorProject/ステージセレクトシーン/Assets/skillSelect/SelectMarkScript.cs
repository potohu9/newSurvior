using UnityEngine;
using System.Collections;

public class SelectMarkScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//まねじゃから大正を受け取る
		GameObject manager = GameObject.Find("SetSkill");
		SetSkillManagerScript script = manager.GetComponent<SetSkillManagerScript>();
		//大正のオブジェクトの位置
		GameObject obj = GameObject.Find (script.setSukill);
		Transform objTrans = obj.GetComponent<Transform>();
		//位置を修正
		transform.localPosition = objTrans.localPosition;

	}
}