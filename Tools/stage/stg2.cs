using UnityEngine;
using System.Collections;

public class stg2 : MonoBehaviour {

 void Start () {
  StageScript stageScript = GetComponent<StageScript>();
  stageScript.stageIconSpritePath = "res/image/stg2";
  stageScript.explanationText = "���ʂ�����X�e�[�W�B�j�n�g�B";
  stageScript.stageName = "�X�e�[�W�Q";
 }
}
