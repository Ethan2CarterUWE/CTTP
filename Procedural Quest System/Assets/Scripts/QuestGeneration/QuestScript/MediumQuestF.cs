using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumQuestF : GAction
{
    public override bool PrePerform()
    {

        print("Going to DOOOOO");
        return true;
    }

    public override bool PostPerform()
    {
        if (beliefs.HasState("OnMedQuest"))
        {

            beliefs.RemoveState("OnMedQuest");
        }

        if (beliefs.HasState("ExploreQuestComplete"))
        {

            beliefs.RemoveState("ExploreQuestComplete");
        }
        if (beliefs.HasState("KillQuestComplete"))
        {

            beliefs.RemoveState("KillQuestComplete");
        }



        return true;
    }
}
