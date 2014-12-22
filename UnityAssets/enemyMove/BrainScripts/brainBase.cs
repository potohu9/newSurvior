using UnityEngine;
using System.Collections;

public class brainBase : MonoBehaviour {
	private enemyMoveController EM_Controller;
	private GameObject player;

	// Use this for initialization
	void Start () {
		EM_Controller = gameObject.GetComponent<enemyMoveController>();
		player = EM_Controller.getPlayer();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
