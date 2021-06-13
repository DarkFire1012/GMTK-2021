﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using System.IO;

/*
public class IInteractables
{
*/
    interface IAnchor
    {
        bool Anchored { get; set; }
        void AnchorUpdate();

    }

    interface IStasis
    {
        bool Stasis { get; set; }
        void StasisUpdate();

    }


    interface ICollidable
    {
        bool Collidable { get; set; }
        void CollidableUpdate();

    }

    interface IBouncy
    {
        bool Bouncy { get; set; }
        float BounceMultiplier { get; set; }
        void BouncyUpdate();

    }

    interface Isticky
    {
        bool Sticky { get; set; }
        float StickTime { get; set; }
        void StickyUpdate();

    }

    interface IIndestructable
    {
        bool Indestructable { get; set; }
        void IndestructableUpdate();

    }

    interface IFlamable
    {
        bool Flamable { get; set; }
        void FlamableUpdate();

    }

    interface IGravity
    {
        bool Gravity { get; set; }
        float GravitySpeed { get; set; } //vertical
        void GravityUpdate();

    }

    interface IMagnetic
    {
        bool Magnetic { get; set; }
        void MagneticUpdate();

    }
/*
}

*/
