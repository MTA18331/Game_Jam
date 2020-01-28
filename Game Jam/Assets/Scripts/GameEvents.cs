using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    #region GameEvents Instance 
    public static GameEvents gameEvents
    {
        get
        {
            return instance;
        }

        set
        {
            if (instance != null)
            {
                Destroy(value.gameObject);
                return;
            }

            instance = value;
        }
    }
    private static GameEvents instance = null; // Singleton Instance
    #endregion

    public event Action<int> onChurchCollide;

    private void Awake()
    {
        gameEvents = this;
    }

    public void ChurchCollide(int id)
    {
        onChurchCollide?.Invoke(id);
    }


}