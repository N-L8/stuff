using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    [SerializeField]
    private float maxInteractDistance = 5f;

    private Vector3 itemPosition;
    private GameObject player;
    
    private void Awake()
    {
        player = GameObject.Find("Player");
        itemPosition = transform.position;
    }

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        float dist = Vector3.Distance(player.transform.position, itemPosition);
        if (dist < maxInteractDistance)
            Pickup();
    }
}
