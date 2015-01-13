using UnityEngine;
using System.Collections;

public class stg2 : MonoBehaviour {

 void Start () {
  StageScript stageScript = GetComponent<StageScript>();
  stageScript.stageIconSpritePath = "res/image/stg2";
  stageScript.explanationText = "普通すぎるステージ。ＫＯＨ。";
  stageScript.stageName = "ステージ２";
 }
}
