using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Knowledge
{
    public string name;

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Knowledge other = obj as Knowledge;
        if (other == null) return false;

        return name == other.name;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}
