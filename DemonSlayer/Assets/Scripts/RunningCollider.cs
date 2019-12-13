using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningCollider : MonoBehaviour
{

    Player script;
    public int enemyLayer;

    int colliderLayer;
    void Start()
    {
        script = gameObject.GetComponentInParent<Player>();
        colliderLayer = gameObject.layer;
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }
   
    void Update()
    {
        if (script != null)
        {
            if (script.isRunning && script.isGrounded)
            {
                Physics2D.IgnoreLayerCollision(colliderLayer, enemyLayer, script.invincible);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
