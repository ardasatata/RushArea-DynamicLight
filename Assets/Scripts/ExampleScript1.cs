using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleScript1 : MonoBehaviour
{
	private static bool created = false;

	public int testingNum;

	void Awake()
	{
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
			Debug.Log("Awake: " + this.gameObject);
		}
	}

	public void LoadScene()
	{
		if (SceneManager.GetActiveScene().name == "scene1")
		{
			SceneManager.LoadScene("scene2", LoadSceneMode.Single);
		}
	}
}