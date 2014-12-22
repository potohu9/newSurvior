using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class enemyMoveController : MonoBehaviour {
	public GameObject enemyObject;
	public GameObject laserEmitter;

	private GameObject player;
	public string playerTag = "Player";

	public float speed = 0.05f;
	public float boostSpeed = 0.1f;
	public float baseRotateSpeed = 0.5f;
	private float rotateSpeed;
	public float maxSpeed = 20.0f;

	public GameObject lineAttackPrefab;
	public GameObject pointAttackPrefab;
	public GameObject circleAttackPrefab;
	public GameObject deathblowPrefab;
	public GameObject summonCharPrefab;

	public MoveState moveState;

	public String enemyTagStr = "enemy";
	public int summonEnemyLimit = 10;

	private bool isInitMoveState = false;
	private Animator anim;

	// ========================
	public int hp = 100;
	public GameObject hitEff;
	// ========================

	public enum MoveState{
		STAY,			//停止
		ONGOING,		//前進
		RETREAT,		//後退
		SLIDE_RIGHT,	//右スライド
		SLIDE_LEFT,		//左スライド
		FRONT_BOOST,	//前ブースト
		BACK_BOOST,		//後ろブースト
		RIGHT_BOOST,	//右ブースト
		LEFT_BOOST,		//左ブースト
		DEATHBLOW,		//必殺技
	}

	public GameObject getPlayer(){
		return player;
	}

	public void setRotateSpeed(float rotateSpeed){
		this.rotateSpeed = rotateSpeed;
	}

	public int[] animNum = new int[Enum.GetNames(typeof(MoveState)).Length];

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		player = GameObject.FindWithTag(playerTag);
		rotateSpeed = baseRotateSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isInitMoveState){
			switch(moveState){
			case MoveState.STAY:
				anim.SetInteger("state",animNum[(int)MoveState.STAY]);
				break;
			case MoveState.ONGOING:
				anim.SetInteger("state",animNum[(int)MoveState.ONGOING]);
				break;
			case MoveState.RETREAT:
				anim.SetInteger("state",animNum[(int)MoveState.RETREAT]);
				break;
			case MoveState.SLIDE_RIGHT:
				anim.SetInteger("state",animNum[(int)MoveState.SLIDE_RIGHT]);
				break;
			case MoveState.SLIDE_LEFT:
				anim.SetInteger("state",animNum[(int)MoveState.SLIDE_LEFT]);
				break;
			case MoveState.FRONT_BOOST:
				anim.SetInteger("state",animNum[(int)MoveState.FRONT_BOOST]);
				enemyObject.rigidbody.AddForce(enemyObject.transform.forward * boostSpeed,ForceMode.VelocityChange);
				break;
			case MoveState.BACK_BOOST:
				anim.SetInteger("state",animNum[(int)MoveState.BACK_BOOST]);
				enemyObject.rigidbody.AddForce(-enemyObject.transform.forward * boostSpeed,ForceMode.VelocityChange);
				break;
			case MoveState.RIGHT_BOOST:
				anim.SetInteger("state",animNum[(int)MoveState.RIGHT_BOOST]);
				enemyObject.rigidbody.AddForce(enemyObject.transform.right * boostSpeed,ForceMode.VelocityChange);
				break;
			case MoveState.LEFT_BOOST:
				anim.SetInteger("state",animNum[(int)MoveState.LEFT_BOOST]);
				enemyObject.rigidbody.AddForce(-enemyObject.transform.right * boostSpeed,ForceMode.VelocityChange);
				break;
			case MoveState.DEATHBLOW:
				anim.SetInteger("state",animNum[(int)MoveState.DEATHBLOW]);
				break;
			default:
				break;
			}
			isInitMoveState = true;
		}
		switch(moveState){
		case MoveState.STAY:
			break;
		case MoveState.ONGOING:
			enemyObject.rigidbody.AddForce(enemyObject.transform.forward * speed,ForceMode.Impulse);
			break;
		case MoveState.RETREAT:
			enemyObject.rigidbody.AddForce(-enemyObject.transform.forward * speed,ForceMode.Impulse);
			break;
		case MoveState.SLIDE_RIGHT:
			enemyObject.rigidbody.AddForce(enemyObject.transform.right * speed,ForceMode.Impulse);
			break;
		case MoveState.SLIDE_LEFT:
			enemyObject.rigidbody.AddForce(-enemyObject.transform.right * speed,ForceMode.Impulse);
			break;
		case MoveState.FRONT_BOOST:
			break;
		case MoveState.BACK_BOOST:
			break;
		case MoveState.RIGHT_BOOST:
			break;
		case MoveState.LEFT_BOOST:
			break;
		case MoveState.DEATHBLOW:
			break;
		default:
			break;
		}
		Vector3 targetPos = new Vector3(player.transform.position.x,gameObject.transform.position.y,player.transform.position.y);
		Vector3 toTarget  = targetPos - enemyObject.transform.position;
		if(toTarget != Vector3.zero){
			enemyObject.transform.rotation = Quaternion.Slerp(enemyObject.transform.rotation, Quaternion.LookRotation(targetPos - enemyObject.transform.position),rotateSpeed);
		}
	}

	public void lineAttack(){
		GameObject instant_object = GameObject.Instantiate(lineAttackPrefab,laserEmitter.transform.position,Quaternion.identity) as GameObject;
		instant_object.transform.LookAt(player.transform.position);
	}

	public void pointAttack(){
		GameObject instant_object = GameObject.Instantiate(pointAttackPrefab,new Vector3(player.transform.position.x,0.01f,player.transform.position.z),Quaternion.identity) as GameObject;
		instant_object.transform.Rotate(gameObject.transform.eulerAngles);
	}

	public void circleAttack(){
		GameObject instant_object = GameObject.Instantiate(circleAttackPrefab,gameObject.transform.position,Quaternion.identity) as GameObject;
		instant_object.transform.Rotate(gameObject.transform.eulerAngles);
		circleSignController controller = instant_object.GetComponent<circleSignController>();
		controller.setAttacker(gameObject);
	}

	public void summon(){
		int enemyNum = GameObject.FindGameObjectsWithTag (enemyTagStr).Length;
		if(summonEnemyLimit > enemyNum){
			GameObject instant_object = GameObject.Instantiate(summonCharPrefab,gameObject.transform.position,gameObject.transform.rotation) as GameObject;
		}
//		instant_object.transform.LookAt(player.transform.position);
	}

	public void changeMoveState(MoveState moveState){
		this.moveState = moveState;
		isInitMoveState = false;
	}

	public void deathblow(){
		GameObject instant_object = GameObject.Instantiate(deathblowPrefab,gameObject.transform.position,Quaternion.identity) as GameObject;
		instant_object.transform.Rotate(gameObject.transform.eulerAngles);
		circleSignController controller = instant_object.GetComponent<circleSignController>();
		controller.setAttacker(gameObject);
	}

	// ===============================
	public void damage(int damage) {
		hp -= damage;

		Instantiate (hitEff, gameObject.transform.position, Quaternion.identity);
	}
	// ===============================
}
