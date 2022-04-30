using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wow : MonoBehaviour
{

    /// <summary>
    /// THIS IS THE MARKET HOLY WOWZERS
    /// </summary>

    public FinishQuest fin;
    public bool chicken = true;
    // Start is called before the first frame update
    void Start()
    {

        //change this to the quest state script, that way it can all be one thing and real epic.
         fin = gameObject.GetComponent<FinishQuest>();


    }

    // Update is called once per frame
    void Update()
    {
        


        if (chicken)
        {
            //fin.beliefs.ModifyState("AchieveQuest", 0);

        }
    }
}
