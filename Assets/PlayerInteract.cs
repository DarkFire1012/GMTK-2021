using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Ray ray;
    public RaycastHit hit;
    [SerializeField] private GameObject other;

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 11))
        {
            other = hit.collider.gameObject;

        }

    }

    private void OnMouseDrag()
    {
        other = hit.collider.gameObject;

        if (other.GetComponent<Source>() != null)
        {
            // Do the arrow


        }
        else
        {
            return;
        }

    }





}
