using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Activateable: MonoBehaviour
{
    public abstract void activate();
    public abstract void deactivate();
}
