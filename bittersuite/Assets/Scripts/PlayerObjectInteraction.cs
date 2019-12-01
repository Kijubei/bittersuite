using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectInteraction : MonoBehaviour
{
    private KeyCode pickUpButton = KeyCode.Mouse1;
    private KeyCode useObjectButton = KeyCode.Mouse0;
    private GameObject smallObject;
    private bool hasObject = false;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
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
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("SmallObject");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
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
                smallObject = closestGO;
                smallObject.GetComponent<PickableObject>().moveToRightHand();
            } else {
                print(distance);
            }
    }

    private void fling() {
        hasObject = false;
        smallObject.GetComponent<PickableObject>().fling();
    }

}
