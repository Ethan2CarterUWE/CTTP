using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigate : GAction
{


    public GameObject[] Investigations;
    private int randomise;
    private int max;
    public override bool PrePerform()
    {
        max = Investigations.Length;
        randomise = Random.Range(0, max);
        target = Investigations[randomise];

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("Investigations");
        return true;
    }
}
