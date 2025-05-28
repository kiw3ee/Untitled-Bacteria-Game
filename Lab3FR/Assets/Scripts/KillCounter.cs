using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public static KillCounter instance;

    public int killCount = 0;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKill()
    {
        killCount++;
        Debug.Log("Kills: " + killCount);
    }

    public int GetKillCount()
    {
        return killCount;
    }
}
