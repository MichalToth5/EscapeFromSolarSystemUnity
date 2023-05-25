using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int index;

    private void Start()
    {

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.slots[index].isUsed = false;
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            Debug.Log("Stlacil som button");
            child.GetComponent<Spawn>().SpawnItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
