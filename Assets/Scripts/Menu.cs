using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AudioSource audioSource;
	AudioClip click;
	
	void Awake(){
		audioSource = gameObject.GetComponent<AudioSource>();
		click = Resources.Load<AudioClip>("Audio/Click");
	}
	public void Play(){
		audioSource.PlayOneShot(click);
		SceneManager.LoadScene("Main");
	}
	
	public void Character(){
		audioSource.PlayOneShot(click);
		SceneManager.LoadScene("Character");
	}
	
	public void Quit(){
		audioSource.PlayOneShot(click);
		 Application.Quit();
	}
}
