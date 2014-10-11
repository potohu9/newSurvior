using UnityEngine;
using System.Collections;

public class PSScript : MonoBehaviour {
	void LateUpdate (){
		//このゲームオブジェクトのパーティクルが生存しているかどうか.
		if(!particleSystem.IsAlive()){
			Destroy (gameObject);
		}
	}	
}
