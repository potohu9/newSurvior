using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private GameObject player;
	private GameObject background;
	private Animator animator;
	//^^^^^^^^
	GameObject temp;
	Transform transform;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("unitychan");
		background = GameObject.Find ("Back1");
		animator = player.GetComponent<Animator> ();

		//^^^^^^^^
		temp = Instantiate(Resources.Load("Prefabs/movetragetsprite"),new Vector3(0, 0.1f, 0),Quaternion.identity) as GameObject;
		transform = temp.GetComponent<Transform> ();
		transform.position = new Vector3(0,-1,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			if(Input.GetTouch (0).phase == TouchPhase.Began
			|| Input.GetTouch (0).phase == TouchPhase.Stationary
			|| Input.GetTouch (0).phase == TouchPhase.Moved) {
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit hit;

				if(background.collider.Raycast (ray, out hit, 1000)) {
					// 移動
					Vector3 target = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
					Vector3 temp = target - player.transform.position;
					Vector3 nor = temp.normalized;

					Vector3 pos = (nor * 0.1f) + player.transform.position;

					player.transform.position = pos;

					float rad = Mathf.Atan2((hit.point.x - player.transform.position.x), (hit.point.z - player.transform.position.z));

					// 向き
					player.transform.rotation = Quaternion.Euler (0, rad * Mathf.Rad2Deg, 0);

					// アニメーション
					animator.SetBool ("isRunning",true);

				}
				//^^^^^^^^
				transform.position = new Vector3(hit.point.x, 0.1f, hit.point.z);
			} else {
				//^^^^^^^^^^^^
				transform.position = new Vector3(0,-1,0);
			}

			if(Input.GetTouch (0).phase == TouchPhase.Ended) {
				animator.SetBool ("isRunning", false);
			}
		}
	}


}
