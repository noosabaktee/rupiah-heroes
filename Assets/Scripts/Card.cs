using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Card : MonoBehaviour
{	
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0);
    }
	
	
	void OnMouseDown()
	{
		SaveLoad.SaveSession(transform.parent.name);
		SceneManager.LoadScene("Open");
	}
}
