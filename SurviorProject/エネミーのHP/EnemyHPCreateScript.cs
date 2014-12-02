using UnityEngine;
using System.Collections;

public class EnemyHPCreateScript : MonoBehaviour {

	enemyHPScript enemyHP;
	public bool tag = false;

	// Use this for initialization
	void Start () {
		// プレハブを取得
		GameObject prefab = (GameObject)Resources.Load ("enemyHPbass");
		enemyHP = prefab.GetComponent<enemyHPScript> ();
		enemyHP.setTarget (gameObject);
		tag = true;
		// プレハブからインスタンスを生成
		Instantiate (prefab, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
