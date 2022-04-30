using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCaveThing : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {


        if (beliefs.HasState("OnMedQuest"))
        {
            beliefs.ModifyState("KillQuestComplete", 0);

        }
        beliefs.RemoveState("SpawnCaveThing");
        return true;
    }
}
