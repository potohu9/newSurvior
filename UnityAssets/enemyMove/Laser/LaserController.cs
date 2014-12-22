using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {
	public float speed = 150.0f;
	public ParticleSystem effect;
	public float repelPower = 1;
	public int power = 1;

	private PlayerController script;

	// Use this for initialization
	void Start () {
		gameObject.rigidbody.AddForce(transform.forward * speed,ForceMode.VelocityChange);

		script = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player") {
			script.damage (10);
		} 

		effect.Stop();
		gameObject.transform.DetachChildren();
		Destroy(gameObject);
	}
}
