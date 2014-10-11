using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

	// Particle Path
	public static string SPARK = "spark";

	private static GameObject sign;
	private static Hashtable hash;
	private string id;

	// Use this for initialization
	void Start () {
		if (sign == null) {
			sign = GameObject.Find ("CircleSign");
		}
		// load Particle Prefab
		hash = new Hashtable ();

		hash.Add(SPARK, Resources.Load ("particle/Prefab/spark"));
	}

	// Update is called once per frame
	void Update () {

	}

	public void create(Vector3 pos, string id) {
		GameObject temp;
		Animator animator;

		temp = Instantiate (sign, pos, Quaternion.identity) as GameObject;
		temp.renderer.enabled = true;
		temp.transform.localScale = new Vector3 (5, 5, 1);

		animator = temp.GetComponent<Animator> ();
		animator.enabled = true;

		this.id = id;
	}

	void attack(){
		Vector3 pos = gameObject.transform.position;
		GameObject temp;

		//temp = Instantiate (effects.transform.Find ("Eff_Burst_7").gameObject, pos, Quaternion.identity) as GameObject;
		temp = Instantiate (hash[SPARK] as Object, pos, Quaternion.identity) as GameObject;
		temp.SetActive (true);

		//prefab.transform.localPosition = sign.transform.position;
		Destroy (gameObject);
	}

	/**
	 * -memo-
	 * 
	 * staticで各パーティクルの文字列を扱った定数を作る
	 * 
	 * 
	 */

}
