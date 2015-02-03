using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skill {

	public string explanationText;
	public string invocationEffectPrefabPath;
	public string runtimeEffectPrefabPath;
	public string skillIconSpritePath;
	public string particleSystemName;
	public float duration;
	public float coolTime;

	protected GameObject eff;
	protected Image image;
	protected float timeS;
	protected bool canTouch;
	protected PlayerStatus status;

	protected GameObject target;

	// Use this for initialization

	public Skill() {

	}

	// Update is called once per frame
	protected void Update () {
	
	}

	public virtual void Push() {
	
	}

	public virtual void startEffect() {

	}

	public virtual void endEffect() {

	}


}
