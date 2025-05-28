using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionScript : MonoBehaviour
{
    //variables
    public GameObject bacteriaModel;

    //evolution checks
    private bool evolutionOne = false;
    private bool evolutionTwo = false;
    private bool evolutionThree = false;
    //private bool evolutionFour = false;
    //private bool evolutionFinal = false;

    //calling other scripts
    public HealthScript healthScript;
    public RadialShot radialShot;
    public KillCounter killCounter;

    void Start()
    {
        //checking if health script was accessed
        Debug.Log("Score from Health Script: " + healthScript.maxHealth);
        radialShot.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        //evolutions
        if (!evolutionOne && KillCounter.instance != null && KillCounter.instance.GetKillCount() == 1)
        {
            FirstEvolution();

            bacteriaModel.transform.localScale *= 1.25f;
        }

        if (!evolutionTwo && KillCounter.instance != null && KillCounter.instance.GetKillCount() == 2)
        {
            SecondEvolution();

            bacteriaModel.transform.localScale *= 1.5f;
        }

        if (!evolutionThree && KillCounter.instance != null && KillCounter.instance.GetKillCount() == 3)
        {
            ThirdEvolution();

            bacteriaModel.transform.localScale *= 1.75f;
        }

        /*commenting out, fourth evolution not needed but keeping just in case
         * if (!evolutionFour && KillCounter.instance != null && KillCounter.instance.GetKillCount() >= 4)
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
        */

        //de-evolutions
        if (healthScript.currentHealth == 1 && evolutionTwo == true)
        {
            FirstEvolution();

            killCounter.killCount = 1;
            bacteriaModel.transform.localScale *= 0.75f;

            if (evolutionOne == true)
            {
                Debug.Log("the player has de-evolved");
            }
        }

        if (healthScript.currentHealth == 1 && evolutionThree == true)
        {
            SecondEvolution();

            killCounter.killCount = 2;
            bacteriaModel.transform.localScale *= 0.75f;

            if (evolutionTwo == true)
            {
                Debug.Log("the player has de-evolved");
            }
        }
    }



    //evolution functions
    void FirstEvolution()
    {
        evolutionOne = true;

        evolutionTwo = false;
        evolutionThree = false;

        if (evolutionOne == true)
        {
            Debug.Log("Evolution 1 is true");
        }

        radialShot.enabled = false;

        healthScript.maxHealth = 6;
        healthScript.currentHealth = 6;
    }

    void SecondEvolution()
    {
        evolutionTwo = true;
        
        evolutionOne = false;
        evolutionThree = false;

        if (evolutionOne == false)
        {
            Debug.Log("Evolution 1 is false");
        }
        if (evolutionTwo == true)
        {
            Debug.Log("Evolution 2 is true");
        }

        //enabling the radial shot script
        radialShot.enabled = true;

        healthScript.maxHealth = 15;
        healthScript.currentHealth = 15;
    }

    void ThirdEvolution()
    {
        evolutionThree = true;
        evolutionOne = false;
        evolutionTwo = false;

        if (evolutionTwo == false)
        {
            Debug.Log("Evolution 2 is false");
        }
        if (evolutionThree == true)
        {
            Debug.Log("Evolution 3 is true");
        }

        radialShot.enabled = true;

        healthScript.maxHealth = 25;
        healthScript.currentHealth = 25;
    }

    /*commenting out, fourth evolution not needed but keeping just in case
    void FourthEvolution()
    {
        Debug.Log("Evolved to level 4");
    }
    */

    /*void FinalEvolution()
    {
        bacteriaModel.transform.localScale *= 2f;
        Debug.Log("Evolved to the final evo");
        healthScript.maxHealth = 50;
        healthScript.currentHealth = 50;
    }
    */
}
