using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Transform pauseMenu;
    public Transform crosshairUI;
    public Transform Player;
    [SerializeField] bool lockCursor = true;

    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
        crosshairUI.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.gameObject.SetActive(true);
                crosshairUI.gameObject.SetActive(false);

                Time.timeScale = 0;
                AudioListener.pause = true;

                Player.GetComponent<CharacterController>().enabled = false;

                if(lockCursor)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }   
            }
            else
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
    }
}