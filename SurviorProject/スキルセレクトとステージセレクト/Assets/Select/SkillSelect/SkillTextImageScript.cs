using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTextImageScript : MonoBehaviour {

	public string imageName;
	private SetSkillManagerScript script;
	private GameObject manager;
	private Image imageComponent;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("SetSkill");
		script = manager.GetComponent<SetSkillManagerScript>();
		imageComponent = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(script.setSukill!=null){
			//マネジャからスキル名を貰う
			imageName = script.setSukill;

			//テクスチャ変更
			Texture2D texture = Resources.Load (imageName)as Texture2D;
			Sprite texture_sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), Vector2.zero);
			imageComponent.sprite = texture_sprite;
		}
	}
}
