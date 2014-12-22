using UnityEngine;
using System.Collections;

public class PrefabMakerController : MonoBehaviour {

	public GameObject prefab;
	private GameObject target;
	public string targetTag;

	public float makeSpeed = 1;

	public Vector3[] posMargin;
	public Vector3[] lookObjAngleMargin;

	private int nowArray = 0;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag(targetTag);
		gameObject.GetComponent<Animator>().speed = makeSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void makePrefab(){
		if(nowArray < posMargin.Length && nowArray < lookObjAngleMargin.Length){
			GameObject instant_object = GameObject.Instantiate(prefab,gameObject.transform.position + posMargin[nowArray],Quaternion.identity) as GameObject;
			instant_object.transform.LookAt(target.transform.position);
			instant_object.transform.eulerAngles += lookObjAngleMargin[nowArray];
			nowArray ++;
		}
		else{
			deleatPrefabMaker();
		}
	}

	public void deleatPrefabMaker(){
		Destroy(gameObject);
	}
}
