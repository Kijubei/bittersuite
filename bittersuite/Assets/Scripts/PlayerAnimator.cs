using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {        
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.W))
        {
            animator.SetInteger("AnimPar", 1);
        }
        else
        {
            animator.SetInteger("AnimPar", 0);
        }
    }
}
