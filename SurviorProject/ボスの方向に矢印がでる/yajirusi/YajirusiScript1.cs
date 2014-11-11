using UnityEngine;
using System.Collections;

public class YajirusiScript1 : MonoBehaviour {

	Transform playerTransform;
	Transform enemyTransform;
	Transform yajirusiTransform;

	public string target;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("Player");
		playerTransform = player.transform;

		//GameObject enemy = GameObject.Find ("bossEnemy1").transform.FindChild("Query-Chan").gameObject;
		//enemyTransform = enemy.transform;

		yajirusiTransform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {

		yajirusiTransform.LookAt (enemyTransform.position);
		yajirusiTransform.position = playerTransform.position;
	}

	public void setTarget(string t){
		target = t;

		GameObject enemy = GameObject.Find (target).transform.FindChild("Query-Chan").gameObject;
		enemyTransform = enemy.transform;
	}
}
