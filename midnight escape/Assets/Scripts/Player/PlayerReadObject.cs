using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLabel : MonoBehaviour
{
    public Camera camera;
    private string nameObject;
    private bool hitObject;

    [SerializeField]
    private float range = 5f;

    [SerializeField]
    private LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        hitObject = false;
        if (Physics.Raycast(ray, out hit, range, mask))
        {
            hitObject = true;
            Transform objectHit = hit.transform;
            nameObject = hit.transform.gameObject.name;
        }
    }

    void OnGUI()
    {
        if (hitObject == true)
        {
            Vector2 screenPos = Event.current.mousePosition;
            Vector2 convertedGUIPos = GUIUtility.ScreenToGUIPoint(screenPos);

            GUI.Label(new Rect(convertedGUIPos.x, convertedGUIPos.y + 25, 200, 100), nameObject);
        }
        else
        {
            Vector2 screenPos = Event.current.mousePosition;
            Vector2 convertedGUIPos = GUIUtility.ScreenToGUIPoint(screenPos);
            GUI.Label(new Rect(convertedGUIPos.x, convertedGUIPos.y, 200, 60), " ");
        }
    }
}