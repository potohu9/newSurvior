using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContentsSizeScript : MonoBehaviour {

	public int childNum;
	public int childNumLine;

	// Use this for initialization
	void Start () {
		childNum = transform.childCount;
		childNumLine = childNum / 3;

		RectTransform rectTrans = GetComponent <RectTransform>();
		if(childNumLine-5 > 0){
			if(childNum % 3 > 0){childNumLine++;}
			rectTrans.sizeDelta = new Vector2 (0, (childNumLine-5)*120);

			//スクロールバーの位置調整
			GameObject scrollbar = GameObject.Find("Scrollbar");
			Scrollbar scrollBar = scrollbar.GetComponent<Scrollbar>();
			scrollBar.value = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
