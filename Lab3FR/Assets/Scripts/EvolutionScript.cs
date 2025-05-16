using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionScript : MonoBehaviour
{
    //variables
    private bool evolutionOne = false;
    private bool evolutionTwo = false;
    private bool evolutionThree = false;
    private bool evolutionFour = false;
    //private bool evolutionFinal = false;

    // Update is called once per frame
    void Update()
    {
        if (!evolutionOne && KillCounter.instance != null && KillCounter.instance.GetKillCount() >= 1)
        {
            FirstEvolution();
            evolutionOne = true;

            if (evolutionOne == true)
            {
                Debug.Log("Evo one is true");
            }
        }

        if (!evolutionTwo && KillCounter.instance != null && KillCounter.instance.GetKillCount() >= 2)
        {
            SecondEvolution();
            evolutionOne = false;
            evolutionTwo = true;

            if (evolutionOne == false)
            {
                Debug.Log("Evolution 1 is false");
            }
            if (evolutionTwo == true)
            {
                Debug.Log("Evolution 2 is true");
            }
        }

        if (!evolutionThree && KillCounter.instance != null && KillCounter.instance.GetKillCount() >= 3)
        {
            ThirdEvolution();
            evolutionOne = false;
            evolutionTwo = false;

            evolutionThree = true;
            if (evolutionThree == true)
            {
                Debug.Log("Evolution 3 is true");
            }
        }

        if (!evolutionFour && KillCounter.instance != null && KillCounter.instance.GetKillCount() >= 4)
        {
            FourthEvolution();
            evolutionOne= false; 
            evolutionTwo = false;
            evolutionThree = false;

            evolutionFour = true;
            if (evolutionTwo == true)
            {
                Debug.Log("Evolution 4 is true");
            }
        }
    }

    //evolution functions
    void FirstEvolution()
    {
        transform.localScale *= 3f;    
    }

    void SecondEvolution()
    {
        transform.localScale *= 2f;
        Debug.Log("Evolved to level 2");
    }

    void ThirdEvolution()
    {
        Debug.Log("Evolved to level 3");
    }

    void FourthEvolution()
    {
        Debug.Log("Evolved to level 4");
    }

    void FinalEvolution()
    {
        Debug.Log("Evolved to the final evo");
    }
}
