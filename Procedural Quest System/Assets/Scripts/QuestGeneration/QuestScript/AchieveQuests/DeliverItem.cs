using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverItem : GAction
{


    public GameObject[] DeliverLocation;
    public int randomise;
    private int max;

    public override bool PrePerform()
    {
        max = DeliverLocation.Length;

        randomise = Random.Range(0, max);


        target = DeliverLocation[randomise];

        return true;
    }

    public override bool PostPerform()
    {



        beliefs.RemoveState("SpawnDeliver");
        return true;
    }
}
