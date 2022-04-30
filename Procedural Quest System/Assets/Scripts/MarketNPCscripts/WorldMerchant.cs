using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMerchant : MonoBehaviour
{


    public int foodSTORED = 250;
    public int foodCAP = 500;
    public int foodCONSUMED = 1;

    public int goodsOUT = 50;
    public int goodsSTORED = 190;
    public int goodsCAP = 200;
    public int goodsCONSUMED = 1;
    public int spareGOODS = 0;


    public int money = 1000;
    private int difference = 0;


    public bool HungryMerchant = false;
    public bool UnhappyMerchant = false;

    public bool Turn = false;
    public TurnTracker turntrack;


    void Update()
    {
        Turn = turntrack.ENDTURN;
        if (Turn)
        {

            goodsFUNCTION();
            money += 10;
            hungryCheck();
            UnhappyCheck();
        }

    }




    void goodsFUNCTION()
    {
        goodsSTORED += goodsOUT;
        goodsSTORED -= goodsCONSUMED;
        morethanENough();
    }

    void morethanENough()
    {
        if (goodsSTORED > goodsCAP)
        {
            difference = (Mathf.Abs(goodsSTORED - goodsCAP));
            goodsSTORED -= difference;
            spareGOODS += difference;
            money += difference;
        }
    }


    void hungryCheck()
    {
        if (foodCONSUMED > foodSTORED)
            HungryMerchant = true;
        else
            HungryMerchant = false;
    }

    void UnhappyCheck()
    {
        if (goodsCONSUMED > goodsSTORED)
            UnhappyMerchant = true;
        else
            UnhappyMerchant = false;
    }
}
