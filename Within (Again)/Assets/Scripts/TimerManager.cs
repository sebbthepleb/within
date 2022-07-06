using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;
    public float targetTime = 600.0f;
 
    void Update()
    { 
        targetTime -= Time.deltaTime;
 
        if (targetTime <= 0.0f)
        {
            flashlightTimerEnded();
        }

        if (targetTime <= 592f)
        {
            controlUITimerEnded();
        }
    }
 
    void flashlightTimerEnded()
    {
        myAudioSource.Play();

        GameObject [] GameObjectArray = GameObject.FindGameObjectsWithTag("FlashlightBulb");
        foreach(GameObject go in GameObjectArray)
        {
            go.SetActive (false);
        }
    }

    void controlUITimerEnded()
    {
        GameObject [] GameObjectArray = GameObject.FindGameObjectsWithTag("ControlUI");
        foreach(GameObject go in GameObjectArray)
        {
            go.SetActive (false);
        }
    }
}
