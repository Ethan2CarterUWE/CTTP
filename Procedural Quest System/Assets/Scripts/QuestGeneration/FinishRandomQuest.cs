using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRandomQuest : GAction
{


    public GameObject[] npcLocation;
    public int npcNumber;

    public void finishLocation()
    {
        target = npcLocation[npcNumber];
    }

    public override bool PrePerform()
    {
        finishLocation();

        return true;
    }

    public override bool PostPerform()
    {

        beliefs.RemoveState("RandomQuest");
        beliefs.ModifyState("QuestObjectiveDone", 0);
        
        return true;
    }
}
