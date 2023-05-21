using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
	public static string savePath = Application.persistentDataPath + "/saveData.json";
	public static string sessionPath = Application.persistentDataPath + "/session.json";
	public static string heroesPath = Application.streamingAssetsPath + "/pahlawan.json";

    public static void Save(List<string> data)
	{
		SaveData saveData = new SaveData() {opened=data};
		string saveDataString = JsonUtility.ToJson(saveData);
		using (StreamWriter streamWriter = new StreamWriter(savePath)){
			streamWriter.Write(saveDataString);
		}
	}
	
	public static string Load()
	{
		string savedDataString = "";
		using (StreamReader streamReader = new StreamReader(savePath)){
			savedDataString = streamReader.ReadToEnd();
		}
		return savedDataString;
	}

	public static void SaveSession(string data)
	{
		SessionData session = new SessionData() {character=data};
		string saveDataString = JsonUtility.ToJson(session);
		using (StreamWriter streamWriter = new StreamWriter(sessionPath)){
			streamWriter.Write(saveDataString);
		}
	}
	
	public static string LoadSession()
	{
		string savedDataString = "";
		using (StreamReader streamReader = new StreamReader(sessionPath)){
			savedDataString = streamReader.ReadToEnd();
		}
		return savedDataString;
	}
	
	public static string LoadHero()
	{
		string savedDataString = "";
		using (StreamReader streamReader = new StreamReader(heroesPath)){
			savedDataString = streamReader.ReadToEnd();
		}
		return savedDataString;
	}

}

[System.Serializable]
public class SaveData
{
    public List<string> opened;
}


[System.Serializable]
public class SessionData
{
    public string character;
}



