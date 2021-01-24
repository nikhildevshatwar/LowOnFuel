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
    public GameObject target;
    public FollowModeType followMode;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        switch (followMode)
        {
            case FollowModeType.X_ONLY:
                transform.position = new Vector2(target.transform.position.x + offset.x, transform.position.y);
                break;
            case FollowModeType.Y_ONLY:
                transform.position = new Vector2(transform.position.x, target.transform.position.y + offset.y);
                break;
            case FollowModeType.ALL:
            default:
                transform.position = target.transform.position + offset;
                break;
        }
    }
}
