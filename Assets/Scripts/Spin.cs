using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);
    }
}
