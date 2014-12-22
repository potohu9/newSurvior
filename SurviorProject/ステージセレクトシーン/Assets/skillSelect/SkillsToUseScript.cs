using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillsToUseScript : MonoBehaviour {

	private SetSkillManagerScript script;
	private GameObject manager;

	public string imageName;
	private Image imageComponent;

	public Sprite sprite;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("SetSkill");
		script = manager.GetComponent<SetSkillManagerScript>();

		imageComponent = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
	}

	public void push(){
		//マネジャからスキル名を貰う
		imageName = script.setSukill;
		string skill1 = script.skill1;
		string skill2 = script.skill2;
		string skill3 = script.skill3;
		if(imageName!=skill1 && imageName!=skill2 && imageName!=skill3){
			//テクスチャ変更
			Texture2D texture = Resources.Load (imageName)as Texture2D;
			Sprite texture_sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), Vector2.zero);
			
			imageComponent.sprite = texture_sprite;
			
			//マネジャにセットされたスキル名を送る
			switch(name){
			case "Button1":
				script.skill1 = imageName;
				break;
			case "Button2":
				script.skill2 = imageName;
				break;
			case "Button3":
				script.skill3 = imageName;
				break;
			}
		}
	}
}
