using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ImpactPause : MonoBehaviour
{

    bool waiting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Stop(float duration)
    {
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }
    
    IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
