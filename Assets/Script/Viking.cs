using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : MonoBehaviour
{
    public Animator animator;
    private Vector3 move;
    private bool isGrounded = true;
    [Header("Turn")]
    public bool isTurning = false;
    public float turningRate = 0.2f;
    private Quaternion startrotate, endrotate;
    private float turningTime = 0;
    private float turningDuration;
    

    // Start is called before the first frame update
    void Start()
    {
        turningDuration = 1 / turningRate;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurning)
        {
            turningTime += turningDuration * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startrotate, endrotate, turningTime);
            if (turningDuration > 1.0f) // correction
            {
                transform.rotation = Quaternion.Slerp(startrotate, endrotate, 1);
                isTurning = false;
            }
        }
        else
            turningTime = 0f;
        if(Input.GetKey(KeyCode.Space) && isGrounded) //jump
        {
            gameObject.GetComponent<Rigidbody>().AddForce(300 * Vector3.up);
            isGrounded = false;
        }
        if(Input.GetKey(KeyCode.W)) //forward
        {
            animator.SetBool("isRunning", true);
            move = 4 * Vector3.forward * Time.deltaTime;
        }
        else
        {
            animator.SetBool("isRunning", false);
            move = Vector3.zero;
        }
        if(Input.GetKeyDown(KeyCode.D) && !isTurning) //right
        {
            TurningDirection(false);
            isTurning = true;
        }
        else if(Input.GetKeyDown(KeyCode.A) && !isTurning) //left
        {
            TurningDirection(true);
            isTurning = true;
        }
        transform.Translate(move);
    }
    void TurningDirection(bool left_or_right)
    {
        Vector3 degree;
        if (left_or_right) //left
            degree = new Vector3(0, -90, 0);
        else //right
            degree = new Vector3(0, 90, 0);
        startrotate = transform.rotation;
        endrotate = startrotate * Quaternion.Euler(degree);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
    }
}
