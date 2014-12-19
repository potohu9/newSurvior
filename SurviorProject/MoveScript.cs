using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
public class MoveScript : MonoBehaviour {
	//float spd = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 vec = new Vector3 (CrossPlatformInputManager.GetAxis("Horizontal"),0,CrossPlatformInputManager.GetAxis("Vertical"));
		//transform.position += vec.normalized * spd;
	}
}