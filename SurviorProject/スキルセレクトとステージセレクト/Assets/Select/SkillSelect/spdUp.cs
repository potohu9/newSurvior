using UnityEngine;
using System.Collections;

public class spdUp : SkillScript {

 void Start () {
  SkillScript script = GetComponent<SkillScript> ();
  script.explanationText = "早くなるよ";
  script.invocationEffectPrefabPath = "res/prefab/spdeff1";
  script. runtimeEffectPrefabPath = "res/prefab/spdeff2";
  script.skillIconSpritePath = "Speed_up";
 }
 
 //スキル効果記述欄
 void skillEffect(GameObject targetObject){
  
 }
}
