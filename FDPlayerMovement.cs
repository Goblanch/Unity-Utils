using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// ***** FDPlayerMovement Class Description *****
/// 
/// FDPlayerMovement stands for "Four Directions Player Movement". This is a utility
/// class for Unity Engine whith basic player movement in 2D four directions enviroment.
/// 
/// ***** USAGE (IMPORTANT BEFORE USING) *****
/// Add this script to a GameObject in Unity Editor. The GameObject must have a RigidBody2D
/// component with gravity scale set to 0, in order to avoid GameObject falling down.
/// The RigidBody must have its body type set to dynamic.
/// 
/// Author: Gonzalo Blanch Domínguez
/// GitHub: https://github.com/Goblanch
/// Script Version: 1.0 (June 2023)
/// 
/// </summary>

public class FDPlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody2D rb2d;

    [Header("Movement Settings")]
    public float moveSpeed = 5.0f;
    public bool sprintEnabled = false;
    public float sprintMultiplier = 1.5f;

    [Header("Dash Settings")]
    public bool dashEnabled = false;
    public float dashingPower       = 10f;
    public float dashingTime        = 0.2f;
    public float dashingCoolDown    = 1f;

    [Header("Inputs")]
    public string xAxisInput    = "Horizontal";
    public string yAxisInput    = "Vertical";
    public string sprintInput   = "Fire3";
    public string dashInput     = "Jump";

    // PRIVATES
    private Vector2 _velocity;
    private float _originalMoveSpeed;
    private float _sprintMoveSpeed;
    private bool  _canDash = true;
    private bool  _isDashing;
    private bool  _movementEnabled = true;

    private void Start() {
        _originalMoveSpeed  = moveSpeed;
        _sprintMoveSpeed    = moveSpeed * sprintMultiplier;
    }

    void Update(){
        // Input
        Vector2 input = Vector2.zero;
        input.x = Input.GetAxisRaw(xAxisInput);
        input.y = Input.GetAxisRaw(yAxisInput);

        // Sprint
        if (sprintEnabled && Input.GetButton(sprintInput)) {
            moveSpeed = _sprintMoveSpeed;
        } else {
            moveSpeed = _originalMoveSpeed;
        }

        // _velocity calculation
        _velocity = input * moveSpeed;

        // Dash
        if(_canDash && Input.GetButtonDown(dashInput) && dashEnabled) {
            StartCoroutine(Dash(GetDashDirection(input) ) );
        }

        // Movement
        ApplyMovement();
    }

    /// <summary>
    /// Applies movement using RB velocity vector
    /// </summary>
    private void ApplyMovement() {
        if (_isDashing) return;
        rb2d.velocity = _velocity;
    }

    /// <summary>
    /// Dashes in a given direction
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private IEnumerator Dash(string direction) {
        _canDash = false;
        _isDashing = true;
        switch (direction.ToLower()) {
            case "right":
                rb2d.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
                break;
            case "left":
                rb2d.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
                break;
            case "up":
                rb2d.velocity = new Vector2(0f, transform.localScale.y * dashingPower);
                break;
            case "down":
                rb2d.velocity = new Vector2(0f, -transform.localScale.y * dashingPower);
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(dashingTime);
        _isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        _canDash = true;
    }

    /// <summary>
    /// Returns the direction of the dash depending on the player input
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private string GetDashDirection(Vector2 input) {
        string direction = "";
        if(input.x > 0) {
            direction = "right";
        }else if(input.x < 0) {
            direction = "left";
        }else if(input.y > 0) {
            direction = "up";
        }else if(input.y < 0) {
            direction = "down";
        }

        return direction;
    }
}
