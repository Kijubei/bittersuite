using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {        
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.W))
        {
            anim.SetInteger("AnimPar", 1);
        }
        else
        {
            anim.SetInteger("AnimPar", 0);
        }
    }
}
