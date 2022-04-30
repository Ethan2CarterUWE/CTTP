using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMiner : MonoBehaviour
{


    public int foodSTORED = 250;
    public int foodCAP = 500;
    public int foodCONSUMED = 1;


    public int woodSTORED = 250;
    public int woodCAP = 500;
    public int woodCONSUME = 1;


    public int oreSPARE = 100;
    public int oreOUT = 50;
    public int oredSTORED = 250;
    public int oreCAP = 500;
    public int oreCONSUME = 1;

    private int difference = 0;


    public int money = 20;


    public bool HungryMiner = false;
    public bool UnhappyMiner = false;

    public bool Turn = false;
    public TurnTracker turntrack;


    void Update()
    {
        Turn = turntrack.ENDTURN;
        if (Turn)
        {
            oreFunction();
            money += 10;
            hungryCheck();
            UnhappyCheck();
        }

    }




    void oreFunction()
    {
        oredSTORED += oreOUT;
        oredSTORED -= oreCONSUME;
        morethanENough();
    }

    void morethanENough()
    {
        if (woodSTORED > woodCAP)
        {
            difference = (Mathf.Abs(oredSTORED - oreCAP));
            oredSTORED -= difference;
            oreSPARE += difference;
            money += difference;
        }
    }



    void hungryCheck()
    {
        if (foodCONSUMED > foodSTORED)
            HungryMiner = true;
        else
            HungryMiner = false;
    }

    void UnhappyCheck()
    {
        if (woodCONSUME > woodSTORED)
            UnhappyMiner = true;
        else
            UnhappyMiner = false;
    }
}
