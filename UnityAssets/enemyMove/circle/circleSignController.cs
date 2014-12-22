using UnityEngine;
using System.Collections;

public class circleSignController : MonoBehaviour {

	public GameObject attackPrefab;

	private GameObject attacker = null;
	
	private Animation signAnim;
	
	// Use this for initialization
	void Start () {
		signAnim = gameObject.GetComponent<Animation>();
	}

	public void setAttacker(GameObject attacker){
		this.attacker = attacker;
	}
	
	// Update is called once per frame
	void Update () {
		if(attacker != null){
			gameObject.transform.position = attacker.transform.position;
		}
		if(!signAnim.isPlaying){
			Destroy(gameObject);
		}
	}
	
	void createAttack(){
		GameObject instant_object = GameObject.Instantiate(attackPrefab,gameObject.transform.position,attackPrefab.transform.rotation) as GameObject;
		//instant_object.transform.Rotate(gameObject.transform.eulerAngles);
	}
}
