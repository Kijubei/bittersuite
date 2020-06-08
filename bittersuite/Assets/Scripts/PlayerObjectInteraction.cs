using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerObjectInteraction : MonoBehaviour
{
    private KeyCode pickUpButton = KeyCode.Mouse0;
    private KeyCode useObjectButton = KeyCode.Mouse1;
    private GameObject pickedObject;
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
        GameObject[] smallObjectList = GameObject.FindGameObjectsWithTag("SmallObject");
        GameObject[] bigObjectList = GameObject.FindGameObjectsWithTag("BigObject");
        // pickableGOList = new GameObject[smallObjectList.Length + bigObjectList.Length];

        pickableGOList = smallObjectList.Concat(bigObjectList).ToArray();
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
                useObject();
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
        GameObject closestObject = searchClosestObjectInDistance();
         if (closestObject is null) { 
             return; 
        }

        if (closestObject.tag == "SmallObject") {
            pickUpSmallObject(closestObject);
        } else if (closestObject.tag == "BigObject") {
            moveBigObject(closestObject);
        }

    }

    // Findet das nähste gameobject aus der liste pickableGOList, oder null wenn out of range
    private GameObject searchClosestObjectInDistance()
    {
        GameObject closestGameObject = null;
        float closestDistance = Mathf.Infinity;
        Vector3 position = this.transform.position;
        foreach (GameObject currentGameObject in pickableGOList)
        {
            if (currentGameObject == null) {continue;}
            float curDistance = Vector3.Distance(position, currentGameObject.transform.position);
            if (curDistance < closestDistance)
            {
                closestGameObject = currentGameObject;
                closestDistance = curDistance;
            }
        }

        if (closestDistance <= range) 
        {
            hasObject = true;
            pickedObject = closestGameObject;
            return closestGameObject;
        } else {
            return null;
        }
    }

    private void pickUpSmallObject(GameObject closestGO) {
        pickedObject.GetComponent<PickableObject>().pick();
    }

    private  void moveBigObject(GameObject closestGO)
    {
        pickedObject.GetComponent<MoveableObject>().move();
    }

    private void useObject()
    {
        if (pickedObject.tag == "SmallObject") {
            fling();
        } else if (pickedObject.tag == "BigObject") {
            release();
        }
    }

    private void fling() 
    {
        hasObject = false;
        pickedObject.GetComponent<PickableObject>().fling(playerCameraDirection.forward, power);
        pickedObject = null;
    }

    private void release()
    {
        hasObject = false;
        pickedObject.GetComponent<MoveableObject>().release();
        pickedObject = null;
    }

}
