﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningCollider : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerControl script;
    public LayerMask ignore;

    int colliderLayer;
    void Start()
    {
        script = gameObject.GetComponentInParent<PlayerControl>();
        colliderLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        if (script != null)
        {
            if (script.isRunning && script.isGrounded)
            {
                Physics2D.IgnoreLayerCollision(colliderLayer, ignore);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}