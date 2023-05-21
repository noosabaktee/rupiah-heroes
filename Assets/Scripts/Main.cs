using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{ 
	public void Close(){
		SceneManager.LoadScene("Menu");
	}
	
}
