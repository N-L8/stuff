using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InteractableController : MonoBehaviour
{
    [SerializeField]
    private bool isEnabled;

    [SerializeField]
    private float maxInteractDistance = 5f;

    [SerializeField]
    private UnityEvent onEvent;

    [SerializeField]
    private UnityEvent offEvent;

    private GameObject player;
    private Vector3 interactable;

    private void Awake()
    {
        player = GameObject.Find("Player");
        interactable = transform.position;
    }

    public void InteractSwitch()
    {
        if (!isEnabled)
        {
            isEnabled = true;
            onEvent.Invoke();
        }
        else
        {
            isEnabled = false;
            offEvent.Invoke();
        }
    }
    private void OnMouseDown()
    {
        float dist = Vector3.Distance(player.transform.position, interactable);
        if(dist < maxInteractDistance)
            InteractSwitch();
    }
}
