using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectInteraction : MonoBehaviour
{
    private KeyCode pickUpButton = KeyCode.Mouse1;
    private KeyCode useObjectButton = KeyCode.Mouse0;
    private GameObject pickedSmallObject;
    private GameObject[] pickableGOList;
    private bool hasObject = false;
    [Tooltip("Range allowed to interact with objects")]
    public float range; 
    [Tooltip("power applied when throwing")]
    public float power; 
    // Start is called before the first frame update
    public Transform playerCameraDirection;
    void Start()
    {
        pickableGOList = GameObject.FindGameObjectsWithTag("SmallObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pickUpButton) && !hasObject) {

            (GameObject, float) closestResult = FindClosestObject();
            GameObject closest = closestResult.Item1;
            float distance = closestResult.Item2;

            if (closest.tag == "SmallObject") {
                pickUpSmallObject(closest, distance);
            } else if (closest.tag == "BigObject") {

            }
            
        }

        if (Input.GetKeyDown(useObjectButton) && hasObject) {
            fling(); 
        }

    }

    // Findet das nähste gameobject, dass mit dem tag "SmallObject" versehen ist
    private (GameObject, float) FindClosestObject()
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in pickableGOList)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return (closest, distance);
    }

    private void pickUpSmallObject(GameObject closestGO, float distance) {
        if ( distance <= range ) {
                hasObject = true;
                pickedSmallObject = closestGO;
                pickedSmallObject.GetComponent<PickableObject>().moveToRightHand();
            } else {
                print(distance);
            }
    }

    private void fling() {
        hasObject = false;
        pickedSmallObject.GetComponent<PickableObject>().fling(playerCameraDirection.forward, power);
    }

}
