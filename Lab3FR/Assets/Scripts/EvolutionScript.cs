using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionScript : MonoBehaviour
{
    private bool evolutionOne = false;
    /* example of what the second evolution would look like:
     private bool evolutionTwo = false;
     */

    // Update is called once per frame
    void Update()
    {
        if (!evolutionOne && KillCounter.instance != null && KillCounter.instance.GetKillCount() >= 2)
        {
            FirstEvolution();
            evolutionOne = true;
        }
    }

    void FirstEvolution()
    {
        transform.localScale *= 3f;
        Debug.Log("You have evolved!");
    }

    /*
    void SecondEvolution()
    {
        script
    }
    */
}
