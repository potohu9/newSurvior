using UnityEngine;
using System.Collections;

public class stg1 : MonoBehaviour {

 void Start () {
  StageScript stageScript = GetComponent<StageScript>();
  stageScript.stageIconSpritePath = "res/image/stg1";
  stageScript.explanationText = "�ȒP������X�e�[�W�B���������B";
  stageScript.stageName = "�X�e�[�W�P";
 }
}
