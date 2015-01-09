using UnityEngine;
using System.Collections;

public class attUp : SkillScript {

 void Start () {
  SkillScript script = GetComponent<SkillScript> ();
  script.explanationText = "攻撃力強くなるよ";
  script.invocationEffectPrefabPath = "res/prefab/atteff1";
  script. runtimeEffectPrefabPath = "res/prefab/eff2";
  script.skillIconSpritePath = "Attack_up";
 }
 
 //スキル効果記述欄
 void skillEffect(GameObject targetObject){
  
 }
}
