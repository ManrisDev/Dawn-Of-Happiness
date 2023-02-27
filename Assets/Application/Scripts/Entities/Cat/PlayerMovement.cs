using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;

    [SerializeField] private ContactFilter2D platform;
    //[SerializeField] VectorValue position;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    private bool isGrounded => rigidbody.IsTouching(platform);
    private bool takeAnimationIsPlaying = false;

    private string currentState;
    private float animationDelay;
    private float scale;

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

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            //Test
            Interaction();
        }*/
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            animationDelay = animator.GetCurrentAnimatorClipInfo(0).Length;
            ChangeAnimationState(TAKE);
            takeAnimationIsPlaying = true;
            enabled = false;
            Invoke("Change", animationDelay);
        }

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
                ChangeAnimationState(IDLE);
        }
        else
            ChangeAnimationState(JUMP);
    }

    private void Change()
    {
        takeAnimationIsPlaying = false;
        enabled = true;
    }

    private void Interaction()
    {

    }

    void Move(float speed)
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    void Jump() => rigidbody.AddForce(transform.up * player.GetJumpForce(), ForceMode2D.Impulse);

    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        if (takeAnimationIsPlaying) return;

        //play animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }
}