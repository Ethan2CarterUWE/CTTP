using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPersonalQuest : GAction
{







    public override bool PrePerform()
    {

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("OnPersonalQuest");
        beliefs.ModifyState("QuestObjectiveDone", 0);
        return true;
    }





}



