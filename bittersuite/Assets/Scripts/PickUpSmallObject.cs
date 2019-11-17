using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSmallObject : MonoBehaviour
{
    private GameObject smallObject;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K) && (guide.transform.position - transform.position).sqrMagnitude < range * range) 
        if (Input.GetKeyDown(KeyCode.T)) {
            (GameObject, float) closestResult = FindClosestObject();
            GameObject closest = closestResult.Item1;
            float distance = closestResult.Item2;
            if ( distance <= range ) {
                print(closest.name); 
                // closest.transform.parent = getRightArm();
                closest.GetComponent<PickableObject>().moveToRightHand();
            } else {
                print(distance);
            }
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

    private Transform getRightArm() 
    {
        Transform current = this.transform.Find("MainCharacter");
        current = current.transform.Find("mixamorig:Hips");
        current = current.transform.Find("mixamorig:Spine");
        current = current.transform.Find("mixamorig:Spine1");
        current = current.transform.Find("mixamorig:Spine2");
        current = current.transform.Find("mixamorig:RightShoulder");
        current = current.transform.Find("mixamorig:RightArm");
        current = current.transform.Find("mixamorig:RightForeArm");
        current = current.transform.Find("mixamorig:RightHand");
        return current;
    }

}
