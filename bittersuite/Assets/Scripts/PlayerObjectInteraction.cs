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
            tryToPickupObject();
        }

        if (Input.GetKeyDown(useObjectButton)) {
            if (hasObject) {
                // in Range
                    // Kombinierbar
                    // Aufmachbar
                    // Sonst
                // Sonst
                fling();
            } else {
                // in range
                    // aufmachbar
                        // verschlossen
                        // unverschlossen
                // Sonst
            }
             
        }

    }

    private void tryToPickupObject() {
        (GameObject, float) closestResult = searchClosestObjectAndDistance();
         if (closestResult.Item1 is null) { 
             return; 
        }
        GameObject closest = closestResult.Item1;
        float distance = closestResult.Item2;

        if (closest.tag == "SmallObject") {
            pickUpSmallObject(closest, distance);
        } else if (closest.tag == "BigObject") {

        }

    }

    // Findet das nähste gameobject aus der liste pickableGOList, oder null wenn out of range
    private (GameObject, float) searchClosestObjectAndDistance()
    {
        GameObject closestGameObject = null;
        float closestDistance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject currentGameObject in pickableGOList)
        {
            Vector3 diff = currentGameObject.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < closestDistance)
            {
                closestGameObject = currentGameObject;
                closestDistance = curDistance;
            }
        }
        return (closestGameObject, closestDistance);
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
