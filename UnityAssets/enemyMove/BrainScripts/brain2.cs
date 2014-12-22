using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class brain2 : MonoBehaviour {
	
	private enemyMoveController EM_Controller;
	private GameObject player = null;
	private int move_Count;
	private bool flag;
	private Text distanceText;
	private float count;		// 攻撃間隔までのカウント
	public float interval;		// 攻撃間隔
	
	// Use this for initialization
	void Start () {
		EM_Controller = gameObject.GetComponent<enemyMoveController>();
		player = EM_Controller.getPlayer();
		move_Count = 0;
		flag = false;
		EM_Controller.changeMoveState (enemyMoveController.MoveState.ONGOING);
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		if (player != null) {
			// プレイヤーとの距離を計算
			float distance = Vector3.Distance (gameObject.transform.position , player.transform.position);
			
			// プレイヤーとの距離が一定に達したらAI変更
			if(distance <= 8){
				EM_Controller.changeMoveState (enemyMoveController.MoveState.SLIDE_LEFT);
			}else{
				EM_Controller.changeMoveState (enemyMoveController.MoveState.ONGOING);
			}
		}
		else {
			player = EM_Controller.getPlayer();
		}

		if(count >= interval){
			EM_Controller.lineAttack ();
			count = 0;
		}
		
	}
}
