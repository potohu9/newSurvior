using UnityEngine;
using System.Collections;

public class SkillScript : MonoBehaviour {
	
	public string explanationText;				//説明文
	public GameObject invocationEffectPrefab;	//発動時エフェクト
	public GameObject runtimeEffectPrefab;		//発動中追従エフェクト
	public Sprite skillIconSprite;				//スキルアイコン用スプライト
	//public Sprite skillSelectIconSprite;		//スキル選択シーン用スプライト
	
	void Start () {
		//explanationText = 
		//	"sdrbvvxdfbh" + "\n" +
		//	"sfjdmgbxmxmrjixvgixg,x,boxlv0f,zb0od.voz0rb.y0zn0vzv";
		explanationText = name;

		switch(name){
		case "Attack_up":
			explanationText = "攻撃力アップ" + "\n" + 
							"攻撃力が＋5される" + "\n" + 
							"効果時間5秒" + "\n" + 
							"クールタイム10秒";
			break;
		case "Avoidance_up":
			explanationText = "bbbbbbbbbbbbbb" + "\n" + "fdsfffdsafsad";
			break;
		case "Speed_up":
			explanationText = "cccccccccccccccccb" + "\n" + "fdsfffdsafsad" + "\n" + "gsgagsdfsdfs";
			break;
		case "Deffens_up":
			explanationText = "dddddddddddddddddd" + "\n" + "fdsfffdsafsad" + "\n" + "fdsfkjsdlsl" + "\n" + "fklsjfsfjdslfjslfjafls";
			break;
		}
	}
	
	void Update () {
		
	}
	
	//スキル効果記述欄
	void skillEffect(GameObject targetObject){
		
	}
}
