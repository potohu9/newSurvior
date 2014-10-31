using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour {

	public uint HP;
	public uint AT;
	public uint DF;
	public uint SP;
	Text atText;
	Text dfText;
	Text spText;

	// Use this for initialization
	void Start () {
		HP = 100;
		AT = 10;
		DF = 10;
		SP = 10;
		GameObject obj = GameObject.Find("ATText");
		atText = obj.GetComponent<Text>();
		obj = GameObject.Find("DFText");
		dfText = obj.GetComponent<Text>();
		obj = GameObject.Find("SPText");
		spText = obj.GetComponent<Text>();
	}

	void Update(){
		atText.text = "AT" + AT;
		dfText.text = "DF" + DF;
		spText.text = "SP" + SP;
	}
}
