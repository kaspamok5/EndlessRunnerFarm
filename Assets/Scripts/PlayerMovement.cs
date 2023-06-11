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
    public bool startedRunning = false;
    public bool hit = false;
    public GameObject startText;
    public GameObject endText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Difficulty());
        characterController = GetComponent<CharacterController>();
    }



    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (hit)
        {
            endText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (!startedRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startText.SetActive(false);
                startedRunning = true;
            }
            return;
        }

        vel.z = runningSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -runningSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            vel.x = runningSpeed;
        }
        else { vel.x = 0; }

        if (!Physics.Raycast(transform.position, Vector3.down, 1.2f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1.2f, Color.yellow);
            vel.y += -.4f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping /*Physics.Raycast(transform.position, Vector3.down, 1.2f)*/)
        {
            isJumping = true;
            vel.y = jumpForce;
        }

        rb.velocity = vel;

    }

    IEnumerator Difficulty()
    {
        yield return new WaitForSeconds(.5f);
        runningSpeed += .1f;
        StartCoroutine(Difficulty());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            rb.velocity = Vector3.zero;
            hit = true;
            startedRunning = false;
            rb.velocity = new Vector3(0, 5, -4);
            StartCoroutine(StopVelocity());
            transform.DORotate(new Vector3(0, 90, 90), 1);

        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            vel.y = 0;
        }
    }

    IEnumerator StopVelocity()
    {
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector3.zero;
        StartCoroutine(StopVelocity());
    }
}
