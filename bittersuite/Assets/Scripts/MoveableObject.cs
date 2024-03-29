﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    // public Vector3 pickPosition;
    // public Vector3 pickRotation;
    [Tooltip("z.B. Rechte Hand - Hält die Sachen")]
    public Transform holdingObject;

    public Rigidbody rigidbodyObject;
    // Start is called before the first frame update
    void Start()
    {
        if (holdingObject == null || rigidbodyObject == null) // pickPosition == null || pickRotation == null || 
        {
            Debug.LogWarning("Not all public field are instanciated!", this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move() {
        this.transform.parent = holdingObject;
    }

    public void release()
    {
        this.transform.parent = null;
    }
}
