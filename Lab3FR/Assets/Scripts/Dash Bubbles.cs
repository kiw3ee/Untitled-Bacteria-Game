using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public ParticleSystem dashBubbles;
    public float bubbleDuration = 3f;

    private bool isPlaying = false;
    private float timer = 0f;

    void Start()
    {
        if (dashBubbles != null)
        {
            dashBubbles.Stop();
            dashBubbles.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Trigger particles on key press
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isPlaying)
        {
            StartParticles();
        }

        // If playing, count down and stop after duration
        if (isPlaying)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                StopParticles();
            }
        }
    }

    void StartParticles()
    {
        if (dashBubbles == null) return;

        dashBubbles.gameObject.SetActive(true);
        dashBubbles.Play();
        timer = bubbleDuration;
        isPlaying = true;
    }

    void StopParticles()
    {
        if (dashBubbles == null) return;

        dashBubbles.Stop();
        dashBubbles.gameObject.SetActive(false);
        isPlaying = false;
    }
}