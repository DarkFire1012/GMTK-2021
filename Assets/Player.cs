﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    private SpriteRenderer _spriteRenderer;
    
    private bool shouldJump;
    private float timeSinceJump;
    private float timeSinceAttack;
    private bool shouldAirDeaccel;
    private bool facingRight = true;
    private Collider2D[] hitEnemies;

    public Sprite attackSprite;
    public float attackCooldown = 0.3f;
    public float attackRange = 0.5f;
    
    public float jumpCooldown;
    public float jumpSpeed = 5;
    public float jumpAccel = 10f;
    public float horizontalSpeed = 4.0f;
    public float horizontalDeaccel = 0.93f;
    public float inAirHorizontalDeaccel = 0.85f;
    public float maxHorizontalSpeed = 6.0f;
    public bool onGround = false;

    public float gravityScale = 1.0f;
    
    public LayerMask enemyLayers;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D colliding)
    {
        foreach (ContactPoint2D contact in colliding.contacts)
        {
            if (_collider2D.bounds.min.y > contact.collider.bounds.max.y)
            {
                ground();
            }
        }

        shouldAirDeaccel = false;
    }

    private void OnCollisionEnter2D(Collision2D colliding)
    {
        foreach (ContactPoint2D contact in colliding.contacts)
        {
            if (_collider2D.bounds.min.y > contact.collider.bounds.max.y)
            {
                ground();
            }
        }

        shouldAirDeaccel = false;
    }

    private void OnCollisionExit2D(Collision2D colliding)
    {
        onGround = false;
        shouldAirDeaccel = true;
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.gravityScale = this.gravityScale;
        
        timeSinceJump += Time.deltaTime;
        timeSinceAttack += Time.deltaTime;

        handleMovement();
        
        if (Input.GetButton("Jump"))
        {
            shouldJump = true;
        }

        if (timeSinceJump >= jumpCooldown)
        {
            if (shouldJump && canJump())
            {
                jump();
            }
        }

        if (Input.GetButton("Fire1"))
        {
            attack();
        }  
        
        shouldJump = false;
    }

    private void OnDrawGizmosSelected() {
        if (facingRight) {
            Gizmos.DrawWireSphere(new Vector2(transform.position.x + attackRange / 2, transform.position.y), attackRange);
        } else if (!facingRight) {
            Gizmos.DrawWireSphere(new Vector2(transform.position.x - attackRange / 2, transform.position.y), attackRange);
        }
    }

    void jump()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _rigidbody2D.velocity = new Vector2(Math.Min(Math.Abs(_rigidbody2D.velocity.x) * jumpAccel, maxHorizontalSpeed), jumpSpeed);
        } else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _rigidbody2D.velocity = new Vector2(Math.Max(-Math.Abs(_rigidbody2D.velocity.x) * jumpAccel, -maxHorizontalSpeed), jumpSpeed);
        } else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (_rigidbody2D.velocity.x > 0)
            {
                _rigidbody2D.velocity = new Vector2(Math.Min(Math.Abs(_rigidbody2D.velocity.x), maxHorizontalSpeed), jumpSpeed);
            } else if (_rigidbody2D.velocity.x < 0)
            {
                _rigidbody2D.velocity = new Vector2(Math.Max(-Math.Abs(_rigidbody2D.velocity.x), -maxHorizontalSpeed), jumpSpeed);
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(0f, jumpSpeed);
            }
        }
                
        onGround = false;
        timeSinceJump = 0;
    }

    void ground()
    {
        onGround = true;
        if (Input.GetAxisRaw("Horizontal") == 0 && !Input.GetButton("Jump"))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x * horizontalDeaccel,
                _rigidbody2D.velocity.y);
        }
    }

    void attack()
    {
        if (timeSinceAttack >= attackCooldown) {
            Debug.Log("Attacking");
            if (facingRight) {
                hitEnemies = Physics2D.OverlapCircleAll(
                    new Vector2(transform.position.x + attackRange / 2, transform.position.y), attackRange,
                    enemyLayers);
            }
            else if (!facingRight) {
                hitEnemies = Physics2D.OverlapCircleAll(
                    new Vector2(transform.position.x - attackRange / 2, transform.position.y), attackRange,
                    enemyLayers);
            }

            foreach (Collider2D hit in hitEnemies) {
                Debug.Log("Hit " + hit.name);
            }

            timeSinceAttack = 0;
        }
    }

    void handleMovement()
    {
        if (shouldAirDeaccel && Input.GetAxisRaw("Horizontal") == 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x * inAirHorizontalDeaccel, _rigidbody2D.velocity.y);
        }
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!facingRight)
            {
                _spriteRenderer.flipX = false;
            }

            facingRight = true;
            _rigidbody2D.velocity = new Vector2(Math.Max(Math.Min(horizontalSpeed, maxHorizontalSpeed), Math.Abs(_rigidbody2D.velocity.x)), _rigidbody2D.velocity.y);
        } else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (facingRight)
            {
                _spriteRenderer.flipX = true;
            }
            
            facingRight = false;
            _rigidbody2D.velocity = new Vector2(Math.Min(Math.Max(-horizontalSpeed, -maxHorizontalSpeed), -Math.Abs(_rigidbody2D.velocity.x)), _rigidbody2D.velocity.y);
        }
    }

    bool canJump()
    {
        return onGround;
    }
    
    
}
