using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Vector3 pickPosition;
    public Vector3 pickRotation;
    [Tooltip("z.B. Rechte Hand - Hält die Sachen")]
    public Transform holdingObject;

    public Rigidbody rigidbodyObject;

    private Vector3 throwPosition = new Vector3(-0.4f, -0.3f, -0.3f);
    private bool applyForce = false;
    private bool isBreakable = false;
    private Vector3 flingDirection;
    private float flingPower;

    // Start is called before the first frame update
    void Start()
    {
        if (pickPosition == null || pickRotation == null || holdingObject == null || rigidbodyObject == null) {
            Debug.LogWarning("Not all public field are instanciated!", this);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (applyForce){
            applyForce = false;
            rigidbodyObject.AddForce(flingDirection * flingPower);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isBreakable) {
            isBreakable = false;
            this.GetComponent<Destroyable>().destory();
        }
    }

    public void pick() {
        Debug.Log("Picking " + this.name);
        rigidbodyObject.isKinematic = true;
        this.transform.parent = holdingObject;
        this.transform.localPosition = pickPosition;
        this.transform.localEulerAngles = pickRotation;
    }

    private void moveToThrowPosition() {
        this.transform.localPosition = throwPosition;
        this.transform.parent = null;
    }

    public void fling(Vector3 flingDirection, float power) {
        rigidbodyObject.isKinematic = false;
        this.moveToThrowPosition();
        this.flingDirection = flingDirection;
        this.flingPower = power;
        applyForce = true;
        if (this.GetComponent<Destroyable>()) {isBreakable = true;}
        
    }

}
