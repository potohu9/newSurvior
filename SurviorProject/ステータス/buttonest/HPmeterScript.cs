using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPmeterScript : MonoBehaviour {

	Image image;
	GameObject obj;
	PlayerStatus script;


	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		obj = GameObject.Find("unitychan");
		script = obj.GetComponent<PlayerStatus> ();
	}

	// Update is called once per frame
	void Update () {
		float hp = (script.HP) * 0.01f;
		image.fillAmount = hp;
	}
}
