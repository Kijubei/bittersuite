using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public GameObject destroyedVersion;
    public GameObject loot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // PUBLIC API
    public void destory()
    {
        destroySelf();
        spawnLoot();
    }

    // PRIVATE API

    private void destroySelf()
    {
        PlayerObjectInteraction.removePickableObject(this.gameObject);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        this.tag = "Untagged";
        Destroy(this.gameObject);
    }
    private void spawnLoot()
    {
        loot.name = "The Loot";
        Debug.Log("Loot tag is " + loot.tag);
        Vector3 lootPosition = transform.position;
        lootPosition.y += 0.2f;
        Instantiate(loot, lootPosition, transform.rotation);
        PlayerObjectInteraction.newPickableObject(loot);

    }
}
