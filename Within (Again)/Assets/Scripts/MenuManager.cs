using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	public Transform pauseMenu;
    public Transform crosshairUI;
    public Transform Player;
    [SerializeField] bool lockCursor = true;

    void Awake()
    {
        GameObject [] GameObjectArray = GameObject.FindGameObjectsWithTag ("UIDoorLocked");
        foreach(GameObject go in GameObjectArray)
        {
            go.SetActive (false);
        }
    }

	public void OnQuitButtonClick()
    {
        Application.Quit();
		Debug.LogError("Application quit called through Pause Menu.");
	}

	public void OnResumeButtonClicked()
	{
		pauseMenu.gameObject.SetActive(false);
        crosshairUI.gameObject.SetActive(true);

        Time.timeScale = 1;
        AudioListener.pause = false;

        Player.GetComponent<CharacterController>().enabled = true;

        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } 
	}
}
