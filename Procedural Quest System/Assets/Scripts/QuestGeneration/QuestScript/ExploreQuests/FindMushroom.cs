using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMushroom : GAction
{


    public GameObject[] Mushrooms;
    private int randomise;
    private int max;

    public override bool PrePerform()
    {
        max = Mushrooms.Length;
        randomise = Random.Range(0, max);
        target = Mushrooms[randomise];

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("FindMushroom");
        return true;
    }
}
