using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;

	public void OnQuitButtonClickMainMenu()
    {
        Application.Quit();
		Debug.LogError("Application quit called through Main Menu.");
	}

	public void OnPlayButtonClick()
    {
        myAudioSource.Stop();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
}
