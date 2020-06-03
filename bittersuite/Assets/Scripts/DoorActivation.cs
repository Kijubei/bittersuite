using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : Activateable
{
    private bool isMovementNeeded = false;
    private Quaternion rotationDestination;
    private int moveRadius = 0;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("Door Activated");
        openDoor();
    }

    override public void deactivate()
    {
        Debug.Log("Door Deactivated");
        closeDoor();
    }

    private void openDoor()
    {
        isMovementNeeded = true;

        Quaternion startRotation = this.gameObject.transform.rotation ;
        rotationDestination = Quaternion.Euler( new Vector3(0,100,0) ) * startRotation ;
    }

    private void closeDoor()
    {
        isMovementNeeded = true;

        Quaternion startRotation = this.gameObject.transform.rotation ;
        rotationDestination = Quaternion.Euler( new Vector3(0,0,0) ) * startRotation ;
    }

    private void moveDoor()
    {
        float delta = moveSpeed * Time.deltaTime;

        Quaternion currentRotation = this.gameObject.transform.rotation;

        currentRotation = Quaternion.Lerp( currentRotation, rotationDestination, delta );    
        
        if (currentRotation == rotationDestination)
        {
            isMovementNeeded = false;
        }
    }
}
