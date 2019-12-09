using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningCollider : MonoBehaviour
{
    // Start is called before the first frame update
    Player script;
    public int enemyLayer;

    int colliderLayer;
    void Start()
    {
        script = gameObject.GetComponentInParent<Player>();
        colliderLayer = gameObject.layer;
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
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
