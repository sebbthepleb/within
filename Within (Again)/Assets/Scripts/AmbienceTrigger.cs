using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource;
    public float targetTime = 300.0f;

    // Update is called once per frame
    void Update()
    { 
        targetTime -= Time.deltaTime;
 
        if (targetTime <= 0f)
        {
            ambienceTimerEnded();
        }
    }

    void ambienceTimerEnded()
    {
        myAudioSource.Play();
    }
}
