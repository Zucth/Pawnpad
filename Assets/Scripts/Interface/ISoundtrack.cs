using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundtrack
{
    public enum Soundtype
    {
        none,
        SurfaceST,
        UndergroundST,
        LabST
    }
    //public Soundtype test;
    void MakeSound(Soundtype sound);
}
