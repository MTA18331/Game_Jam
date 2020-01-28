using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int triggerID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvents.gameEvents.ChurchCollide(triggerID);
    }
}
