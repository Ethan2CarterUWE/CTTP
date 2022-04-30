using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBridge : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("RepairBridge");

        return true;
    }
}
