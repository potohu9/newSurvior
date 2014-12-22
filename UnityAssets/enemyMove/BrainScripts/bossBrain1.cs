using UnityEngine;
using System.Collections;

public class bossBrain1 : MonoBehaviour {
	private enemyMoveController EM_Controller;
	private GameObject player;
	public float startEscapeDistance = 20;
	public float startDeathblowDistance = 10;
	public float startAttackDistance = 50;
	public float startAvoidWallDistance = 10;
	
	public float DeathblowCount = 5;
	private bool isPlayDeathblow = false;

	private GameObject[] wall;
	public string wallTag = "Wall";

	private float lineAttackCount;
	public float lineAttackBaseInterval;
	private float lineAttackInterval;

	private float pointAttackCount;
	public float pointAttackBaseInterval;
	private float pointAttackInterval;

	private float circleAttackCount;
	public float circleAttackBaseInterval;
	private float circleAttackInterval;

	private float summonCount;
	public float summonBaseInterval;
	private float summonInterval;

	public float deathblowMagnification = 3;

	private Vector3[] checkVec = {
		Vector3.forward,
		Vector3.back,
		Vector3.left,
		Vector3.right
	};
	
	// Use this for initialization
	void Start () {
		EM_Controller = gameObject.GetComponent<enemyMoveController>();
		player = EM_Controller.getPlayer();
		wall = GameObject.FindGameObjectsWithTag (wallTag);
	}
	
	// Update is called once per frame
	void Update () {
		if(isPlayDeathblow){
			lineAttackInterval = lineAttackBaseInterval / deathblowMagnification;
			pointAttackInterval = pointAttackBaseInterval / deathblowMagnification;
			circleAttackInterval = circleAttackBaseInterval / deathblowMagnification;
			summonInterval = summonBaseInterval / deathblowMagnification;
		}
		else{
			lineAttackInterval = lineAttackBaseInterval;
			pointAttackInterval = pointAttackBaseInterval;
			circleAttackInterval = circleAttackBaseInterval;
			summonInterval = summonBaseInterval;
		}
		lineAttackCount += Time.deltaTime;
		if(lineAttackCount >= lineAttackInterval){
			EM_Controller.lineAttack ();
			lineAttackCount = 0;
		}
		pointAttackCount += Time.deltaTime;
		if(pointAttackCount >= pointAttackInterval){
			EM_Controller.pointAttack();
			pointAttackCount = 0;
		}

		summonCount += Time.deltaTime;
		if(summonCount >= summonInterval){
			EM_Controller.summon();
			summonCount = 0;
		}

		if(player != null){
			float distance = Vector3.Distance(gameObject.transform.position,player.transform.position);
			
			EM_Controller.setRotateSpeed(EM_Controller.baseRotateSpeed * distance); 
			
			if(distance < startDeathblowDistance){
				Invoke ("readeyDeathblow", DeathblowCount);
				EM_Controller.changeMoveState(enemyMoveController.MoveState.RETREAT);
			}
			else{
				if(distance > startAttackDistance){
					EM_Controller.changeMoveState(enemyMoveController.MoveState.ONGOING);
				}
				else{
					EM_Controller.changeMoveState(enemyMoveController.MoveState.RETREAT);
				}
				isPlayDeathblow = false;
			}
			
			if(isPlayDeathblow){
				EM_Controller.deathblow();
				circleAttackCount += Time.deltaTime;
				if(circleAttackCount >= circleAttackInterval){
					EM_Controller.circleAttack();
					circleAttackCount = 0;
				}
			}
		}
		else{
			player = EM_Controller.getPlayer();
		}
		checkWall();
	}
	
	void readeyDeathblow(){
		float distance = Vector3.Distance(gameObject.transform.position,player.transform.position);
		if(distance < startDeathblowDistance){
			isPlayDeathblow = true;
		}
	}

	void checkWall(){
		RaycastHit hit;

		int length = wall.Length;
		float nearLength = 10000;
		float farLength = 0;
		int nearIndex = 0;
		int farIndex = 0;
		for(int i = 0; i < checkVec.Length; i++) {
			//LineRenderer lr = wall[i].GetComponent<LineRenderer>();

			Ray ray = new Ray (gameObject.transform.position,checkVec[i]);

			for(int j = 0; j < length; j++) {
				if(wall[j].collider.Raycast (ray, out hit, 10000)) {
					float distance = Vector3.Distance(gameObject.transform.position,hit.point);
					//lr.SetPosition(0,hit.point);
					//lr.SetPosition(1,gameObject.transform.position);
					if(nearLength > distance){
						nearLength = distance;
						nearIndex = j;
					}
					if(farLength < distance){
						farLength = distance;
						farIndex = j;
					}
				}
			}
		}
		if(nearLength < startAvoidWallDistance){
			gameObject.transform.parent.gameObject.rigidbody.AddForce(wall[farIndex].transform.position.normalized * EM_Controller.boostSpeed,ForceMode.Impulse);
		}
	}
}
