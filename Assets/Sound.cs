using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public GameObject player;
    public AudioClip running;
    public AudioClip carCrash;
    public AudioClip runningLoop;
    private PlayerMovement thePlayer;
    public bool oneUse = true;
    public bool oneUse2 = true;
    public bool oneUse3 = true;
    void Start()
    {
        source = GetComponent<AudioSource>();
        thePlayer = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying && !oneUse && oneUse3 && !thePlayer.hit)
        {
            source.clip = runningLoop;
            source.loop = true;
            source.Play();
            oneUse3 = false;
        }
        if (thePlayer.hit && oneUse2)
        {
            source.Stop();
            source.PlayOneShot(carCrash);
            oneUse2 = false;
        }
        if (thePlayer.startedRunning && oneUse)
        {
            source.loop = false;
            source.clip = running;
            source.Play();
            
            //source.clip = runningLoop;
            oneUse = false;
            print("hi");
        }
        
    }

    //IEnumerator PlayLoop ()
    //{
    //    yield return new WaitForSeconds(running.length);
    //    source.clip = runningLoop;
    //    source.Pl
    //}
}
