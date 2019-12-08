using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Vector3 pickPositionRightHand;
    public Vector3 pickRotationRightHand;

    public float flingPower = 3;
    //public Rigidbody rigidbody;

    private Vector3 throwPosition = new Vector3(-0.4f, -0.3f, -0.3f);
    private bool applyForce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (applyForce){
            applyForce = false;
            rigidbody.AddForce(flingDirection * power);

        }
    }

    public void moveToRightHand() {
        rigidbody.isKinematic = true;
        this.transform.parent = getRightArm();
        this.transform.localPosition = pickPositionRightHand;
        this.transform.localEulerAngles = pickRotationRightHand;
    }

    private void moveToThrowPosition() {
        this.transform.localPosition = throwPosition;
        this.transform.parent = null;
    }

    private Transform getRightArm() 
    {
        GameObject go = GameObject.Find("mixamorig:RightHand");
        return go.transform;
    }

    public void fling(Vector3 flingDirection, float power) {
        rigidbody.isKinematic = false;
        // Move to Throw position
        this.moveToThrowPosition();
        applyForce = true;
    }

}
