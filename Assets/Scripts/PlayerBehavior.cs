using System;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private LayerMask shootlayer;

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
        ProjectilleShootingHandler();
        RaycastShootingHandler();
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

    private void ProjectilleShootingHandler()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("shot");
            Instantiate(projectilePrefab,
                spawnPosition.position,
                projectilePrefab.transform.rotation);
        }
        else
        {
            animator.ResetTrigger("shot");
        }
    }
}
