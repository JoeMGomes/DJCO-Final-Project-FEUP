using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Knowledge
{
    public string name;

    public override bool Equals(System.Object obj)
    {
        if (obj == null) return false;
        Knowledge other = obj as Knowledge;
        if ((System.Object)other == null) return false;

        Debug.Log(name + " == " + other.name);
        return name == other.name;
    }
}
