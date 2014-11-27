using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkikkButtonScript : MonoBehaviour {

	private int ATTACK = 5;
	private uint DEFENCE = 4;
	private float SPEED = 5;

	public GameObject prefab;
	public GameObject target;
	public Image image;
	public bool pushFlag;

	public uint coolTime = 30;
	public Time timer;
	private float timeS;
	public float duration = 30;	// 持続時間
	
	private static string name;

	PlayerStatus script;
	GameObject type;

	void Start () {
		pushFlag = true;
		timeS = 0;

		name = null;

		image = GetComponent<Image>();

		GameObject obj = GameObject.Find("Player");
		script = obj.GetComponent<PlayerStatus> ();
		
		type = this.gameObject;
	}

	// ボタンを押した際に呼ばれる関数
	public void Push()
	{
		if(pushFlag==true){
			if(name != null) {
				GameObject.Find (name).GetComponent<SkikkButtonScript>().stopCoroutine();
			}

			name = type.name;

			image.fillAmount = 0;
			pushFlag=false;
			// ボタンが押した際に出力
			//print("Button Push!");

			//カメラとの距離
			GameObject instance = Instantiate (prefab, target.transform.position, Quaternion.identity) as GameObject;
			instance.transform.parent = target.transform;
			Destroy (instance, 5);

			timeS = Time.time;	//ゲーム起動から今までの時間

			switch(type.name){
			case "skill1button":
				script.AT += ATTACK;
				break;
			case "skill2button":
				script.DF += DEFENCE;
				break;
			case "skill3button":
				script.SP += SPEED;
				break;
			default:
				script.HP -= 10;
				break;
			}

			StartCoroutine ("limitDuration");
		}
	}

	void Update () {
		if(pushFlag==false){

			float timeN = Time.time;
			image.fillAmount = (timeN-timeS)/coolTime;

			if(timeN-timeS >= coolTime){
				pushFlag=true;
			}


			print ("AT=" + script.AT);
			print ("DF=" + script.DF);
			print ("SP=" + script.SP);

		}
	}

	IEnumerator limitDuration () {
		yield return new WaitForSeconds (duration);

		switch(type.name){
		case "skill1button":
			script.AT -= ATTACK;
			break;
		case "skill2button":
			script.DF -= DEFENCE;
			break;
		case "skill3button":
			script.SP -= SPEED;
			break;
		default:
			script.HP -= 10;
			break;
		}

		name = null;
	}

	public void stopCoroutine (){
		StopCoroutine ("limitDuration");

		switch(name){
		case "skill1button":
			script.AT -= ATTACK;
			break;
		case "skill2button":
			script.DF -= DEFENCE;
			break;
		case "skill3button":
			script.SP -= SPEED;
			break;
		default:
			script.HP -= 10;
			break;
		}
	}

}
