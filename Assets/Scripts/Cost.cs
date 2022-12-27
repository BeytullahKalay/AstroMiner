using System;
using Orb;
using UnityEngine;

[Serializable]
public struct Cost
{
    public OrbType OrbType;
    public int OrbCost;

    public Type GetCostClassType()
    {
        switch (OrbType)
        {
            case OrbType.Blue:
                return typeof(OrbBlue);
            case OrbType.Yellow:
                return typeof(OrbYellow);
            default:
                Debug.LogError("There is no type " + OrbType + "in Type");
                throw new ArgumentOutOfRangeException();
        }
    }
}
