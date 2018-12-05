using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public enum playerMode
    {
        buildMode,
        playMode
    }
    playerMode pMode = playerMode.playMode;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayMode(playerMode m_pMode)
    {
        switch (pMode)
        {
            case playerMode.buildMode:
                pMode = playerMode.buildMode;
                break;
            case playerMode.playMode:
                pMode = playerMode.playMode;
                break;
            default:
                Debug.Log("If you are seeing this, that means the game mode changes isn't working. Contact Jonathan for support.");
                break;
        }
    }
    public playerMode GetPlayerMode()
    {
        return pMode;
    }
}
