using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAnim : MonoBehaviour
{
    Animator Player;
 
    void Start()
    {
        Player = GetComponent<Animator>();
    }
 
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Player.SetTrigger("Attack");
        }
        
        if(Input.GetKey(KeyCode.W))
        {
            Player.SetTrigger("Moving");
        }
    }
}