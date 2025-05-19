using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);

        CheckSpriteFlip(moveX);
        CheckMoveAnim(moveX);
        ShootingHandler();
    }    

    private void CheckSpriteFlip(float moveX)
    {
        if(moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void CheckMoveAnim(float moveX)
    {
        if(moveX != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void ShootingHandler()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("shot");
        }
        else
        {
            animator.ResetTrigger("shot");
        }
    }
}
