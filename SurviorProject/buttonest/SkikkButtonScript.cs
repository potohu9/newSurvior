using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkikkButtonScript : MonoBehaviour {

	public GameObject prefab;
	public GameObject target;
	public Image image;
	public bool pushFlag;

	void Start () {
		pushFlag = true;
		image = GetComponent<Image>();
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
		}
	}

	void Update () {
		if(pushFlag==false){
			image.fillAmount += 0.005f;
			if(image.fillAmount>=1){
				pushFlag=true;
			}
		}
		
	}
}
