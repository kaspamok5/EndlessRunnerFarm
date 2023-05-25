using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    public float laneDistance = 2.5f;

    private Rigidbody rb;
    private int currentLane = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLane(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
         
    }

    void FixedUpdate()
    {
        rb.position = Vector3.MoveTowards(rb.position, new Vector3((currentLane - 1) * laneDistance, rb.position.y, rb.position.z + moveSpeed), moveSpeed * Time.deltaTime);
        //rb.DOMove(new Vector3((currentLane - 1) * laneDistance, 0, 1), moveSpeed);
    }

    void ChangeLane(int direction)
    {
        currentLane += direction;
        currentLane = Mathf.Clamp(currentLane, 0, 2);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
