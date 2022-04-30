using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QUESTSTATE : GAction
{
    // Start is called before the first frame update


    


    //NPC selector
    private int JobN;
    //changes value of the finish quest npc, so that it can change to the one who sent you on the quest.
    public FinishQuest finQ;

    //Dealing with selection of quest types
    private int ToQ;

    //Variables of Certain AI elements to calculate quest weightings for player based on playstyle
    public int KillQmax = 1;
    public int ExploreQmax = 1;
    public int AchieveQmax = 1;
    //private int totalQmax = 3;

        //arrays for weighting quests on playstyle
     int[] arraytest = {1,1,1,2,2,2,3,3,3,0};
     int[] actualValues = {0,0,0,0,0,0,0,0,0,0};

    private bool DoOnce = false;

    //minimum weighting of different quests
    int FirstNumber= 2;
    int SecondNumber = 2;
    int ThirdNumber = 2;


    //for market to update every quest
    public TurnTracker turntrack;
    public WorldMarket markeet;



    //Dealing with selection of quests 
    private int KQnum;
    private int EQnum;
    private int AQnum;
    private int RandomEventnum;

    public void Start()
    {
          finQ = GetComponent<FinishQuest>();
    }

    public void JobSelector()
    {


         JobN = Random.Range(1,7);
         switch (JobN)
         {
             default:
                 print("Job Selected: Nothing");
                 break;

             case 1:           
                 print("Job Selected: Lumberjack");
                 beliefs.ModifyState("JobLumberJack", 0);
                 
                 break;
            case 2:
                 print("Job Selected: Farmer ");
                 beliefs.ModifyState("JobFarmer", 0);
                 break;
             case 3:
                 print("Job Selected: King");
                 beliefs.ModifyState("JobKing", 0);
                 break;
             case 4:
                 print("Job Selected: Miner");
                 beliefs.ModifyState("JobMiner", 0);
                 break;
             case 5:
                 print("Job Selected: Merchant");
                 beliefs.ModifyState("JobMerchant", 0);
                 break;
             case 6:
                 print("Job Selected: Hunter");
                 beliefs.ModifyState("JobHunter", 0);              
                 break;
             
         }
    }

    public void cleanJob()
    {

        if (beliefs.HasState("JobKing"))
        {
            finQ.npcNumber = 0;
            beliefs.ModifyState("JobKing", -1);

        }
        if (beliefs.HasState("JobFarmer"))
        {
            finQ.npcNumber = 1;
            beliefs.ModifyState("JobFarmer", -1);
        }
        if (beliefs.HasState("JobLumberJack"))
        {
            finQ.npcNumber = 4;
            beliefs.ModifyState("JobLumberJack", -1);
        }
        if (beliefs.HasState("JobMiner"))
        {
            finQ.npcNumber = 2;

            beliefs.ModifyState("JobMiner", -1);

        }
        if (beliefs.HasState("JobMerchant"))
        {
            finQ.npcNumber = 5;
            beliefs.ModifyState("JobMerchant", -1);

        }
        if (beliefs.HasState("JobHunter"))
        {
            finQ.npcNumber = 3;
            beliefs.ModifyState("JobHunter", -1);

        }
       /* if (beliefs.HasState("JobGuard"))
        {
            finQ.npcNumber = 2;
            beliefs.ModifyState("JobGuard", -1);

        }*/





    }



    public void playstyleAIWeighting()
    {

        ///his initialises the array. It contains 3 values. each value depends on which quest has been completed. To fix the issue of forever infinite weightings, 
        ///there is a cap of the last 10 quests which removes the oldest value for the newest
        ///This is so that the weightings can be in check. there is also a limit on how high a number can get which is 5.
        /// 
      


        if (!DoOnce)
        {
            for (int i = 0; i < 9; i++)
            {
                actualValues[i] = arraytest[i + 1];

                actualValues[9] = 1;

                if (actualValues[i] == 1 && FirstNumber != 6)
                {
                    FirstNumber++;
                }
                else if (actualValues[i] == 2 && SecondNumber != 6)
                {
                    SecondNumber++;
                }
                else if (actualValues[i] == 3 && ThirdNumber != 6)
                {
                    ThirdNumber++;
                }
            }
            DoOnce = true;
        }

        for (int i = 0; i < 9; i++)
        {
            actualValues[i] = arraytest[i + 1];
            actualValues[i] = actualValues[i + 1];

            if (actualValues[i] == 1 && FirstNumber != 7)
            {
                FirstNumber++;
            }
            else if (actualValues[i] == 2 && SecondNumber != 7)
            {
                SecondNumber++;
            }
            else if (actualValues[i] == 3 && ThirdNumber != 7)
            {
                ThirdNumber++;
            }
        }
         
        Debug.Log("FirstNum: " + FirstNumber + " SecondNum: " + SecondNumber + " ThirdNum: " + ThirdNumber);
    }

    public void typeofquest()
    {

        /*
        //Basic find a quest depending on just a random number, equal chance = boring

        ToQ = Random.Range(1, 5);

         switch (ToQ)
         {

             default:
                 print("NothingSpawned");
                 break;
             case 1:
                 print("Explorer");
                 beliefs.ModifyState("ExploreQuest", 0);   
                 break;
             case 2:
                 print("Killer ");
                 beliefs.ModifyState("KillQuest", 0);
                 break;
             case 3:
                 print("Achieve ");
                 beliefs.ModifyState("AchieveQuest", 0);
                 break;
             case 4:
                 print("Random");
                 beliefs.ModifyState("RandomQuest", 0);
                 break;
         }*/

        /*---------------------------------------------------------------------------------------------------------------*/
        /*---------------------------------------------------------------------------------------------------------------*/
        /*---------------------------------------------------------------------------------------------------------------*/

        //Weighted values instead of switch, so that certain ones can be more valued if wanted to.
        /* ToQ = Random.Range(1, 101);

         Debug.Log("THE RANDOM NUMBER IS: " + ToQ);
         if(ToQ <= 30)
         {
             print("Explorer");
             beliefs.ModifyState("ExploreQuest", 0);
         }
         else if(ToQ <= 60)
         {
             print("Killer ");
             beliefs.ModifyState("KillQuest", 0);
         }
         else if (ToQ>90)
         {
             print("Random");
             beliefs.ModifyState("RandomQuest", 0);
         }
         else
         {
             print("Achieve ");
             beliefs.ModifyState("AchieveQuest", 0);
         }*/

        /*---------------------------------------------------------------------------------------------------------------*/
        /*---------------------------------------------------------------------------------------------------------------*/
        /*---------------------------------------------------------------------------------------------------------------*/

        /* 

          //Weighted depending on players favourite quests but can easily go out of control and block off other quests

          int comb1 =ExploreQmax  + KillQmax;
          int comb2 = comb1 + AchieveQmax;

          ToQ = Random.Range(1, totalQmax + 1);

          Debug.Log("THE RANDOM NUMBER IS: " + ToQ);
          if (ToQ <= ExploreQmax)
          {
              print("Explorer");
              ExploreQmax++;
              beliefs.ModifyState("ExploreQuest", 0);
          }
          // else if (ToQ <= KillQmax)
           else if (ToQ > ExploreQmax && ToQ <= comb1)

          {
              print("Killer ");
              KillQmax++;
              beliefs.ModifyState("KillQuest", 0);
          }
          // else if (ToQ > AchieveQmax)
          else if (ToQ > comb1 && ToQ <= comb2)
          {
              print("Achieve ");
              AchieveQmax++;
              beliefs.ModifyState("AchieveQuest", 0);
          }
          else
          {
              print("Random");
              beliefs.ModifyState("RandomQuest", 0);
          }
          totalQmax = ExploreQmax + KillQmax + AchieveQmax;
          */

        /*---------------------------------------------------------------------------------------------------------------*/
        /*---------------------------------------------------------------------------------------------------------------*/
        /*---------------------------------------------------------------------------------------------------------------*/



        playstyleAIWeighting();

        Debug.Log("array check:" + actualValues[0] + (",") + actualValues[1] + (",") + actualValues[2] + (",") + actualValues[3] + (",") + actualValues[4] +
            (",") + actualValues[5] + (",") + actualValues[6] + (",") + actualValues[7] + (",") + actualValues[8] + (",") + actualValues[9]);


        int comb1 = FirstNumber + SecondNumber;
        int comb2 = comb1 + ThirdNumber;

        //Weighted depending on players favourite quests but but using arrays, and limiting values,
        //can no longer go out of control as it still gives access to lesser played quests
        ToQ = Random.Range(1, comb2 + 1);

       // Debug.Log("THE RANDOM NUMBER IS: " + ToQ);
        if (ToQ <= FirstNumber)
        {
           // print("Explorer");
            actualValues[9] = 1;
            ExploreQmax++;
            beliefs.ModifyState("ExploreQuest", 0);
        }
        else if (ToQ > FirstNumber && ToQ <= comb1)

        {
          //  print("Killer ");
            actualValues[9] = 2;
            KillQmax++;
            beliefs.ModifyState("KillQuest", 0);
        }
        else if (ToQ > comb1 && ToQ <= comb2)
        {
            //print("Achieve ");
            actualValues[9] = 3;
            AchieveQmax++;
            beliefs.ModifyState("AchieveQuest", 0);

        }

        //resets the values and keeps a minmium which means that the option is always there
        FirstNumber = 2;
        SecondNumber = 2;
        ThirdNumber = 2;
    }

    public void clearToQ()
    {
        if (beliefs.HasState("ExploreQuest"))
        {
            beliefs.RemoveState("ExploreQuest");
        }
        if (beliefs.HasState("KillQuest"))
        {
            beliefs.RemoveState("KillQuest");
        }
        if (beliefs.HasState("AchieveQuest"))
        {
            beliefs.RemoveState("AchieveQuest");
        }
    }


    public void KQFinder()
    {
        KQnum = Random.Range(1, 7);

         switch(KQnum)
         {
             default:
                 print("FailedKILLSPAWN");
                 break;
             case 1:
                 print("Spawn Wolves");
                 beliefs.ModifyState("SpawnWolves", 0);
                 break;
             case 2:
                 print("Spawn Bears ");
                 beliefs.ModifyState("SpawnBears", 0);
                 break;
             case 3:
                 print("Spawn Ice Wolves");
                 beliefs.ModifyState("SpawnIceWolves", 0);
                 break;
             case 4:
                 print("Spawn Ice Bears ");
                 beliefs.ModifyState("SpawnIceBears", 0);
                 break;
             case 5:
                 print("Spawn Cave THING ");
                 beliefs.ModifyState("SpawnCaveThing", 0);
                 break;
             case 6:
                 print("Spawn Zombie ");
                 beliefs.ModifyState("SpawnZombie", 0);
                 break;
         }



    }

    public void EQFinder()
    {


        EQnum = Random.Range(1, 5);

          switch(EQnum)
            {
                default:
                    print("FailedEXPLORESPAWN");
                    break;
                case 1:
                    beliefs.ModifyState("ExploreMountain", 0);
                    break;
                case 2:
                     beliefs.ModifyState("ExploreCave", 0);
                    break;
                case 3:            
                     beliefs.ModifyState("FindMushroom", 0);
                    break;
                case 4:
                    beliefs.ModifyState("Investigations", 0);
                    break;

            }



        // CASE 1 BREAKS MEDIUM QUESTS BUT CASE 2 BREAKS SHORT QUESTS FOR NO REASON
        //may have fixed since adding 3rd option
        //look at explore cave script for easy fix if wanting you use in med quests
        //med quests need own seperate quests which will never appear in other quest functions.
        // for example instead of kill bear and explore cave, it would be find boss, kill boss, return loot
        // instead of thinking of it as medium length, change to medium difficulty

    }

    public void AQFinder()
    {
        AQnum = Random.Range(1, 5);

        switch (AQnum)
        {
            default:
                print("FailedACHIEVESPAWN");
                break;           
            case 1:
                beliefs.ModifyState("SpawnItem", 0);
                break;
            case 2:
                beliefs.ModifyState("RepairBridge", 0);
                break;
            case 3:
                beliefs.ModifyState("SpawnDeliver", 0);
                break;
            case 4:
                beliefs.ModifyState("BuildDef", 0);
                break;            
        }

    }

    public void RandomQuestFinder()
    {

        RandomEventnum = Random.Range(1, 15);


        if (RandomEventnum <= 6)
        {
            beliefs.ModifyState("KillQuest", 0);
        }
        else if (RandomEventnum >= 7 && RandomEventnum <= 10)
        {
            beliefs.ModifyState("ExploreQuest", 0);
        }
        else
        {
            beliefs.ModifyState("AchieveQuest", 0);
        }


        switch (RandomEventnum)
        {
            default:
                print("FailedKILLSPAWN");
                break;
            case 1:
                print("Spawn Wolves");
                beliefs.ModifyState("SpawnWolves", 0);
                break;
            case 2:
                print("Spawn Bears ");
                beliefs.ModifyState("SpawnBears", 0);
                break;
            case 3:
                print("Spawn Ice Wolves");
                beliefs.ModifyState("SpawnIceWolves", 0);
                break;
            case 4:
                print("Spawn Ice Bears ");
                beliefs.ModifyState("SpawnIceBears", 0);
                break;
            case 5:
                print("Spawn Cave THING ");
                beliefs.ModifyState("SpawnCaveThing", 0);
                break;
            case 6:
                print("Spawn Zombie ");
                beliefs.ModifyState("SpawnZombie", 0);
                break;

            case 7:
                beliefs.ModifyState("ExploreMountain", 0);
                break;
            case 8:
                beliefs.ModifyState("ExploreCave", 0);
                break;
            case 9:
                beliefs.ModifyState("FindMushroom", 0);
                break;
            case 10:
                beliefs.ModifyState("Investigations", 0);
                break;

            case 11:
                beliefs.ModifyState("SpawnItem", 0);
                break;
            case 12:
                beliefs.ModifyState("RepairBridge", 0);
                break;
            case 13:
                beliefs.ModifyState("SpawnDeliver", 0);
                break;
            case 14:
                beliefs.ModifyState("BuildDef", 0);
                break;
        }
    }

    public void MarketUpdate()
    {

        if (markeet.hunter.foodCONSUMED > markeet.hunter.foodSTORED)
        {
            markeet.hunter.HungryHunter = true;


            if (markeet.hunter.HungryHunter == true)
            {
                beliefs.ModifyState("OnPersonalQuest", 0);

                if (markeet.hunter.money >= 10)
                {
                    beliefs.ModifyState("SpawnDeliver", 0);
                    beliefs.ModifyState("AchieveQuest", 0);
                    beliefs.ModifyState("OnQuest", 0);
                    markeet.hunter.foodSTORED = 15;
                }
                else
                {
                    beliefs.ModifyState("SpawnWolves", 0);
                    beliefs.ModifyState("KillQuest", 0);
                    beliefs.ModifyState("OnQuest", 0);
                    markeet.hunter.foodSTORED = 15;
                }
            }
        }


        if (markeet.miner.foodCONSUMED > markeet.miner.foodSTORED)
        {
            if (markeet.miner.HungryMiner == true)
            {
                beliefs.ModifyState("OnPersonalQuest", 0);

                if (markeet.miner.money >= 10)
                {
                    beliefs.ModifyState("SpawnDeliver", 0);
                    beliefs.ModifyState("AchieveQuest", 0);
                    beliefs.ModifyState("OnQuest", 0);
                    markeet.miner.foodSTORED = 15;
                }
                else
                {
                    beliefs.ModifyState("SpawnWolves", 0);
                    beliefs.ModifyState("KillQuest", 0);
                    beliefs.ModifyState("OnQuest", 0);
                    markeet.miner.foodSTORED = 15;
                }
            }
        }



        if (markeet.lumberJack.foodCONSUMED > markeet.lumberJack.foodSTORED)
        {
            if (markeet.lumberJack.HungryLumber == true)
            {
                beliefs.ModifyState("OnPersonalQuest", 0);

                if (markeet.lumberJack.money >= 10)
                {
                    beliefs.ModifyState("SpawnDeliver", 0);
                    beliefs.ModifyState("AchieveQuest", 0);
                    beliefs.ModifyState("OnQuest", 0);
                    markeet.lumberJack.foodSTORED = 15;
                }
                else
                {
                    beliefs.ModifyState("SpawnWolves", 0);
                    beliefs.ModifyState("KillQuest", 0);
                    beliefs.ModifyState("OnQuest", 0);
                    markeet.lumberJack.foodSTORED = 15;
                }
            }
        }



        if (markeet.king.foodCONSUMED > markeet.king.foodSTORED)
        {
            if (markeet.king.HungryKing == true)
            {
                beliefs.ModifyState("OnPersonalQuest", 0);

                if (markeet.king.money >= 10)
                {
                    beliefs.ModifyState("SpawnDeliver", 0);
                    beliefs.ModifyState("AchieveQuest", 0);
                    beliefs.ModifyState("OnQuest", 0);
                    markeet.king.foodSTORED = 15;
                }
                else
                {
                    beliefs.ModifyState("SpawnWolves", 0);
                    beliefs.ModifyState("KillQuest", 0);
                    beliefs.ModifyState("OnQuest", 0);
                    markeet.king.foodSTORED = 15;
                }
            }
        }    

        if (markeet.merchant.HungryMerchant == true)
        {
            beliefs.ModifyState("OnPersonalQuest", 0);

            if (markeet.merchant.money >= 10)
            {
                beliefs.ModifyState("SpawnDeliver", 0);
                beliefs.ModifyState("AchieveQuest", 0);
                beliefs.ModifyState("OnQuest", 0);
                markeet.merchant.foodSTORED = 15;
            }
            else
            {
                beliefs.ModifyState("SpawnWolves", 0);
                beliefs.ModifyState("KillQuest", 0);
                beliefs.ModifyState("OnQuest", 0);
                markeet.merchant.foodSTORED = 15;
            }
        }



    }



  

    public override bool PrePerform()
    {
       cleanJob();
        clearToQ();
        //clears any potential active quest finishes to stop early finishing quests
        beliefs.RemoveState("QuestObjectiveDone");


        //function for ranomd quest selection


        return true;
    }

    public override bool PostPerform()
    {     
        //Updates the market and all npcs
        turntrack.ENDTURN = true;

        //WHy are they so needy that its always interrupting everything
        //MarketUpdate();

       
            typeofquest();

            if (beliefs.HasState("KillQuest"))
            {
                KQFinder();
            }
            if (beliefs.HasState("ExploreQuest"))
            {
                EQFinder();
            }
            if (beliefs.HasState("AchieveQuest"))
            {
                AQFinder();
            }       

            JobSelector();          

        return true;
    }
}
