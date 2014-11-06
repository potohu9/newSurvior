using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour {

	public int HP;
	public int AT;
	public int DF;
	public float SP;
	Text atText;
	Text dfText;
	Text spText;
	Text hpText;

	public Texture2D texture;
	public Texture2D startMask, endMask;
	public float fadeinTime = 0.4f, fadeoutTime = 1.4f;


	// Use this for initialization
	void Start () {
		FadeSwitch.IsFadeIn = true;
		HP = 100;
		AT = 10;
		DF = 10;
		SP = 0.1f;
		GameObject obj = GameObject.Find("ATText");
		atText = obj.GetComponent<Text>();
		obj = GameObject.Find("DFText");
		dfText = obj.GetComponent<Text>();
		obj = GameObject.Find("SPText");
		spText = obj.GetComponent<Text>();

		obj = GameObject.Find("HPText");
		hpText = obj.GetComponent<Text>();
	}

	void Update(){
		atText.text = "AT" + AT;
		dfText.text = "DF" + DF;
		spText.text = "SP" + SP;

		hpText.text = "HP" + HP + "    " + HP*0.01f;

		if(HP<=0){
			Application.LoadLevel("gameover");
			FadeSwitch.IsFadeIn = false;
			//LoadLevel ("gameover");
		}
	}

	void LoadLevel (string name)	
	{
		/*
		float time = 1; // フェードアウト時間
		atText.text = "time" + time;
		// フェードアウト
		FadeCamera.Instance.FadeOut (time, () =>                            
		{
			// フェードアウト完了後の処理（画面は真っ暗）
			Application.LoadLevel(name); //　シーン遷移
			atText.text = "AT" + 222222222222;
			//time=1;
			// フェードイン
			FadeCamera.Instance.FadeIn (time, () =>
			{
				//  フェードイン完了後の処理
				atText.text = "AT" + 33333333333333333;
			});
		});
		*/

		FadeCamera.Instance.UpdateTexture(texture);
		FadeCamera.Instance.UpdateMaskTexture(startMask);
		FadeCamera.Instance.FadeOut ( fadeinTime, () =>
		                             {
			Application.LoadLevel (name);
			FadeCamera.Instance.UpdateMaskTexture(endMask);
			FadeCamera.Instance.FadeIn (fadeoutTime , null);
		});
	}
}
