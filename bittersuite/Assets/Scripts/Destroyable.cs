using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public GameObject destroyedVersion;

    public void destory()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        this.tag = "Untagged";
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
