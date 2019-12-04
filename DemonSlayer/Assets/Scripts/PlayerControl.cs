using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 100f;

    public Transform groundCheck;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform firePoint;
    public LayerMask whatIsGround;

    public GameObject tornado;
    public GameObject lightHitBox;
    public GameObject heavyHitBox;
    public GameObject upHitBox;
    public GameObject skillIHitBox;

    Rigidbody2D body;
    Animator animator;

    float vx;
    float vy;

    public bool isRunning = false;
    public bool isGrounded = true;
    bool doingSkill = false;
    bool facingRight = true;
    bool isAttacking = false;

    float upAttackCD = 0f;
    float skillICD = 0f;
    float skillIICD = 0f;
    Vector2 dashSpeed = new Vector2(15, 0);

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lightHitBox.SetActive(false);
        heavyHitBox.SetActive(false);
        upHitBox.SetActive(false);
        skillIHitBox.SetActive(false);
        //var animController = GetComponent<Animator>().runtimeAnimatorController;
        //foreach (var clip in animController.animationClips)
        //{
        //    if (clip.name == "Skill2") Debug.Log(clip.length);
        //}

    }
    void Update()
    {
        //Up Attack
        if ((Input.GetKey(KeyCode.UpArrow)) && !isAttacking && isGrounded && Input.GetAxisRaw("Horizontal")==0)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (upAttackCD <= 0)
                {
                    doingSkill = true;
                    animator.Play("UpAttack");
                    upAttackCD = 1;
                    StartCoroutine(UpAttackCoolDown(0.4f));
                }
            }

        }
        //Heavy Attack
        else if (Input.GetKeyDown(KeyCode.G) && !isAttacking && !doingSkill && isGrounded)
        {
            animator.Play("Attack1");
            StartCoroutine(LightAttackCoolDown(0.2f));
                
        }
        //Light Attack
        else if (Input.GetKeyDown(KeyCode.D) && !isAttacking && !doingSkill)
        {
            isAttacking = true;
            if (!isGrounded)
            {
                animator.Play("AirAttack");
                StartCoroutine(HeavyAttackCoolDown(0.1f));
            }
            else
            {
                animator.Play("Attack2");
                StartCoroutine(HeavyAttackCoolDown(0.2f));
            }
        }
        //Skill 2
        else if (Input.GetKeyDown(KeyCode.S) && !isAttacking && !doingSkill && isGrounded)
        {
            if (skillIICD <=0)
            {
                StartCoroutine(DoSkill2());
            }
        }
        //Skill 1
        else if (Input.GetKeyDown(KeyCode.A) && !isAttacking && !doingSkill)
        {
            if (skillICD <=0)
            {
                //StartCoroutine(DoSkill1(0.35f));
                StartCoroutine(MoveToPosition(transform.position + new Vector3(6f, 0, 0) * transform.localScale.x, 0.35f));
            }
        }

        // Reduce skill cooldown
        if (upAttackCD > 0 )
        {
            upAttackCD -= Time.deltaTime;
        }

        if (skillICD > 0 )
        {
            skillICD -= Time.deltaTime;
        }
        if (skillIICD > 0)
        {
            skillIICD -= Time.deltaTime;
        }

        vx = Input.GetAxisRaw("Horizontal");
        if (vx != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        animator.SetBool("Running", isRunning);

        //Check if Player is on the ground by casting a ray to the groundCheck position
        if (Physics2D.Linecast(gameObject.transform.position, groundCheck.position, whatIsGround) ||
            Physics2D.Linecast(gameObject.transform.position, groundCheckLeft.position, whatIsGround) ||
            Physics2D.Linecast(gameObject.transform.position, groundCheckRight.position, whatIsGround))
        {
            isGrounded = true;
        }
        else isGrounded = false;
        //isGrounded = Physics2D.Linecast(gameObject.transform.position, groundCheck.position, whatIsGround);
        animator.SetBool("Grounded", isGrounded);

        vy = body.velocity.y;
        if (isGrounded && Input.GetButtonDown("Jump") && !isAttacking)
        {
            vy = 0;
            body.AddForce(new Vector2(0, jumpForce));
        }

    }
    void FixedUpdate()
    {
        if ((!isAttacking && isGrounded) || (isAttacking && !isGrounded) || (!isAttacking && !isGrounded))
        {
            if (!doingSkill) body.velocity = new Vector2(vx * moveSpeed, vy);
        }
        else
        {
            if (!doingSkill) body.velocity = new Vector2(0, vy);
        }
        
           
    }
    void LateUpdate()
    {

        //Flipping the player sprite
        Vector3 _localScale = transform.localScale;
        if (!doingSkill)
        {
            if (vx > 0)
            {
                facingRight = true;
            }
            else if (vx < 0)
            {
                facingRight = false;
            }
            if ((facingRight && _localScale.x < 0) || (!facingRight && _localScale.x > 0))
            {
                _localScale.x *= -1;
                //transform.Rotate(0f, 180f, 0f);
            }
            transform.localScale = _localScale;
        }
    }


    IEnumerator DoSkill1(float dashDur)
    {
        //doingSkill = true;
        //animator.Play("Skill1");
        ////body.AddForce(new Vector2(transform.localScale.x * 700, 0));
        //body.velocity = new Vector2(transform.localScale.x * dashSpeed, 0);
        //skillICD = 3f;
        float time = 0;
        doingSkill = true;
        skillICD = 3f;
        animator.Play("Skill1");
        while (dashDur > time)
        {
            time += Time.deltaTime;
            body.velocity = new Vector2(dashSpeed.x * transform.localScale.x, 0);
            yield return 0;
        }
        body.velocity = new Vector2(0, 0);
        //yield return new WaitForSeconds(0.44f);
        doingSkill = false;

    }
    public IEnumerator MoveToPosition(Vector3 position, float timeToMove)
    {
        doingSkill = true;
        var currentPos = transform.position;
        var t = 0f;
        animator.Play("Skill1");
        skillIHitBox.SetActive(true);
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return 0;
        }
        skillIHitBox.SetActive(false);
        body.velocity = new Vector2(0, 0);
        doingSkill = false;
        skillICD = 3f;
    }

    //Perform skill 2
    IEnumerator DoSkill2()
    {
        body.velocity = new Vector2(0, 0);
        doingSkill = true;
        animator.Play("Skill2");
        skillIICD = 3f;
        yield return new WaitForSeconds(0.7f);
        if (facingRight)
        {
            Instantiate(tornado, firePoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(tornado, firePoint.position, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
        }
        //StartCoroutine(ResumeMovement(0.2f));
        doingSkill = false;
    }

    IEnumerator LightAttackCoolDown (float time)
    {
        lightHitBox.SetActive(true);
        yield return new WaitForSeconds(time);
        lightHitBox.SetActive(false);
        isAttacking = false;
    }

    IEnumerator HeavyAttackCoolDown(float time)
    {
        heavyHitBox.SetActive(true);
        yield return new WaitForSeconds(time);
        heavyHitBox.SetActive(false);
        isAttacking = false;
    }

    IEnumerator UpAttackCoolDown(float time)
    {
        upHitBox.SetActive(true);
        yield return new WaitForSeconds(time);
        upHitBox.SetActive(false);
        doingSkill = false;
    }
}
