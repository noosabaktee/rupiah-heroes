using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
	public static string savePath = Application.persistentDataPath + "/saveData.json";

    public static void Save(List<string> data)
	{
		SaveData saveData = new SaveData() {opened=data};
		string saveDataString = JsonUtility.ToJson(saveData);
		using (StreamWriter streamWriter = new StreamWriter(savePath)){
			streamWriter.Write(saveDataString);
		}
		print(saveDataString);
	}
	
	public static string Load()
	{
		string savedDataString = "";
		using (StreamReader streamReader = new StreamReader(savePath)){
			savedDataString = streamReader.ReadToEnd();
		}
		return savedDataString;
	}
	
	public static string LoadHero(){
		string savedDataString = "";
		using (StreamReader streamReader = new StreamReader("Assets/Scripts/pahlawan.json")){
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
