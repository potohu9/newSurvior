/**
 * SoundManager 暫定版
 * 
 * オブジェクトのタグをSoundManagerにしてこのスクリプトをぶっぱ
 * シングルトンなのでどのスクリプトからでもアクセスできるはず
 */ 

using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private static SoundManager instance;	// Instance
	
	// AudioSource
	private AudioSource bgmSource;	// BGM
	private AudioSource seSource;	// SE

	// AudioClip
	public AudioClip[] bgmClip;
	public AudioClip[] seClip;
	
	public static SoundManager getInstance {
		get {
			if(instance == null) {
				instance = FindObjectOfType <SoundManager>() as SoundManager;
			}

			return instance;
		}
	}
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		// Add Component
		bgmSource = gameObject.AddComponent<AudioSource> ();
		seSource  = gameObject.AddComponent<AudioSource> ();
	}

	/**
	 * BGM
	 */

	public void playBGM() {
		if (bgmSource != null) {
			bgmSource.Play ();		
		}
	}
	
	public void playBGM(int index) {
		if (0 > index || bgmClip.Length < index) {
			return;
		}

		if (bgmSource != null) {
			bgmSource.Stop ();
		}
		bgmSource.clip = bgmClip [index];
		bgmSource.Play ();
	}

	public void pauseBGM() {
		bgmSource.Pause ();
	}

	public void stopBGM() {
		bgmSource.Stop ();
		bgmSource.clip = null;
	}

	/**
	 * SE
	 */

	public void playSE(int index) {
		if (0 > index || seClip.Length < index) {
			return;
		}

		if (seSource != null) {
			seSource.Stop ();
		}
		seSource.clip = seClip [index];
		seSource.Play ();
	}

	public void pauseSE() {
		seSource.Pause ();
	}

	public void stopSE() {
		seSource.Stop ();
		seSource.clip = null;
	}


}
