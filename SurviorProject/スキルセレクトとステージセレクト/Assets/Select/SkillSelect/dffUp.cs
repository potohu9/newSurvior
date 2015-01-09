using UnityEngine;
using System.Collections;

public class dffUp : SkillScript {

 void Start () {
  SkillScript script = GetComponent<SkillScript> ();
  script.explanationText = "防御力強くなるよ";
  script.invocationEffectPrefabPath = "res/prefab/dffeff";
  script. runtimeEffectPrefabPath = "res/prefab/dffeff2";
  script.skillIconSpritePath = "Deffens_up";
 }
 
 //スキル効果記述欄
 void skillEffect(GameObject targetObject){
  
 }
}
