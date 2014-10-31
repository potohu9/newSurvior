using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections;

public class SkikkButtonScript : MonoBehaviour {

	public GameObject prefab;
	public GameObject target;
	public Image image;
	public bool pushFlag;

	public uint coolTime;
	public Time timer;
	public float timeS;

	GameObject obj;
	PlayerStatus script;

	GameObject type;

	void Start () {
		pushFlag = true;
		coolTime = 5;
		timeS = 0;
		image = GetComponent<Image>();

		obj = GameObject.Find("unitychan");
		script = obj.GetComponent<PlayerStatus> ();

		type = this.gameObject;
	}

	// ボタンを押した際に呼ばれる関数
	public void Push()
	{
		if(pushFlag==true){
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
					script.AT += 10;
					break;
				case "skill2button":
					script.DF += 10;
					break;
				case "skill3button":
					script.SP += 10;
					break;
				default:
					script.HP -= 10;
					break;
			}
		}
	}

	void Update () {
		if(pushFlag==false){
			float timeN = Time.time;
			image.fillAmount = (timeN-timeS)/coolTime;
			if(timeN-timeS >= coolTime){
				pushFlag=true;
				switch(type.name){
				case "skill1button":
					script.AT -= 10;
					break;
				case "skill2button":
					script.DF -= 10;
					break;
				case "skill3button":
					script.SP -= 10;
					break;
				default:
					script.HP -= 10;
					break;
				}
			}
		}
		
	}
}
