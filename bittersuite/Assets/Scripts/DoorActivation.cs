﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : Activateable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    override public void activate() 
    {
        Debug.Log("Door Activated");
    }

    override public void deactivate()
    {
        Debug.Log("Door Deactivated");

    }
}
