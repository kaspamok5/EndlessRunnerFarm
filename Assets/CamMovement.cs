using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float speed = 5;

    private void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
}
