using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalMusic : MonoBehaviour
{
    public Transform goal;
    public Transform rocket;

    private float startingDist;
    private float distProgress;

    public AudioSource goalAudioLoop;

    private void Start()
    {
        startingDist = Vector3.Distance(rocket.position, goal.position);
        goalAudioLoop.volume = 0;
    }

    private void Update()
    {
        float dist = Vector3.Distance(rocket.position, goal.position);
        distProgress = dist / startingDist;
        print(distProgress);
        goalAudioLoop.volume = .7f - distProgress;

    }

}
