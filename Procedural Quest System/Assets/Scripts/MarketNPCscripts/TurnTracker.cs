using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTracker : MonoBehaviour
{
    public bool ENDTURN = false;

    private void LateUpdate()
    {
        if (ENDTURN)
        {
            ENDTURN = false;

        }
    }
}
