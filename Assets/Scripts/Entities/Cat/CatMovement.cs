using UnityEngine;
using UnityEngine.Events;

public class CatMovement : MonoBehaviour
{
    Cat cat;

    [Header("Events")]
    [SerializeField] UnityEvent Dead;

    [SerializeField] ContactFilter2D platform;

    new Rigidbody2D rigidbody;
    //Animator animator;
    //[SerializeField] VectorValue position;

    bool isGrounded => rigidbody.IsTouching(platform);

    string currentState;
    float scale;

    const string IDLE = "cat_stopping";
    const string WALK = "cat_walk";
    const string RUN = "cat_run";
    const string JUMP = "Cat_start_run";

    void Awake()
    {
        //transform.position = position.GetInitialValue();
        rigidbody = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        cat = GetComponent<Cat>();
    }

    void Start()
    {
        scale = transform.localScale.x;
        if (GlobalVar.fromCafe)
            transform.position = new Vector3(178f, -2.78f, 0f);
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Walk();

        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    void FixedUpdate()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction > 0)
            transform.localScale = new Vector2(scale, transform.localScale.y);
        else if (direction < 0)
            transform.localScale = new Vector2(-scale, transform.localScale.y);

        if (isGrounded)
        {
            if (Input.GetButton("Horizontal"))
                ChangeAnimationState(WALK);
            else
            {
                //animationDelay = animator.GetCurrentAnimatorClipInfo(0).Length;
                ChangeAnimationState(IDLE);
            }
        }
        else
            ChangeAnimationState(JUMP);
    }

    void Walk()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, cat.GetWalkSpeed() * Time.deltaTime);
    }

    void Jump()
    {
        rigidbody.AddForce(transform.up * cat.GetJumpForce(), ForceMode2D.Impulse);
    }

    //void Die() => Dead.Invoke();

    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play animation
        //animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }
}