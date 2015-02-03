using UnityEngine;
using System.Collections;

public class AttUp : Skill {

	private static int ATTACK = 5;
	string particleSystemName;

	public AttUp() {
		explanationText = "攻撃力が急上昇↑↑";
		invocationEffectPrefabPath = "SkillParticle/Attack_Buf";
		runtimeEffectPrefabPath = "SkillParticle/Aura";
		skillIconSpritePath = "SkillIcon/AttackUp";
		particleSystemName = "MagicField1";
		duration = 30f;
		coolTime = 30f;

		target = GameObject.Find ("Player");
	}
 
	public override void Push() {
		if (target == null) {
			target = GameObject.Find ("Player");	
		}

		GameObject obj = GameObject.Instantiate (Resources.Load (invocationEffectPrefabPath), new Vector3(0, 0.1f, 0), Quaternion.identity) as GameObject;
		obj.transform.position = target.transform.position;
		obj.transform.parent = target.transform;
		//obj.transform.GetChild (0).gameObject.AddComponent<ShurikenParticle> ();
	}

	public override void startEffect() {
		eff = GameObject.Instantiate(Resources.Load(runtimeEffectPrefabPath), new Vector3(0, 0.1f, 0),Quaternion.identity) as GameObject;

		eff.transform.position = target.transform.position;
		eff.transform.parent = target.transform;
	}

	public override void endEffect() {
		GameObject.Destroy (eff);
	}

}
