using UnityEngine;
using System.Collections;

public class stg3 : MonoBehaviour {

 void Start () {
  StageScript stageScript = GetComponent<StageScript>();
  stageScript.stageIconSpritePath = "res/image/stg3";
  stageScript.explanationText = "�������X�e�[�W�B�}�W�����Q�[�B";
  stageScript.stageName = "�X�e�[�W�R";
 }
}
