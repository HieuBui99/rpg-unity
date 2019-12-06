using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCollider : MonoBehaviour
{
    // Start is called before the first frame update
    Player script;
    public LayerMask ignore;

    int colliderLayer;
    void Start()
    {
        script = gameObject.GetComponentInParent<Player>();
        colliderLayer = gameObject.layer;

    }

    // Update is called once per frame
    void Update()
    {
        if (script != null)
        {
            CapsuleCollider2D collider = gameObject.GetComponent<CapsuleCollider2D>();
            if (collider != null)
            {
                if (!script.isGrounded && !script.isRunning)
                {
                    collider.enabled = true;
                }
                else
                {
                    collider.enabled = false;
                }
            }
            else
            {
                if (!script.isGrounded && !script.isRunning)
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = true;
                }
                else
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }
            }
            
        }
    }
}
