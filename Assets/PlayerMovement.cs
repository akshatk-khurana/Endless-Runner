using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float jumpTime = 0.3f;

    private bool isGrounded = false;

    private void Update() {
        isGrounded = Physics2D.OverlapCircle(feetPos.position,
         groundDistance, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump")) {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
