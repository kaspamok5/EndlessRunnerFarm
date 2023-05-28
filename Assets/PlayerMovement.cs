using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float runningSpeed = 8;
    private Vector3 vel;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vel = Vector3.forward * runningSpeed;
    }



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            vel += Vector3.left * runningSpeed;
            StartCoroutine(StopTurning());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            vel += Vector3.right * runningSpeed;
            StartCoroutine(StopTurning());
        }
        /*if (!Physics.Raycast(transform.position, Vector3.down, out var hit, 1.05f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            vel += Vector3.down;
        }*/
        rb.velocity = vel;
    }

    IEnumerator StopTurning()
    {
        yield return new WaitForSeconds(.35f);
        print("done");
        vel = Vector3.forward * runningSpeed;
    }
}
