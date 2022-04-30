using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreMountain : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("ExploreMountain");
        return true;
    }
}
