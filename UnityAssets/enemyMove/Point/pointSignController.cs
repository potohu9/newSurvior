using UnityEngine;
using System.Collections;

public class pointSignController : MonoBehaviour {

	public GameObject attackPrefab;

	private Animation signAnim;
	
	// Use this for initialization
	void Start () {
		signAnim = gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!signAnim.isPlaying){
			Destroy(gameObject);
		}
	}

	void createAttack(){
		if(attackPrefab != null){
			GameObject instant_object = GameObject.Instantiate(attackPrefab,gameObject.transform.position,Quaternion.identity) as GameObject;
			instant_object.transform.Rotate(gameObject.transform.eulerAngles);
		}
	}
}
