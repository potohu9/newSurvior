using UnityEngine;
using System.Collections;

public class brain3 : MonoBehaviour {
	private enemyMoveController EM_Controller;
	private GameObject player;
	private float count;		// 攻撃間隔までのカウント
	public float interval;		// 攻撃間隔(秒数指定)
	
	// Use this for initialization
	void Start () {
		EM_Controller = gameObject.GetComponent<enemyMoveController>();
		player = EM_Controller.getPlayer();
		EM_Controller.changeMoveState (enemyMoveController.MoveState.STAY);
		count = 0;
		// WaitForSeconds();
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		if(count >= interval){
			EM_Controller.lineAttack ();
			count = 0;
		}
	}
}
