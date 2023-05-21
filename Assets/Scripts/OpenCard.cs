using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenCard : MonoBehaviour
{
	public GameObject button;
	public GameObject tapText;
	public GameObject confetti1;
	public GameObject confetti2;
	public Vector3 targetPosition;
	public Vector3 backPosition;
	public GameObject Base,Light,Vertical;
	public float speed=10;
	bool clicked = false;
	bool opened = false;
	bool exist = false;
	bool boomPlayed = false;
	bool hoorayPlayed = false;
	bool shaked = false;
	AudioSource audioSource;
	AudioClip whoosh, boom;
	string openChar;
	// Audio hooray dipisah karena, jika menggunakan audio ini kecepatannya beda karena ini dipercepat saat "Boom"
	public AudioSource hooray, click;
	List<string> newData = new List<string>();
	
	void Awake(){
		audioSource = gameObject.GetComponent<AudioSource>();
		whoosh = Resources.Load<AudioClip>("Audio/Whoosh");
		boom = Resources.Load<AudioClip>("Audio/Boom");
	}
	
	public void SetTexture(string textureName)
	{
		Texture tex = Resources.Load(textureName, typeof(Texture)) as Texture;
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.SetTexture("_MainTex", tex);
	}
	
    // Start is called before the first frame update
    void Start()
    {
		openChar = JsonConvert.DeserializeObject<Dictionary<string, string>>(SaveLoad.LoadSession())["character"];
		var loadData = SaveLoad.Load();
		var values = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(loadData);
		foreach(string v in values["opened"]){
			newData.Add(v);
		}
		
		// Cek apakah sudah ada atau belum
		if(values["opened"].Contains(openChar)){
			exist = true;
		}
		
		// Tampilkan "Tap to open" jika belum ada atau jika belum dibuka
		if((transform.position.y == 2 && !clicked) || !exist){
			tapText.SetActive(true);
		}else{
			button.SetActive(true);
		}
		
		// Jika sudah ada langsung ganti skin aja dan berputar
		if(exist){
			SetTexture("Unlocked/" + openChar);
			transform.Rotate(0, 0.5f, 0);
		}
    }

    // Update is called once per frame
    void Update()
    {
		
		// Jika kartu sudah keatas lagi, maka ganti texture dan turun lagi
		if(transform.position.y == 10 && clicked){
			ShowEffect();
			Invoke("Turun", 2f);
			SetTexture("Unlocked/" + openChar);
			opened = true;
		}
		// Jika sudah terbuka maka berputar 
		if((transform.position.y == 2 && opened) || exist){
			transform.Rotate(0, 0.5f, 0);
			// jika baru terbuka (sebelumya belum terbuka) maka rayakan
			if(!exist){
				if (!shaked){
					CinemachineShake.Instance.ShakeCamera(5f,.5f);
					shaked = true;
				}
				if(!hoorayPlayed){
					hooray.Play();
					hoorayPlayed = true;
				}
				confetti1.SetActive(true);
				confetti2.SetActive(true);
				Invoke("ShowButton", 2f);
			}
		}
		
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime * 2);
    }
	
	void OnMouseDown()
	{
		// Jika sudah ada tidak bisa diklik
		if(!exist){
			tapText.SetActive(false);
			clicked = true;
			Vertical.SetActive(true);
			Invoke("GoUp", 2f);
		}
	}
	
	public void Next(){
		if(exist){
			// Jika character sudah ada
			SaveLoad.SaveSession(openChar);
			SceneManager.LoadScene("About");
		}else{
			// Jika character belum ada
			SaveLoad.SaveSession(openChar);
			newData.Add(openChar);
			SaveLoad.Save(newData);
			SceneManager.LoadScene("About");
		}
		click.Play();
	}
	
	void Turun(){
		if(!boomPlayed){
			// Percepat audio karena sound ini agak lambat
			audioSource.pitch = 2f;
			audioSource.PlayOneShot(boom, 0.3f);
			boomPlayed = true;
		}
		targetPosition = new Vector3(0,2,0);
	}
	
	void GoUp(){
		// Naikkan lagi kartu untuk membuka
		targetPosition = new Vector3(0,10,0);
		audioSource.PlayOneShot(whoosh, 1.3f);
	}
	
	void ShowEffect(){
		Base.SetActive(true);
		Light.SetActive(true);
		Vertical.SetActive(false);
	}
	
	void ShowButton(){
		button.SetActive(true);
	}
	
	
}
