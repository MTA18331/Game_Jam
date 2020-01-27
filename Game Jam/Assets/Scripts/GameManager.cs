using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region GameManager instance
    private static GameManager instane;

    public static GameManager gameManager
    {
        get
        {
            return instane;
        }

        set
        {
            if (instane != null)
            {
                instane = value;
            }
        }
    }
    #endregion

    private void Awake()
    {
        gameManager = this;
    }



}
