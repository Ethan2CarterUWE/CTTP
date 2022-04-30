using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindChest : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("SpawnChest");
        return true;
    }
}
