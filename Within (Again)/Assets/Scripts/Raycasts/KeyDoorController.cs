using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private bool doorOpen = false;
        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;
        [SerializeField] private KeyInventory _keyInventory = null;
        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void OpenDoorAndEndGame()
        {
            if(_keyInventory.hasKey)
            {
                OpenDoor();  
            }
            else
            {
                StartCoroutine(showDoorLocked());
            }
        }

        void OpenDoor()
        {
            if(!doorOpen && !pauseInteraction)
            {
                GameObject [] GameObjectArray = GameObject.FindGameObjectsWithTag ("EndUI");
                foreach(GameObject go in GameObjectArray)
                {
                    go.SetActive (true);
                }

                StartCoroutine(PauseDoorInteraction());
                    
                doorOpen = true;
                Time.timeScale = 0;
                AudioListener.pause = true;
            }
            else if(doorOpen && !pauseInteraction)
            {
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }

        IEnumerator showDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
        }
    }
}  