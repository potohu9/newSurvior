using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageTextScript : MonoBehaviour {

	public string stageName;
	private GameObject manager;
	private SetStageManagerScript script;
	
	public StageScript stageText;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("setStage");
		script = manager.GetComponent<SetStageManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(script.setStage!=null){
			GameObject stageObj = GameObject.Find(script.setStage);
			stageText = stageObj.GetComponent<StageScript>();
			
			Text myText = GetComponent<Text>();
			myText.text = stageText.explanationText;
			
		}
	}
}
