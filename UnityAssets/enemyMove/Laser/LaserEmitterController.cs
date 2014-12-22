using UnityEngine;
using System.Collections;

public class LaserEmitterController : MonoBehaviour {

	public GameObject attackPrefab;
	public GameObject signPrefab;
	public GameObject shotShockPrefab;
	private GameObject emitter;

	public float signWidth = 1.0f;

	private GameObject signObject;

	private static GameObject[] wall;

	private Animation signAnim;

	public string wallTag = "Wall";
	public string signName = "sign";

	private bool isCreate = false;

	// Use this for initialization
	void Start () {
		emitter = gameObject;
		wall = GameObject.FindGameObjectsWithTag (wallTag);
		Vector3 targetPos = gameObject.transform.position + gameObject.transform.forward;
		targetPos.y = gameObject.transform.position.y;
		createSign(emitter.transform.position,targetPos,signWidth);
	}
	
	// Update is called once per frame
	void Update () {
		if(isCreate){
			if(!signAnim.isPlaying){
				finishSign();
			}
		}
	}

	void finishSign(){
		GameObject instant_object = GameObject.Instantiate(attackPrefab,emitter.transform.position,Quaternion.identity) as GameObject;
		instant_object.transform.Rotate(emitter.transform.eulerAngles);
		GameObject instant_object2 = GameObject.Instantiate(shotShockPrefab,emitter.transform.position,Quaternion.identity) as GameObject;
		instant_object2.transform.Rotate(emitter.transform.eulerAngles + new Vector3(0,180,0));
		Destroy(signObject);
		Destroy(gameObject);
	}

	public void createSign(Vector3 initial, Vector3 target, float width) {
		RaycastHit hit;
		
		Vector3 nor = new Vector3(target.x - initial.x,
		                          target.y - initial.y,
		                          target.z - initial.z);
		
		Ray ray = new Ray (initial, nor.normalized);
		
		int length = wall.Length;
		
		for(int i = 0; i < length; i++) {
			Vector3 targetPos = wall[i].transform.position;

			if(wall[i].collider.Raycast (ray, out hit, 500.0f)) {
				Vector3 pos = new Vector3((initial.x + hit.point.x) * 0.5f,
				                          0.01f,
				                          (initial.z + hit.point.z) * 0.5f);

				Vector2 v0 = new Vector2(initial.x, initial.z);
				Vector2 v1 = new Vector2(hit.point.x, hit.point.z);

				Vector3 scale = new Vector3(width, Vector2.Distance (v0, v1), 1);
				
				float rad = Mathf.Atan2((hit.point.x - initial.x), (hit.point.z - initial.z));
				
				float angle = rad * Mathf.Rad2Deg;
				
				signObject = Instantiate (signPrefab, pos, Quaternion.Euler (90, 0, -angle)) as GameObject;

				GameObject sign = signObject.transform.FindChild(signName).gameObject;

				sign.renderer.enabled = true;
				sign.transform.localScale = scale;
				sign.renderer.material.mainTextureScale = new Vector2(1, Mathf.Abs (sign.transform.localScale.y) * 0.5f);

				signAnim = signObject.GetComponent<Animation>();

				gameObject.transform.LookAt(target);

				isCreate = true;

				break;
			}
		}
	}
}
