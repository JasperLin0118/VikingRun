using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    private CharacterController dragon;
    Vector3 destination = new Vector3(0, 0, -7.5f);
    void Start()
    {
        animator = GetComponent<Animator>();
        dragon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Viking.alive == false)
        {
            transform.localPosition = destination;
            animator.SetBool("isVikingDead", true);
        }
    }
}
