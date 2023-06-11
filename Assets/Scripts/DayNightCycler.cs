using System;
using UnityEngine;


public class DayNightCycler : MonoBehaviour
{
    private Camera cam;
    public Gradient gradient;
    public float dayLength = 10;
    public float currentTime;
    
    
    private void Start()
    {
        cam = Camera.main;
    }

    private void OnValidate()
    {
        Start();
        Update();
    }

    private void Update()
    {
        if(Application.isPlaying)currentTime += Time.deltaTime;
        
        var ratio = currentTime / dayLength;
        if (ratio > 1) currentTime = 0;
        Camera.main.backgroundColor = gradient.Evaluate(ratio);
        
        transform.rotation = Quaternion.Euler(ratio * 360,0,0);
        
        // make fog color match background color
        RenderSettings.fogColor = cam.backgroundColor;
    }
}
