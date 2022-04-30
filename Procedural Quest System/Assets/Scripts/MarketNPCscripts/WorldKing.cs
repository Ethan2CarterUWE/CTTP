using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldKing : MonoBehaviour
{




    public int foodSTORED = 250;
    public int foodCAP = 500;
    public int foodCONSUMED = 1;

    public int goodsSTORED = 250;
    public int goodsCAP = 500;
    public int goodsCONSUMED = 1;


    public int money = 1000;


    public bool HungryKing = false;
    public bool UnhappyKing = false;

    public bool Turn = false;
    public TurnTracker turntrack;


    void Update()
    {
        Turn = turntrack.ENDTURN;
        if (Turn)
        {
            money += 10;
            hungryCheck();
            UnhappyCheck();
        }

    }


    void hungryCheck()
    {
        if (foodCONSUMED > foodSTORED)
            HungryKing = true;
        else
            HungryKing = false;
    }

    void UnhappyCheck()
    {
        if (goodsCONSUMED > goodsSTORED)
            UnhappyKing = true;
        else
            UnhappyKing = false;
    }

}
