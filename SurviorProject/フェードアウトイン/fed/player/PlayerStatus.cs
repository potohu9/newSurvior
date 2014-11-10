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
			FadeSwitch.IsFadeIn = false;
			StartCoroutine("hyouji");
		}
	}

	IEnumerator hyouji(){
		yield return new WaitForSeconds (1);
		Application.LoadLevel("gameover");
	}
}
