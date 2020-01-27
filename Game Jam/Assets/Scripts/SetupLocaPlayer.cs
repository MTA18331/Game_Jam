using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocaPlayer : NetworkBehaviour
{
    [SyncVar(hook = "OnChangePoints")]
    [SerializeField] private int playerPoints = 0; 

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            //GetComponent<PlayerMovement>().enabled = true;
        }
    }

    #region Command Methods
    // Called on client runs on server
    [Command]
    public void CmdChangePoints(int points)
    {
        ChangePoints(points);
    }

    #endregion

    #region Client RPC Methods
    // Called On Server only runs on clients
    #endregion

    #region Sync Variable Methods
    void OnChangePoints(int points)
    {
        if (isLocalPlayer)
        {
            return;
        }
        ChangePoints(points);
    }
    #endregion

    #region Private Methods
    private void ChangePoints(int points)
    {
        playerPoints += points;
    }
    #endregion

}
