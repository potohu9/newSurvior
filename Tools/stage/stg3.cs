using UnityEngine;
using System.Collections;

public class stg3 : MonoBehaviour {

 void Start () {
  StageScript stageScript = GetComponent<StageScript>();
  stageScript.stageIconSpritePath = "res/image/stg3";
  stageScript.explanationText = "難しすぎるステージ。マジ無理ゲー。";
  stageScript.stageName = "ステージ３";
 }
}
