using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
   void Start()
	{
		// Cek apakah kita sudah pernah save atau belum
		if (System.IO.File.Exists(SaveLoad.savePath) == false)
		{
			SaveData saveData = new SaveData() {opened=new List<string>()};
			string saveDataString = JsonUtility.ToJson(saveData);
			using (StreamWriter streamWriter = new StreamWriter(SaveLoad.savePath)){
				streamWriter.Write(saveDataString);
			};
		}
		if (System.IO.File.Exists(SaveLoad.sessionPath) == false)
		{
			SessionData session = new SessionData() {character=""};
			string saveDataString = JsonUtility.ToJson(session);
			using (StreamWriter streamWriter = new StreamWriter(SaveLoad.sessionPath)){
				streamWriter.Write(saveDataString);
			};
		}
		Invoke("MyFunction", 3);
		
	}
	void MyFunction()
	{
		SceneManager.LoadScene("Menu");
	}
}
