using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            loadEnding();
            stopAudio();
        }
    }

    void stopAudio()
    {
        GameObject [] GameObjectArray = GameObject.FindGameObjectsWithTag ("Audio");
        foreach(GameObject go in GameObjectArray)
        {
            go.SetActive (false);
        }
    }

    void loadEnding()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
