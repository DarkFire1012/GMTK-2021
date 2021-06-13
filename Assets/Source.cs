using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    [Header("Object Properties")]
    [SerializeField] private bool Anchored = true;
    [SerializeField] private bool Stasis = false;
    [SerializeField] private bool Collidable = true;
    [SerializeField] private bool Bouncy = false;
    [SerializeField] private float BounceMultiplier = 1.5f;
    [SerializeField] private bool Sticky = false;
    [SerializeField] private bool Indestructable = false;
    [SerializeField] private bool Flamable = false;
    [SerializeField] private bool Gravity = false;
    [SerializeField] private float GravitySpeed = 1;

    [SerializeField] private Material Mat;

    private void Start()
    {

        //Mat = Material.Create("Test");

    }





}
