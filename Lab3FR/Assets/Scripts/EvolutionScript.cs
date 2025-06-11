using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvolutionScript : MonoBehaviour
{
    //variables
    public GameObject bacteriaModel1;
    public GameObject bacteriaModel2;
    public GameObject bacteriaModel3;

    //evolution checks
    private bool evolutionOne = false;
    private bool evolutionTwo = false;
    private bool evolutionThree = false;
    private bool evolutionFinal = false;

    //calling other scripts
    public HealthScript healthScript;
    public RadialShot radialShot;
    public KillCounter killCounter;

    //scene to load for win
    public string sceneToLoad;

    void Start()
    {
        //checking if health script was accessed
        Debug.Log("Score from Health Script: " + healthScript.maxHealth);
        radialShot.enabled = false;
        bacteriaModel1.SetActive(true);
        bacteriaModel2.SetActive(false);
        bacteriaModel3.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        //evolutions
        if (!evolutionOne && KillCounter.instance != null && KillCounter.instance.GetKillCount() == 1)
        {
            FirstEvolution();

            bacteriaModel1.transform.localScale *= 1.25f;
        }

        if (!evolutionTwo && KillCounter.instance != null && KillCounter.instance.GetKillCount() == 2)
        {
            SecondEvolution();

            bacteriaModel1.SetActive(false);
            bacteriaModel2.SetActive(true);
        }

        if (!evolutionThree && KillCounter.instance != null && KillCounter.instance.GetKillCount() == 3)
        {
            ThirdEvolution();

            bacteriaModel2.transform.localScale *= 1.25f;
        }

        if (!evolutionFinal && KillCounter.instance != null && KillCounter.instance.GetKillCount() == 4)
        {
            FinalEvolution();
            bacteriaModel2.SetActive(false);
            bacteriaModel3.SetActive(true);
        }



        //de-evolutions
        if (healthScript.currentHealth == 1 && evolutionTwo == true)
        {
            FirstEvolution();

            bacteriaModel1.SetActive(true);
            bacteriaModel2.SetActive(false);

            killCounter.killCount = 1;
            bacteriaModel1.transform.localScale *= 0.75f;

            if (evolutionOne == true)
            {
                Debug.Log("the player has de-evolved");
            }
        }

        if (healthScript.currentHealth == 1 && evolutionThree == true)
        {
            SecondEvolution();

            killCounter.killCount = 2;
            bacteriaModel2.transform.localScale *= 0.75f;

            if (evolutionTwo == true)
            {
                Debug.Log("the player has de-evolved");
            }
        }

        if (healthScript.currentHealth == 1 && evolutionFinal == true)
        {
            ThirdEvolution();

            bacteriaModel2.SetActive(true);
            bacteriaModel3.SetActive(false);

            killCounter.killCount = 3;
            bacteriaModel2.transform.localScale *= 0.75f;

            if (evolutionThree == true)
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

        healthScript.maxHealth = 100;
        healthScript.currentHealth = healthScript.currentHealth + 25;
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

        healthScript.maxHealth = 200;
        healthScript.currentHealth = healthScript.currentHealth + 25;
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

        healthScript.maxHealth = 300;
        healthScript.currentHealth = healthScript.currentHealth + 50;
    }

    void FinalEvolution()
    {
        evolutionThree = false;
        evolutionOne = false;
        evolutionTwo = false;
        evolutionFinal = true;

        if (evolutionThree == false)
        {
            Debug.Log("Evolution 3 is false");
        }
        if (evolutionFinal == true)
        {
            Debug.Log("Evolved to the final evo");
        } 

        healthScript.maxHealth = 500;
        healthScript.currentHealth = healthScript.currentHealth + 100;
    }
    
    //winning the game
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OceanTop") && evolutionFinal == true)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void WinTheGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
