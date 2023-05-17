using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
   void Start()
	{
		Invoke("MyFunction", 3);
	}
	void MyFunction()
	{
		SceneManager.LoadScene("Menu");
	}
}
