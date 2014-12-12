using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	private Vector3 pos;		// 位置
	private float count;		// カットインの経過時間

	public float speed = 0.0f;
	public bool flag = false;

	public GameObject pauseCanvasPrefab;
	private GameObject pauseCanvas;
	// Use this for initialization
	void Start () {

	}

	public void touched()
	{
		stopTime();
	}

	void stopTime(){
		if(flag == false){
			Time.timeScale = 0.0f;
			flag = true;
			pauseCanvas = GameObject.Instantiate(pauseCanvasPrefab,gameObject.transform.position,Quaternion.identity) as GameObject;
		}
		else{
			Time.timeScale = 1.0f;
			flag = false;
			Destroy(pauseCanvas);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
