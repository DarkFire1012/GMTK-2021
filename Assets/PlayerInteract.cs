using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Ray ray;
    public RaycastHit hit;
    [SerializeField] private GameObject FirstObj;
    [SerializeField] private GameObject SecondObj;
    [SerializeField] private LineRenderer Line = new LineRenderer();

    /*
    private void OnMouseDown()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 11))
        {
            if (hit.collider.gameObject != null)
            {
                FirstObj = hit.collider.gameObject;
                if (FirstObj.GetComponent<Source>() != null)
                {
                    // Do the arrow
                    Line.SetWidth(0.2f, 0.2f);
                    Line.SetPosition(0, FirstObj.transform.position);

                }
            }
        }

    }

    private void OnMouseDrag()
    {
        if (FirstObj.GetComponent<Source>() != null)
        {
            Line.SetPosition(1, Input.mousePosition);

        }
        else
        {
            return;

        }

    }

    private void OnMouseUpAsButton()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 12))
        {
            if (hit.collider.gameObject != null)
            {
                SecondObj = hit.collider.gameObject;


            }

        }

    }
    */

    void Update()
    {
        
    }





}
