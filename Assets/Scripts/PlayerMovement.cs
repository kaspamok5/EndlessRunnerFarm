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
        
        characterController = GetComponent<CharacterController>();
    }



    // Update is called once per frame
    void Update()
    {
        vel.z = runningSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -runningSpeed;
        } else if (Input.GetKey(KeyCode.D))
        {
            vel.x = runningSpeed;
        } else { vel.x = 0; }

        if (!Physics.Raycast(transform.position, Vector3.down, 1.2f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1.2f, Color.yellow);
            vel.y += -.2f;
            print("test");
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping /*Physics.Raycast(transform.position, Vector3.down, 1.2f)*/)
        {
            isJumping = true;
            vel.y = jumpForce;
        }

        rb.velocity = vel;



        ////transform.position = Vector3.forward * runningSpeed * Time.deltaTime;
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.AddForce(Vector3.left * runningSpeed);
        //    //transform.DOMoveZ(-2.7f, .5f);
        //    //currentLane--;
        //    //moveFinish = false;
        //    //StartCoroutine(StopTurning());
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    rb.AddForce(Vector3.right * runningSpeed);
        //    //transform.DOMoveZ(2.7f, .5f);
        //    //currentLane++;
        //    //moveFinish = false;
        //    //StartCoroutine(StopTurning());
        //}
        //if (!Physics.Raycast(transform.position, Vector3.down, 1.2f))
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1.2f, Color.yellow);
        //    vel += Vector3.down * .2f;
        //}
        ////if (Physics.Raycast(transform.position, Vector3.down, out var hit, 1.2f) && hit.Compare)
        ////{
        ////    rb.MoveRotation(Quaternion.Euler(0f, 0f, Vector2.Angle(Vector2.up, hit.normal)));
        ////}
        //if (Input.GetKeyDown(KeyCode.Space) && !isJumping /*Physics.Raycast(transform.position, Vector3.down, 1.2f)*/)
        //{
        //    isJumping = true;
        //    vel += Vector3.up * jumpForce;
        //}
        //transform.position = new Vector3( Mathf.Clamp(transform.position.x, -2.7f, 2.7f),transform.position.y,transform.position.z);
        //rb.velocity = vel;
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
