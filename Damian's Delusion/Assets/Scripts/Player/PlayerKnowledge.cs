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

    // knowledge empty is skipped because it is equivalent to consider
    // the player already having it
    public void AddKnowledge(Knowledge knowledge)
    {
        if (ContainsKnowledge(knowledge) || knowledge.name == "") return;
        knowledges.Add(knowledge);
    }

    // knowledge empty is equivalent to player having the knowledge already
    // as the component doesn't require knowledge
    public bool ContainsKnowledge(Knowledge knowledge)
    {
        if (knowledge.name == "") return true;
        return knowledges.Contains(knowledge);
    }
}
