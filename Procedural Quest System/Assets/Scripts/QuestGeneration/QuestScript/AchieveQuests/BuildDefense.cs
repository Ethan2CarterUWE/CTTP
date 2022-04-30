using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildDefense : GAction
{



    public GameObject[] BuildLocations;
    public int randomise;
    private int max;


    public override bool PrePerform()
    {
        max = BuildLocations.Length;
        randomise = Random.Range(0, max);


        target = BuildLocations[randomise];
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("BuildDef");
        return true;
    }
}
