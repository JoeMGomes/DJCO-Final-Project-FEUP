using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private IEnumerator coroutine;
    private IEnumerator soundCoroutine;
    private bool eventScheduled = false;
    // Start is called before the first frame update
    [FMODUnity.EventRef]
    public string flickerSound = "event:/FX/Blown_Fuse_Light";
    FMOD.Studio.EventInstance flickerEvent;



    void Start()
    {
        flickerEvent = FMODUnity.RuntimeManager.CreateInstance(flickerSound);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(flickerEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
    // Update is called once per frame
    void Update()
    {
        if (!eventScheduled)
        {
            coroutine = flicker();

            StartCoroutine(coroutine);
        }
    }

    private IEnumerator playSound(){
        flickerEvent.start();
        yield return new WaitForSeconds(5f);
        flickerEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private IEnumerator flicker()
    {
        soundCoroutine = playSound();
        eventScheduled = true;
        StartCoroutine(soundCoroutine);
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<Light>().enabled = false;
        float timeDelay = Random.Range(0.1f, 0.15f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.3f, 0.5f);        
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.1f, 0.15f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(2f, 10f);
        yield return new WaitForSeconds(timeDelay);
   
        eventScheduled = false;
    }
}
