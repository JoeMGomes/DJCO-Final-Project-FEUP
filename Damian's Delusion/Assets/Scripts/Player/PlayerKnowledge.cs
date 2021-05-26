using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnowledge : MonoBehaviour
{
    public ArrayList knowledges;
    // Start is called before the first frame update
    void Start()
    {
        knowledges = new ArrayList();
    }

    public void AddKnowledge(Knowledge knowledge)
    {
        Debug.Log("knowledge: " + knowledge.name);
        if (ContainsKnowledge(knowledge)) return;
        knowledges.Add(knowledge);
    }

    public bool ContainsKnowledge(Knowledge knowledge)
    {
        bool contains = knowledges.Contains(knowledge);
        Debug.Log("contains " + knowledge.name + "? " + contains);
        return contains;
    }
}
