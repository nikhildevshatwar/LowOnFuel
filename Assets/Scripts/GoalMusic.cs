using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMusic : MonoBehaviour
{
    private Transform rocket;
    private Transform goal;

    private float startingDist;
    private float distProgress;

    public AudioSource goalAudioLoop;

    private void Start()
    {
        rocket = GameObject.Find("Rocket").transform;
        goal = GameObject.Find("Goal").transform;
        startingDist = Vector3.Distance(rocket.position, goal.position);
        goalAudioLoop.volume = 0;
    }

    private void Update()
    {
        float dist = Vector3.Distance(rocket.position, goal.position);
        distProgress = dist / startingDist;
        goalAudioLoop.volume = .7f - distProgress;
    }

}
