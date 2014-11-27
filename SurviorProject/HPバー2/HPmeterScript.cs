using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPmeterScript : MonoBehaviour {

	private Image image;
	public float hp;
	public float sirohp;

	private GameObject siro;
	private Image siroImage;

	// Use this for initialization
	void Start () {

		image = GetComponent<Image>();

		siro = GameObject.Find ("siroHP");
		siroImage = siro.GetComponent<Image>();
		hp = 100.0f;
		sirohp = hp;
	}

	// Update is called once per frame
	void Update () {
		//hp -= 0.1f;
		image.fillAmount = hp * 0.01f;

		siroImage.fillAmount = sirohp * 0.01f;

		if(hp < sirohp){
			sirohp -= 0.1f;
		} else if(hp>sirohp){
			sirohp = hp;
		}
	}
}
