using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpeedMap : ScriptableObject
{
    public float g;
    public float[] speedMultypliersl;
    public float GetSpeed(int level)
    { 
    return g* speedMultypliersl[level];
    }

}
