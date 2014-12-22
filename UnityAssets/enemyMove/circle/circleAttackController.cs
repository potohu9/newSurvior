using UnityEngine;
using System.Collections;

public class circleAttackController : MonoBehaviour {

	public float repelPower = 1;
	public int power = 1;

	private PlayerController script;

	void Start() {
		script = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player") {
			script.damage (6);
		}
		Destroy (gameObject.GetComponent<SphereCollider>());
	}
}
