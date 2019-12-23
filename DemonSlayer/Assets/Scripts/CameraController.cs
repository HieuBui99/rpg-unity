
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    Transform playerPos;
    Transform cameraPos;

    [SerializeField]
    float timeOffset;

    [SerializeField]
    Vector3 posOffset;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

    void Awake()
    {
        if (playerPos == null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }
        cameraPos = this.transform;
    }

    void FixedUpdate()
    {
        try
        {
            if (playerPos == null)
            {
                playerPos = GameObject.FindGameObjectWithTag("Player").transform;
                return;
            }
            Vector3 startPos = cameraPos.position;
            Vector3 endPos = playerPos.position;
            endPos.x += posOffset.x;
            endPos.y += posOffset.y;
            endPos.z = -10;
            transform.position = Vector3.Lerp(startPos, endPos, timeOffset);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                                             Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                                             transform.position.z);
        }
        catch { }
    

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
