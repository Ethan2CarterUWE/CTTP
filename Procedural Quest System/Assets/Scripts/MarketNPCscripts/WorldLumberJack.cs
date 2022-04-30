using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLumberJack : MonoBehaviour
{
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
    public int foodSTORED = 250;                                                
    public int foodCAP = 500;                                                   
    public int foodCONSUMED = 1;                                                
                                                                                
                                                                                
    public int woodOUT = 30;                                                    
    public int woodSTORED = 250;                                                
    public int woodCAP = 500;                                                   
    public int woodCONSUME = 1;                                                 
    public int SpareWOOD = 100;                                                 
                                                                                
    public int oredSTORED = 250;                                                
    public int oreCAP = 500;                                                    
    public int oreCONSUME = 1;                                                  
                                                                                
    private int difference = 0;                                                 


    public int money = 20;


    public bool HungryLumber = false;
    public bool UnhappyLumber = false;

    public bool Turn = false;
    public TurnTracker turntrack;


    void Update()
    {
        Turn = turntrack.ENDTURN;
        if (Turn)
        {
            woodFUNCTION();
            money += 10;
            hungryCheck();
            UnhappyCheck();
        }

    }




    void woodFUNCTION()
    {
        woodSTORED += woodOUT;
        woodSTORED -= woodCONSUME;
        morethanENough();
    }

    void morethanENough()
    {
        if (woodSTORED > woodCAP)
        {
            difference = (Mathf.Abs(woodSTORED - woodCAP));
            woodSTORED -= difference;
            SpareWOOD += difference;
            money += difference;
        }
    }



    void hungryCheck()
    {
        if (foodCONSUMED > foodSTORED)
            HungryLumber = true;
        else
            HungryLumber = false;
    }

    void UnhappyCheck()
    {
        if (oreCONSUME > oredSTORED)
            UnhappyLumber = true;
        else
            UnhappyLumber = false;
    }


}
