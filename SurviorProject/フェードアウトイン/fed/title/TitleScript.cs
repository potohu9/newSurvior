using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	void Start () {
		FadeSwitch.IsFadeIn = true;
	}
	public void nextScene(){
		FadeSwitch.IsFadeIn = false;
		StartCoroutine("hyouji");
	}

	IEnumerator hyouji(){
		yield return new WaitForSeconds (1);
		Application.LoadLevel("test");
	}
}
