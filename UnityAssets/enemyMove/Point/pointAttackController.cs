using UnityEngine;
using System.Collections;

public class pointAttackController : MonoBehaviour {

	public float repelPower = 1;
	public int power = 1;

	private PlayerController script;

	void Start() {
		script = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}
	
	/*void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player") {
			script.damage (6);
		}

		Destroy (gameObject.GetComponent<SphereCollider>());
	}*/

	void OnTriggerEnter(Collider collider) {
		SphereCollider temp = collider as SphereCollider;
		if(temp != null) {
			if (collider.gameObject.tag == "Player") {
				script.damage (15);		
			}
			print ("point");
			Destroy (gameObject.GetComponent<SphereCollider> ());
		}
	}
}