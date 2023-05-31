using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float runningSpeed = 8;
    private Vector3 vel;
    public bool isJumping = false;
    public float jumpForce = 2;
    private int currentLane = 0; // middle lane
    private CharacterController characterController;
    private bool moveFinish = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vel = Vector3.forward * runningSpeed;
        characterController = GetComponent<CharacterController>();
    }



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A) && currentLane > -1 && moveFinish)
        {
            vel += Vector3.left * runningSpeed;
            currentLane--;
            moveFinish = false;
            StartCoroutine(StopTurning());
        }
        if (Input.GetKeyDown(KeyCode.D) && currentLane < 1 && moveFinish)
        {
            vel += Vector3.right * runningSpeed;
            currentLane++;
            moveFinish = false;
            StartCoroutine(StopTurning());
        }
        if (!Physics.Raycast(transform.position, Vector3.down, out var hit, 1.2f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            vel += Vector3.down * .2f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping /*Physics.Raycast(transform.position, Vector3.down, 1.2f)*/)
        {
            isJumping = true;
            vel += Vector3.up * jumpForce;
        }
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, -2.7f, 2.7f),transform.position.y,transform.position.z);
        rb.velocity = vel;
    }

    IEnumerator StopTurning()
    {
        yield return new WaitForSeconds(((runningSpeed / 2.7f) - 2.7f) - 0.01f);
        print("done");
        vel = Vector3.forward * runningSpeed;
        moveFinish = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            vel.y = 0;
        }
    }
}
