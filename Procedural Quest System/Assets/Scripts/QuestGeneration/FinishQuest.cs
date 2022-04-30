using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishQuest : GAction
{
        public GameObject[] npcLocation;
    public int npcNumber;

    private void Start()
    {
        duration = 2;
    }




    public void finishLocation()
    { 
        target = npcLocation[npcNumber];
    }




    public override bool PrePerform()
    {
        finishLocation();     
        return true;
    }


  
    public override bool PostPerform()
    {

  


        return true;
    }
}
