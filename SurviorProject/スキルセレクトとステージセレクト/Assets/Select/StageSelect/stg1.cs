using UnityEngine;
using System.Collections;

public class stg1 : MonoBehaviour {

 void Start () {
  StageScript stageScript = GetComponent<StageScript>();
  stageScript.stageIconSpritePath = "res/image/stg1";
  stageScript.explanationText = "簡単すぎるステージ。くそざこ。";
  stageScript.stageName = "ステージ１";
 }
}
