using UnityEngine;
using System.Collections;

public class SkikkButtonScript : MonoBehaviour {

	public GameObject prefab;
	public GameObject target;

	// ボタンを押した際に呼ばれる関数
	public void Push()
	{

		// ボタンが押した際に出力
		print("Button Push!");

		//カメラとの距離.
		int camerakyori = 10;
		/*GameObject instant_object = (GameObject) GameObject.Instantiate(
			prefab,new Vector3(0,0,camerakyori),Quaternion.identity);*/
		GameObject instance = Instantiate (prefab, target.transform.position, Quaternion.identity) as GameObject;
		instance.transform.parent = target.transform;
		//GameObject.Destroy(instant_object,5);
		Destroy (instance, 5);
	}
}
