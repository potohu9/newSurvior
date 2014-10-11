using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	private GameObject player;	// Bar オブジェクトの取得実験
	public GameObject circleSign;
	private GameObject background;
	private GameObject query;

	private int count = 80;

	// Use this for initialization
	void Start () {
		// 画面の向きを制御（デフォは横？）
		Screen.orientation = ScreenOrientation.LandscapeLeft; // 縦向き

		player = GameObject.Find ("unitychan");

		circleSign = GameObject.Find ("CircleSign");
		// Background
		background = GameObject.Find ("Back1");


		query = GameObject.Find ("Query-Chan");
	}
	
	// Update is called once per frame
	void Update () {
		// 座標を移動等させる時、値を一度格納し
		// それを代入しなおす形にしないとエラーをはかれる 謎


		// キー入力のテスト PCでも動作させるため
		if (Input.GetKey (KeyCode.RightArrow)) {
			//temp.x += 0.3f;
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			//temp.x -= 0.3f;
		}

		// タッチパネル入力テスト

		/**
		 * -memo-
		 * 
		 *  Began タッチの開始
   		 * 	Ended タッチの終了
    	 *	Moved 移動中
    	 *	Stationary タッチが継続中の場合(非移動中)
    	 *	Canceled タッチがキャンセルになった場合
		 */
		/**
		if (Input.touchCount > 0) {
			// パネルが１つ以上タッチされている
			if(Input.GetTouch (0).phase == TouchPhase.Began) {
				if(Screen.width / 5 > Input.GetTouch (0).position.x) {
					temp.x += 0.3f;
				}
				else {
					temp.x -= 0.3f;
				}
			}

			if(Input.GetTouch (0).phase == TouchPhase.Moved
			|| Input.GetTouch (0).phase == TouchPhase.Stationary) {
				if(Screen.width / 2 < Input.GetTouch (0).position.x) {
					temp.x += 0.3f;
				}
				else {
					temp.x -= 0.3f;
				}
			}

			if(Input.GetTouch (0).phase == TouchPhase.Ended) {

			}
		}

		// 入力に応じて移動
		bar.transform.position = temp;
		*/

		/*if (Input.touchCount > 0) {
			if(Input.GetTouch(0).phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit hit;

				if(background.collider.Raycast (ray, out hit, 1000)) {*/
		if (count <= 0) {
			count = 80;

			GameObject obj;
			Circle script;
			Animator animator;

			Vector3 pos = new Vector3 (player.transform.position.x, 0.1f, player.transform.position.z);

						// プレハブを複製
						//obj = Instantiate (circleSign, pos, Quaternion.identity) as GameObject;
						//obj.renderer.enabled = true;

			// プレハブに設定されているスクリプトを取得
			script = circleSign.GetComponent<Circle> ();
			script.create (pos, Circle.SPARK);
		}
		else {
			count--;
		}
				/*}
			}
		}*/

		if (Input.GetKey (KeyCode.Q)) {
			QueryAnimationController script = query.GetComponent<QueryAnimationController>();
			script.ChangeAnimation (QueryAnimationController.QueryChanAnimationType.FLY_IDLE);
		}

		if (Input.GetKey (KeyCode.W)) {
			QueryAnimationController script = query.GetComponent<QueryAnimationController>();
			script.ChangeAnimation (QueryAnimationController.QueryChanAnimationType.FLY_STRAIGHT);
		}

		if (Input.GetKey (KeyCode.E)) {
			QueryAnimationController script = query.GetComponent<QueryAnimationController>();
			script.ChangeAnimation (QueryAnimationController.QueryChanAnimationType.FLY_ITEMGET_LOOP);
		}



		// タッチ座標にサインの表示
		/*if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				circleSign.renderer.enabled = true;
				//Instantiate (circleSign, Input.GetTouch (0).position, Quaternion.identity);
				Instantiate (circleSign, new Vector3(0, 0, 0), Quaternion.identity);
				circleSign.renderer.enabled = false;
			}
		*/
	}
}
