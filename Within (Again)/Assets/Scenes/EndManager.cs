using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;

    public void Awake()
    {
        myAudioSource.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

	public void OnQuitButtonClick()
    {
        Application.Quit();
		Debug.LogError("Application quit called through Endscreen.");
	}
}
