using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash, isRunningHash, isWalkingBackHash, isJumpingHash;
    public float walkSpeed, runSpeed, backwardsSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingBackHash = Animator.StringToHash("isWalkingBack");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    void Update()
    {
        bool isWalking, isRunning, isWalkingBack, isJumping;

        if (Input.GetKey("w"))
        {
            animator.SetBool(isWalkingHash, true);
            isWalking = true;
            if (Input.GetKey("left shift"))
            {
                animator.SetBool(isRunningHash, true);
                isRunning = true;
            }
            else
            {
                animator.SetBool(isRunningHash, false);
                isRunning = false;
            }
        } else
        {
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isRunningHash, false);
            isWalking = false;
            isRunning = false;
        }

        if (Input.GetKey("s"))
        {
            animator.SetBool(isWalkingBackHash, true);
            isWalkingBack = true;
        } else
        {
            animator.SetBool(isWalkingBackHash, false);
            isWalkingBack = false;
        }

        if (Input.GetKey("space"))
        {
            animator.SetBool(isJumpingHash, true);
            isJumping = true;
        }
        else
        {
            animator.SetBool(isJumpingHash, false);
            isJumping = false;
        }

        // update position
        if (isRunning)
        {
            transform.position += Vector3.forward * runSpeed * Time.deltaTime;
        } else if (isWalking)
        {
            transform.position += Vector3.forward * walkSpeed * Time.deltaTime;
        } else if (isWalkingBack)
        {
            transform.position += Vector3.back * backwardsSpeed * Time.deltaTime;
        }
    }
}
