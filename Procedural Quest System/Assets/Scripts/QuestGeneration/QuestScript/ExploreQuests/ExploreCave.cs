using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreCave : GAction
{
    public override bool PrePerform()
    {
        //beliefs.ModifyState("ExploreQuestComplete", 0);
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("ExploreCave");
        return true;
    }
}
