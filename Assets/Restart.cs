using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	Button btn;
	private void Start()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(RestartScene);
	}
	void RestartScene() 
	{
		
		SceneManager.LoadScene("Farm");
		
	}

}
