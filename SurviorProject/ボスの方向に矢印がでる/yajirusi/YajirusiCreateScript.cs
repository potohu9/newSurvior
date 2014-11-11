using UnityEngine;
using System.Collections;

public class YajirusiCreateScript : MonoBehaviour {

	GameObject yajirusi;
	YajirusiScript1 script;
	// Use this for initialization
	void Start () {
		yajirusi = Instantiate(Resources.Load("Prefabs/yajirusi/Yajirusi"),new Vector3(0, 0.1f, 0),Quaternion.identity) as GameObject;
		
		script = yajirusi.GetComponent<YajirusiScript1> ();
		script.setTarget (this.name);
	}
	
	// Update is called once per frame
	void Update () {
		//float rand = Random.value;
		/*if(rand<=0.01){
			Object.Destroy(this.gameObject);
		}*/

	}

	void OnDestroy(){
		Object.Destroy(yajirusi);
	}
}
