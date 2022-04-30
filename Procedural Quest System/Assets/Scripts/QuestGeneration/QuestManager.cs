using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : GAgent
{


    public bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();


        //Init the values to get the system started
        beliefs.ModifyState("JobFarmer", 0);
        if (!done)
        {
            beliefs.ModifyState("KillQuest", 0);

            beliefs.ModifyState("SpawnWolves", 0);
            done = true;
        }

        //Default goal, normal quests normal weightings that change depending on playstyle
        SubGoal s1 = new SubGoal("NoQuest", 1, false);
        goals.Add(s1, 1);

        //no longer active, random quests based on static percentage weightings
        SubGoal s2 = new SubGoal("RandomQuestFinished", 1, false);
        goals.Add(s2, 3);

        //quests which relate to npcs and their current states to do with the market
        SubGoal s3 = new SubGoal("PersonalQuestFinished", 1, false);
        goals.Add(s3, 5);         

    }













}
