using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Vector3 pickPositionRightHand;
    public Vector3 pickRotationRightHand;

    public float flingPower = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToRightHand() {
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent = getRightArm();
        this.transform.localPosition = pickPositionRightHand;
        this.transform.localEulerAngles = pickRotationRightHand;
    }

    private Transform getRightArm() 
    {
        GameObject go = GameObject.Find("mixamorig:RightHand");
        return go.transform;
    }

    public void fling() {
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.parent = null;
    }

}
