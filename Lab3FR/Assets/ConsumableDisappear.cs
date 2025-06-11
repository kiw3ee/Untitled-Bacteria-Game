using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComsumableDisappear: MonoBehaviour
{
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            //kill counter - adds 1 kill
            if (KillCounter.instance != null)
            {
                KillCounter.instance.AddKill();
            }

            Destroy(gameObject);
        }  
    }
}