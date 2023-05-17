using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;


public class Card : MonoBehaviour
{	
	void Start(){
		// Cek apakah kita sudah pernah save atau belum
		if (System.IO.File.Exists(SaveLoad.savePath) == false)
		{
			SaveData saveData = new SaveData() {opened=new List<string>()};
			string saveDataString = JsonUtility.ToJson(saveData);
			using (StreamWriter streamWriter = new StreamWriter(SaveLoad.savePath)){
				streamWriter.Write(saveDataString);
			};
		}
	}
	
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0);
    }
	
	
	void OnMouseDown()
	{
		Vars.openChar = transform.parent.name;
		SceneManager.LoadScene("Open");
	}
	
}
