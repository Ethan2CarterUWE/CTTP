using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHunter : MonoBehaviour
{


    public int foodSTORED = 0;
    public int foodCAP = 20;
    public int foodCONSUMED = 2;


    
        public int woodStored = 50;
        public int woodCAP = 100;
        public int woodConsumed = 1;
        public int SpareWood = 0;

    public int furOUT = 5;
    public int furStored = 0;
    public int furCAP = 10;
    public int furConsumed = 1;
    public int SpareFur = 0;



    public int money = 0;


    private int difference = 0;

    public bool HungryHunter = false;
    public bool UnhappyHunter = false;

    public bool Turn = false;
    public TurnTracker turntrack;



    void Update()
    {
        Turn = turntrack.ENDTURN;

        if (Turn)
        {
            furFUNCTION();
            woodStored--;
            hungryCheck();
            UnhappyCheck();
            Debug.Log("wood: " + woodStored);
        }
    }


    void furFUNCTION()
    {
        furStored += furOUT;
        furStored -= furConsumed;
        morethanENough();
    }

    void morethanENough()
    {
        if (furStored > furCAP)
        {
            difference = (Mathf.Abs(furStored - furCAP));
            furStored -= difference;
            SpareFur += difference;
            money += difference;
        }
    }


    void hungryCheck()
    {
        if (foodCONSUMED > foodSTORED)
            HungryHunter = true;
        else
            HungryHunter = false;
    }

    void UnhappyCheck()
    {
        if (woodConsumed > woodStored)
            UnhappyHunter = true;
        else
            UnhappyHunter = false;
    }

}
