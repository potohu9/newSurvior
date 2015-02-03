using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	const int IDLE = 0;
	const int RUN = 1;
	const int DAMAGE = 2;
	int DEATH = 3;

	private static int MAX_HP = 100;

	private GameObject player;
	private GameObject background;
	private Animator animator;

	GameObject temp;
	Transform transform;
	PlayerStatus status;

	public GameObject attackEff;
	public GameObject hitEff;
	public GameObject deathEff;

	private float interval = 1;
	private float count = 0;

	private float invincible = 0;	// 無敵時間

	private bool damaged;
	private int animeState;			//
	float time;

	bool canStoped;

	GameObject joy;
	public GameObject joyjoy;
	
	public bool isBarrier = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		//background = GameObject.Find ("Back1");
		background = GameObject.Find ("Terrain 1");
		animator = player.GetComponent<Animator> ();

		/*temp = Instantiate(Resources.Load("Prefabs/movetraget/movetragetsprite"),new Vector3(0, 0.1f, 0),Quaternion.identity) as GameObject;
		transform = temp.GetComponent<Transform> ();
		transform.position = new Vector3(0,-1,0);*/

		GameObject obj = GameObject.Find("Player");

		status = obj.GetComponent<PlayerStatus> ();

		status.HP = MAX_HP;
		animeState = -1;

		Application.targetFrameRate = 60; 

		joy = GameObject.Find ("MobileJoystick") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		// rigidbodyを常時有効にし続ける（重かったら別の方法考える）
		gameObject.GetComponent<Rigidbody>().WakeUp();
		/*if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			if(touch.phase == TouchPhase.Began) {
				print("joy");
				Vector3 vec = new Vector3(touch.position.x, touch.position.y ,0);
				joy.transform.position = vec;
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			Vector3 vec = new Vector3(Input.mousePosition.x, Input.mousePosition.y , 0);
			(Instantiate(joyjoy, vec, Quaternion.Euler(0, 0, 0)) as GameObject).transform.parent = (GameObject.Find ("Canvas") as GameObject).transform;
		}*/

		if (animeState != -1) {
			changeState (animeState);
			animeState =  -1;
		}

		if (damaged) {
			// ダメージのアニメーション中
			AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

			if(info.nameHash == Animator.StringToHash ("Base Layer.Damage")) {
				if(info.normalizedTime >= 1.0f) {
					print ("damage");
					//animator.SetInteger("state", IDLE);
					animeState = IDLE;
					damaged = false;
					time = 0;
				}
			}
		}
		else {

			move ();

			invincible -= Time.deltaTime;
		}

		/*if (Input.GetMouseButtonUp (0)) {
			animator.SetBool ("isRunning", false);		
		}*/

		count += Time.deltaTime;
	}

	public float getHpRate() {
		return (float)status.HP / MAX_HP;
	}

	public void damage(int damage) {
		if(isBarrier){
			isBarrier = false;
		}
		else if(invincible <= 0) {
			/*if(animator.GetBool("isRunning") == true) {
				print ("oppai");
				animator.SetBool ("isDamage", true);
				animator.SetBool ("isRunning", false);
			}*/
			player.rigidbody.velocity = Vector3.zero;

			damaged = true;

			animeState = DAMAGE;

			status.HP -= damage - (int)status.DF;

			if(status.HP > 0) {
				// Hit Effect
				Instantiate (hitEff, gameObject.transform.position, Quaternion.identity);
			}
			else {
				// GameOver
				Instantiate (deathEff, gameObject.transform.position, Quaternion.identity);
			}

			invincible = 2;
			//animator.SetBool ("isDamage1", false);
			//animator.stop
		}
	}

	/**
	 * Collision
	 */
	void OnCollisionStay(Collision collision) {
		if(count >= interval) {
			if(collision.gameObject.tag == "Enemy") {
				Vector3 pos = player.transform.position;
				pos.y = 0.2f;
				float rad = Mathf.Atan2((collision.gameObject.transform.position.x - player.transform.position.x), (collision.gameObject.transform.position.z - player.transform.position.z));

				Instantiate (attackEff, pos, Quaternion.Euler (0, rad * Mathf.Rad2Deg - 180, 0));

				collision.gameObject.GetComponentInChildren<enemyMoveController>().damage (status.AT);

				count = 0;
			}
		}
	}

	void OnTriggerStay(Collider collider) {
		if(count >= interval) {
			if(collider.gameObject.tag == "Enemy") {
				Vector3 pos = player.transform.position;
				pos.y = 0.2f;
				float rad = Mathf.Atan2((collider.gameObject.transform.position.x - player.transform.position.x), (collider.gameObject.transform.position.z - player.transform.position.z));
				
				Instantiate (attackEff, pos, Quaternion.Euler (0, rad * Mathf.Rad2Deg - 180, 0));
				
				collider.gameObject.GetComponentInChildren<enemyMoveController>().damage (status.AT);
				
				count = 0;
			}
		}
	}

	void move() {
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis ("Vertical");

		if (horizontal != 0 || vertical != 0) {
			Vector3 vec = new Vector3(horizontal, 0, vertical);

			gameObject.rigidbody.AddForce(vec.normalized * status.SP * Time.deltaTime, ForceMode.Impulse);

			float rad = Mathf.Atan2(horizontal, vertical);

			gameObject.transform.rotation = Quaternion.Euler (0, rad * Mathf.Rad2Deg, 0);

			animeState = RUN;
		}
		else {
			animeState = IDLE;
		}
	}

	void changeState(int id) {
		switch (id) {
		case IDLE:
			animator.SetInteger ("state", IDLE);
			break;

		case RUN:
			animator.SetInteger ("state", RUN);
			break;

		case DAMAGE:
			animator.SetInteger ("state", DAMAGE);
			break;
		}
	}
}
