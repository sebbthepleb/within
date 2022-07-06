using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnLeaveSpawn : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            myAudioSource.Play();

            GameObject [] GameObjectArray = GameObject.FindGameObjectsWithTag ("SpawnAudioTrigger");
            foreach(GameObject go in GameObjectArray)
            {
                go.SetActive (false);
            }
        }
    }
}
