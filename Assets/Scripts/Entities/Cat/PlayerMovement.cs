using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private Player player;

    [Header("Events")]
    [SerializeField] private UnityEvent Dead;

    [SerializeField] private ContactFilter2D platform;
    //[SerializeField] VectorValue position;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    private bool isGrounded => rigidbody.IsTouching(platform);

    string currentState;
    float scale;

    private const string IDLE = "idle";
    private const string WALK = "walk";
    private const string RUN = "run";
    private const string JUMP = "jump";
    private const string TAKE = "take";

    void Awake()
    {
        //transform.position = position.GetInitialValue();
        rigidbody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start() => scale = transform.localScale.x;

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                Move(player.GetRunSpeed());
            else
                Move(player.GetWalkSpeed());
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Test
            ChangeAnimationState(TAKE);
        }
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
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    ChangeAnimationState(RUN);
                else
                    ChangeAnimationState(WALK);
            }
            else
            {
                //animationDelay = animator.GetCurrentAnimatorClipInfo(0).Length;
                ChangeAnimationState(IDLE);
            }
        }
        else
            ChangeAnimationState(JUMP);
    }

    void Move(float speed)
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void Jump() => rigidbody.AddForce(transform.up * player.GetJumpForce(), ForceMode2D.Impulse);

    //void Die() => Dead.Invoke();

    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }
}