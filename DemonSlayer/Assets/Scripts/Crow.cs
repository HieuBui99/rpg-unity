using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    public Transform player;

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            return;
        }
    }
    void Update()
    {
        DestroyCrow();
        StartCoroutine(MoveToPlayer(1f));
    }

    void DestroyCrow()
    {
        Destroy(gameObject, 1f);
    }
    IEnumerator MoveToPlayer(float time)
    {
        Vector3 currentPos = transform.position;
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(currentPos, player.position, t);
            yield return 0;
        }

    }
}
