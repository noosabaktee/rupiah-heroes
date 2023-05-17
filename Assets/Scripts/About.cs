using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour
{
	
	public GameObject AboutHeight;
	public GameObject Panel;
	public GameObject Photo;
	
	float about_height;
	float panel_height;
	
	public Text Name, As, Aka, Born, Died, Gender, Ascension, AboutText;
    // Start is called before the first frame update
	
	void SetImage(string imageName)
	{
		Image image = Photo.GetComponent<Image>();
		Sprite sc = Resources.Load<Sprite>(imageName);
		image.sprite = sc;
	}
	
    void Start()
    {
		
		// Tampilkan data 
		var loadData = SaveLoad.LoadHero();
		var values = JsonConvert.DeserializeObject<object>(loadData);
		var heroes = JObject.FromObject(values).ToObject<Dictionary<string, object>>();
		var hero = JObject.FromObject(heroes[Vars.aboutChar]).ToObject<Dictionary<string, object>>();
		
		// Set value text
		SetImage("About/" + Vars.aboutChar);
		Name.text = hero["name"].ToString();
		As.text = hero["as"].ToString();
		Aka.text = hero["aka"].ToString();
		Born.text = hero["born"].ToString();
		Died.text = hero["died"].ToString();
		Gender.text = hero["gender"].ToString();
		Ascension.text = hero["ascension"].ToString();
		AboutText.text = hero["about"].ToString();
		
		about_height = AboutHeight.GetComponent<Text>().preferredHeight;
		RectTransform rt_panel = Panel.GetComponent<RectTransform>();
		// Ubah tinggi panel -> tinggi panel + tinggi about text 
		rt_panel.sizeDelta = new Vector2(1080, rt_panel.rect.height + about_height);	
		
    }
	
	public void Close(){
		SceneManager.LoadScene("Character");
	}

}
