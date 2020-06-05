using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : Activateable
{
    private bool isMovementNeeded = false;
    private Quaternion rotationDestination;
    private Quaternion startRotation;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startRotation =  this.gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovementNeeded)
        {
            moveDoor();
        }
    }
    
    override public void activate() 
    {
        openDoor(); 
    }

    override public void deactivate()
    {
        closeDoor();
    }

    private void openDoor()
    {
        isMovementNeeded = true;

        // Ka warum man das so machen muss ...
        rotationDestination = Quaternion.Euler( new Vector3(0,100,0) ) * startRotation ;
    }

    private void closeDoor()
    {
        isMovementNeeded = true;

        rotationDestination = Quaternion.Euler( new Vector3(0,0,0) ) * startRotation ;
    }

    private void moveDoor()
    {        
        this.gameObject.transform.rotation = Quaternion.RotateTowards(this.gameObject.transform.rotation, rotationDestination, 1);

        if (this.gameObject.transform.rotation == rotationDestination)
        {
            isMovementNeeded = false;
        }
    }
}
