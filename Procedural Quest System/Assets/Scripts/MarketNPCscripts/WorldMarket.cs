using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMarket : MonoBehaviour
{

    public int foodstock = 0;
    public int foodsell = 0;

    public int woodstock = 0;
    public int woodsell = 0;

    public int orestock = 0;
    public int oresell = 0;

    public int furstock = 0;
    public int fursell = 0;

    public int goodsstock = 0;
    public int goodssell = 0;


    public WorldFarmer farmer;
    public WorldHunter hunter;
    public WorldKing king;
    public WorldLumberJack lumberJack;
    public WorldMerchant merchant;
    public WorldMiner miner;

    public TurnTracker turntrack;

    public bool turn = false;


    void Update()
    {
        turn = turntrack.ENDTURN;


     if (turn)
        {
            collectfood();
            collectwood();
            collectore();
            collectfur();
            collectgoods();



            deliverFood();
            deliverWood();
            deliverGoods();
            deliverOre();

        }


    }


    void collectfood()
    {
        foodstock = farmer.SPAREFOOD;
        foodsell += foodstock;
        farmer.SPAREFOOD = 0;
    }

    void collectwood()
    {
       woodstock = lumberJack.SpareWOOD;
        woodsell += woodstock;
        lumberJack.SpareWOOD = 0;
    }

    void collectore()
    {
        orestock = miner.oreSPARE;
        oresell += orestock;
        miner.oreSPARE = 0;
    }


    void collectfur()
    {
        furstock = hunter.SpareFur;
        fursell += furstock;
        hunter.SpareFur = 0;
    }

    void collectgoods()
    {
        goodsstock = merchant.spareGOODS;
        goodssell += goodsstock;
        merchant.spareGOODS = 0;
    }



    void deliverFood()
    {
        if (hunter.money >= 3 && hunter.foodSTORED <=3)
        {
            hunter.money -= 3;
            hunter.foodSTORED += 5;
            foodsell -= 5;
        }

        if (miner.money >= 3 && miner.foodSTORED <= 3)
        {
            miner.money -= 3;
            miner.foodSTORED += 5;
            foodsell -= 5;
        }

        if (king.money >= 3 && king.foodSTORED <= 3)
        {
            king.money -= 3;
            king.foodSTORED += 5;
            foodsell -= 5;
        }

        if (lumberJack.money >= 3 && lumberJack.foodSTORED <= 3)
        {
            lumberJack.money -= 3;
            lumberJack.foodSTORED += 5;
            foodsell -= 5;
        }

        if (merchant.money >= 3 && merchant.foodSTORED <= 3)
        {
            merchant.money -= 3;
            merchant.foodSTORED += 5;
            foodsell -= 5;
        }


    }


    void deliverWood()
    {
        if (hunter.money >= 3)
        {
            hunter.money -= 3;
            hunter.woodStored += 5;
            woodsell -= 5;
        }

        if (miner.money >= 3)
        {
            miner.money -= 3;
            miner.woodSTORED += 5;
            woodsell -= 5;
        }
    }

    void deliverGoods()
    {
        if (king.money >3)
        {
            king.money -= 3;
            king.goodsSTORED += 5;
            goodssell -= 5;
        }
    }

    void deliverOre()
    {

        if (lumberJack.money > 3)
        {
            lumberJack.money -= 3;
            lumberJack.oredSTORED += 5;
            oresell -= 5;
        }
    }
}
