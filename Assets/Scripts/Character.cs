using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;


public class Character : MonoBehaviour
{
	Button btn;
	AudioSource audioSource;
	bool opened = false;
	void SetImage(string imageName)
	{
		Image image = GetComponent<Image>();
		Sprite sc = Resources.Load<Sprite>(imageName);
		image.sprite = sc;
	}
	
	void Awake(){
		audioSource =  GameObject.Find("Canvas").GetComponent<AudioSource>();
		btn = gameObject.GetComponent<Button>();
		
	}
	
    // Start is called before the first frame update
    void Start()
    {
		btn.onClick.AddListener(OnClick);
		var loadData = SaveLoad.Load();
		var values = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(loadData);
		if(values["opened"].Contains(this.name)){
			opened = true;
			SetImage("Unlocked/" + this.name);
		}
    }

	void OnClick()
	{
		audioSource.Play();
		if(opened){
			Vars.aboutChar = this.name;
			SceneManager.LoadScene("About");
		}
	}
	
	public void Back()
	{
		SceneManager.LoadScene("Menu");
	}
	
	
}
