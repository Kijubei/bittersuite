﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private GameObject[] heavyGOList;
    private float activationDistance = 0.5f;
    private bool isButtonPressed = false;

    [Tooltip("The object that is pushed down")]
    public GameObject pressureButton;

    [Tooltip("The Object that will activate")]
    public Activateable activationObject;
    // Start is called before the first frame update
    void Start()
    {
        if (pressureButton is null || activationObject is null) 
        {
            Debug.LogWarning("Not all public field are instanciated!", this);
        }
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] BigObjectList = GameObject.FindGameObjectsWithTag("BigObject");
        // heavyGOList = new GameObject[playerList.Length + BigObjectList.Length];
        heavyGOList = playerList.Concat(BigObjectList).ToArray();
        if (heavyGOList is null)
        {
            Debug.LogWarning("No heavy objects found", this);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        bool isOnTop = isHeavyObjectOnTop();
        if (isOnTop && !isButtonPressed)
        {
            buttonPressed();
        } else if (!isOnTop && isButtonPressed) {
            buttonReleased();
        } 
    }

    private bool isHeavyObjectOnTop()
    {
        if (heavyGOList is null) 
        {
            return false;
        }
        Vector3 selfPosition = this.transform.position;
        foreach (GameObject heavyObject in heavyGOList)
        {
            float curDistance = Vector3.Distance(selfPosition, heavyObject.transform.position);
            if (curDistance < activationDistance)
            {
                //Debug.Log("Distance: " + curDistance);
                return true;
            }
        }
        return false;
    }

    private void buttonPressed()
    {
        isButtonPressed = true;
        activationObject.activate();
    }

    private void buttonReleased()
    {
        isButtonPressed = false;
        activationObject.deactivate();
    }
}
