using UnityEngine;
using System.Collections;

public class SkillFactory {
	
	public static Skill getSkill(string className) {
		switch (className) {
		case "AttUp":
			MonoBehaviour.print ("hey");
			return new AttUp();
			break;

		case "DefUp":
			return new DefUp();
			break;

		case "SpdUp":
			return new AttUp();
			break;
		}

		return null;
	}
}
