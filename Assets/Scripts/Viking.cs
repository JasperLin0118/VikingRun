using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Viking : MonoBehaviour
{
    private Animator animator;
    private Vector3 move, horizontalMove;
    private bool isGrounded = true;

    [Header("Turn")]
    public bool isTurning = false;
    public float turningRate = 0.5f;
    private Quaternion startrotate, endrotate;
    private float turningTime = 0;
    private float turningDuration;
    private bool alive = true;
    float horizontalInput;
    public Canvas pause;


    // Start is called before the first frame update
    void Start()
    {
        turningDuration = 1 / turningRate;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) return; //dead, don't do anything

        if (transform.position.y < -4) Invoke("Die", 1);//fall underground

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pause.enabled = true;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded) //jump
        {
            gameObject.GetComponent<Rigidbody>().AddForce(7 * Vector3.up, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.W)) //forward
        {
            animator.SetBool("isRunning", true);
            move = 8 * transform.forward * Time.deltaTime;
        }
        else
        {
            animator.SetBool("isRunning", false);
            move = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.E) && !isTurning) //right turn
        {
            TurningDirection(false);
            isTurning = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !isTurning) //left turn
        {
            TurningDirection(true);
            isTurning = true;
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");
        horizontalMove = 7 * transform.right * horizontalInput * Time.deltaTime;
        transform.Translate(move + horizontalMove, Space.World);
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
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Bridge"))
            isGrounded = true;
        if (collision.collider.CompareTag("Obstacle"))
        {
            alive = false;
            animator.SetBool("isDead", true);
            Invoke("Die", 1.5f);
        }
    }
    void Die()
    {
        GameManager.inst.Gameover();
    }
}
