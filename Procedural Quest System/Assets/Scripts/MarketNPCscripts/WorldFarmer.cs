using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFarmer : MonoBehaviour
{




    public int foodOUT = 40;
    public int foodSTORED = 0;
    public int foodCAP = 50;
    public int foodCONSUMED = 2;
    public int SPAREFOOD = 0;


    public int money = 0;

    private int difference = 0;

    public bool HungryFarmer = false;
    public bool Turn = false;
    public TurnTracker turntrack;


    void Update()
    {
         Turn = turntrack.ENDTURN;

        if (Turn)
        {
            foodFUNCTION();
            hungryCheck();
        }
    }



    void foodFUNCTION()
    {
        foodSTORED += foodOUT;
        foodSTORED -= foodCONSUMED;
        morethanENough();
    }

    void morethanENough()
    {
        if (foodSTORED > foodCAP)
        {
            difference = (Mathf.Abs(foodSTORED - foodCAP));
            foodSTORED -= difference;          
            SPAREFOOD += difference;
            money += difference;
        }
    }

    void hungryCheck()
    {
        if (foodCONSUMED > foodSTORED)
            HungryFarmer = true;
        else
            HungryFarmer = false;
    }

 









}
