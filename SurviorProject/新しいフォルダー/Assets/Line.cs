using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {

	private GameObject line;
	private static GameObject[] wall;
	private Vector3 initial;

	private float angle = 0;

	// Use this for initialization
	void Start () {
		line = GameObject.Find ("LineSign");

		wall = GameObject.FindGameObjectsWithTag ("Wall");
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 v0 = player.transform.position;
		Vector3 v1 = orz.transform.position;

		Vector3 pos = new Vector3((v0.x + v1.x) * 0.5f, ((v0.y + v1.y) * 0.5f) + 0.01f, (v0.z + v1.z) * 0.5f);
		Vector3 scale = new Vector3 (1, Mathf.Abs(v0.z - v1.z), 1);
		float rad = Mathf.Atan2 ((v1.x - v0.x), (v1.z - v0.z));

		GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Quad);

		temp.transform.position = pos;
		temp.transform.Rotate (90, 0, 0);
		temp.transform.Rotate (0, 0, -(rad * Mathf.Rad2Deg));
		temp.transform.localScale = scale;
		*/
	}

	public void Create(Vector3 initial, Vector3 target, int width) {
		RaycastHit hit;

		this.initial = initial;

		Vector3 nor = new Vector3(target.x - initial.x,
		                          target.y - initial.y,
		                          target.z - initial.z);

		Ray ray = new Ray (initial, nor.normalized);

		int length = wall.Length;

		for(int i = 0; i < length; i++) {
			Vector3 targetPos = wall[i].transform.position;

			//if(Physics.Raycast(orz.transform.position, target.transform.position, out hit, 100.0f)) {
			if(wall[i].collider.Raycast (ray, out hit, 100.0f)) {
				Vector3 pos = new Vector3((initial.x + hit.point.x) * 0.5f,
				                          (initial.y + hit.point.y) * 0.5f + 0.3f,
				                          (initial.z + hit.point.z) * 0.5f);
				Vector3 scale = new Vector3(width, Mathf.Abs (initial.z - hit.point.z), 1);

				float rad = Mathf.Atan2((hit.point.x - initial.x), (hit.point.z - initial.z));

				angle = rad * Mathf.Rad2Deg;

				GameObject obj = Instantiate (line, pos, Quaternion.Euler (90, 0, -angle)) as GameObject;
				obj.renderer.enabled = true;
				//obj.transform.Rotate (0, 0, -(rad * Mathf.Rad2Deg));
				obj.transform.localScale = scale;
				obj.renderer.material.mainTextureScale = new Vector2(1, Mathf.Abs (obj.transform.localScale.y) * 0.5f);

				// 後で整理
				Invoke ("attack", 2);
				Destroy (obj, 2);

				break;
			}
		}
	}

	void attack() {
		Vector3 pos = initial;
		GameObject temp;

		//temp = Instantiate (effects.transform.Find ("Eff_Burst_7").gameObject, pos, Quaternion.identity) as GameObject;
		temp = Instantiate (Resources.Load ("Particle/Prefab/Eff_Laser_2") as Object, pos, Quaternion.Euler(0, angle, 0)) as GameObject;
		temp.SetActive (true);
		
		//prefab.transform.localPosition = sign.transform.position;
		//Destroy (gameObject);
		Destroy (temp, 1);
	}
}
