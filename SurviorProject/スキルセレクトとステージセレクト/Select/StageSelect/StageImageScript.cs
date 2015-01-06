using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageImageScript : MonoBehaviour {

	public string imageName;
	private SetStageManagerScript script;
	private GameObject manager;
	private Image imageComponent;
	
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("setStage");
		script = manager.GetComponent<SetStageManagerScript>();
		imageComponent = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(script.setStage!=null){
			//マネジャからスキル名を貰う
			imageName = script.setStage;
			
			//テクスチャ変更
			Texture2D texture = Resources.Load (imageName)as Texture2D;
			Sprite texture_sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), Vector2.zero);
			imageComponent.sprite = texture_sprite;
		}
	}
}
