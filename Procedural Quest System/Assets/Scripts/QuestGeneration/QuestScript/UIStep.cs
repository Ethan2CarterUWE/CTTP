using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStep : MonoBehaviour
{
    public GameObject player;

    public Text Nextstep;
    public string Location;
    bool doOnce = true;

  

    void LateUpdate()
    {
        if (doOnce)
        {
            Location = player.GetComponent<GAgent>().currentAction.target.name;
            Nextstep.text += Location;
            doOnce = false;
        }

        Nextstep.text = "";
        Nextstep.text += player.GetComponent<GAgent>().currentAction;

        Nextstep.text += " Location:  " + Location;

        if (Location != player.GetComponent<GAgent>().currentAction.target.name)
        {
            Location = player.GetComponent<GAgent>().currentAction.target.name;

        }
    }
}
