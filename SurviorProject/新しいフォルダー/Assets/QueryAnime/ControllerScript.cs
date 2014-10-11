using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	private GameObject obj;
	private QueryAnimationController qAnime;
	private int count=0;

	public const int baseAttackCount = 120;
	public float stayLength = 10;
	private int attackCount = baseAttackCount;

	private Line line;

	//EnemyMoveFactory enemyMoveFactory;
	private AbstractEnemyAIController straight;
	private AbstractEnemyAIController wait;
	private AbstractEnemyAIController smallSlalom;
	private AbstractEnemyAIController damage;
	private AbstractEnemyAIController disappo;
	private AbstractEnemyAIController turnRight;
	private AbstractEnemyAIController turnLeft;
	private AbstractEnemyAIController attack;

	enum MoveState{
		STRAIGHT,
		WAIT,
		SMALL_SLALOM,
		DAMAGE,
		DISAPPO,
		TURN_R,
		TURN_L
	};

	private MoveState moveState = MoveState.WAIT;

	public GameObject enemy;


	// Use this for initialization
	void Start () {
		obj = GameObject.Find ("Query-Chan");
		qAnime =  obj.GetComponent<QueryAnimationController>();
		straight = new Straight (obj,qAnime);
		wait = new Wait (obj, qAnime);
		smallSlalom = new SmallSlalom(obj,qAnime);
		damage = new Damage (obj, qAnime);
		disappo = new Disappo (obj, qAnime);
		turnRight = new TurnRight (obj, qAnime);
		turnLeft = new TurnLeft (obj, qAnime);
		attack = new Attack (obj, qAnime);
		moveState = MoveState.SMALL_SLALOM;

		line = obj.GetComponent<Line> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt(enemy.transform.position);

		Vector3 subEnemyLength = gameObject.transform.position - enemy.transform.position;

		if(subEnemyLength.magnitude <= stayLength){
			Vector3 enemyPoint = enemy.transform.position;
			Vector3 thisCharaPoint = gameObject.transform.position;
			Vector3 thisCharaRotVec = thisCharaPoint + Vector3.forward * stayLength;
			float n = enemyPoint.x * (thisCharaPoint.z - thisCharaRotVec.z) + thisCharaPoint.x * (thisCharaRotVec.z - enemyPoint.z) + thisCharaRotVec.x * (enemyPoint.y - thisCharaPoint.z);
			if(n > 0){
				moveState = MoveState.TURN_L;
			}
			else if(n <= 0){
				moveState = MoveState.TURN_R;
			}
		}
		else{
			moveState = MoveState.SMALL_SLALOM;
		}

		attackCount--;
		if(attackCount <= 0){
			attackCount = baseAttackCount;
			AttackMove(count);
		}

		switch(moveState){
		case MoveState.STRAIGHT:
			StraightMove(count);
			break;
		case MoveState.WAIT:
			WaitMove(count);
			break;
		case MoveState.SMALL_SLALOM:
			SmallSlalomMove(count);
			count++;
			break;
		case MoveState.DAMAGE:
			DamageMove(count);
			break;
		case MoveState.DISAPPO:
			DisappoMove(count);
			break;
		case MoveState.TURN_R:
			TurnRightMove(count);
			break;
		case MoveState.TURN_L:
			TurnLeftMove(count);
			break;
		default:
			WaitMove(count);
			break;
		}
	}

	public void StraightMove(int count){
		straight.move (count);
	}
	public void WaitMove(int count){
		wait.move (count);
	}
	public void SmallSlalomMove(int count){
		smallSlalom.move(count);
	}
	public void DamageMove(int count){
		damage.move(count);
	}
	public void DisappoMove(int count){
		disappo.move(count);
	}
	public void TurnRightMove(int count){
		turnRight.move(count);
	}
	public void TurnLeftMove(int count){
		turnLeft.move(count);
	}
	public void AttackMove(int count){
		attack.move(count);
		Vector3 pos = obj.transform.position;
		pos.y = 0;
		line.Create (pos, this.enemy.transform.position, 2);
	}

}
