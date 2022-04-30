using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiValues : MonoBehaviour
{

    public GameObject player;

    public Text valuecheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        valuecheck.text = "";
        valuecheck.text += "EQ: " + player.GetComponent<QUESTSTATE>().ExploreQmax + "  ";
        valuecheck.text += "KQ: " + player.GetComponent<QUESTSTATE>().KillQmax + "  ";
        valuecheck.text += "AQ: " + player.GetComponent<QUESTSTATE>().AchieveQmax + "  ";

    }
}
