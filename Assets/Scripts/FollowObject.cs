using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FollowModeType
{
    ALL,
    X_ONLY,
    Y_ONLY,
};

public class FollowObject : MonoBehaviour
{
    public FollowModeType followMode = FollowModeType.ALL;
    private GameObject rocket;

    private Vector3 offset;

    void Start()
    {
        rocket = GameObject.Find("Rocket");
        offset = transform.position - rocket.transform.position;
    }

    void Update()
    {
        switch (followMode)
        {
            case FollowModeType.X_ONLY:
                transform.position = new Vector2(rocket.transform.position.x + offset.x, transform.position.y);
                break;
            case FollowModeType.Y_ONLY:
                transform.position = new Vector2(transform.position.x, rocket.transform.position.y + offset.y);
                break;
            case FollowModeType.ALL:
            default:
                transform.position = rocket.transform.position + offset;
                break;
        }
    }
}
