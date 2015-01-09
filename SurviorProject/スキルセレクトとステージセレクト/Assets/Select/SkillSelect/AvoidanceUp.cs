using UnityEngine;
using System.Collections;

public class AvoidanceUp : SkillScript {

 void Start () {
  SkillScript script = GetComponent<SkillScript> ();
  script.explanationText = "このスキル・・・\n踊るよ・・・";
  script.invocationEffectPrefabPath = "res/prefab/spdeff1";
  script. runtimeEffectPrefabPath = "res/prefab/spdeff2";
  script.skillIconSpritePath = "Avoidance_up";
 }
 
 //スキル効果記述欄
 void skillEffect(GameObject targetObject){
  
 }
}
