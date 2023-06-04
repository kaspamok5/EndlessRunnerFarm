using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - 2.26f);
    }
}
