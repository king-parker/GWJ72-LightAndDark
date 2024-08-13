using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export] private float _speed = 100.0f;
    [Export] private float _jumpSpeed = 300.0f;
    [Export] private float _gravity = 15.0f;

    private Vector2 _velocity = new Vector2();
    private bool _isJumping = false;
    private bool _isAlive = true;
    private bool _hasDoubleJump = true;
    private AnimatedSprite _characterAnimation;
    private AudioStreamPlayer2D _jumpSound;
    private Timer _coyoteTimer;
    private Timer _jumpBufferTimer;
    private Timer _shortHopTimer;
    // private GameManager _gameManager;

    public override void _Ready()
    {
        _isAlive = true;

        _characterAnimation = GetNode<AnimatedSprite>("CharacterAnimation");
        _characterAnimation.Play("default");

        _jumpSound = GetNode<AudioStreamPlayer2D>("Sounds/JumpSound");

        _coyoteTimer = GetNode<Timer>("Timers/CoyoteTimer");
        _coyoteTimer.Stop();

        _jumpBufferTimer = GetNode<Timer>("Timers/JumpBufferTimer");
        _jumpBufferTimer.Stop();

        _shortHopTimer = GetNode<Timer>("Timers/ShortHopTimer");
        _shortHopTimer.Stop();

        // _gameManager = GetNode<GameManager>("/root/GameManager");
        // _gameManager.Connect("PlayerDeathEvent", this, "OnDeath");
    }

    public override void _PhysicsProcess(float delta)
    {
        // if (!_isAlive)
        // {
        //     _characterAnimation.Play("jump");
        //     _velocity.y += _gravity / 4;
        //     MoveAndSlide(_velocity, new Vector2(0, -1));
        //     return;
        // }

        // Add the gravity.
        if (!IsOnFloor())
        {
            _velocity.y += _gravity;
            if (_velocity.y > 0 && _isJumping)
            {
                _isJumping = false;
            }
        }

        // Handle jump.
        if (Input.IsActionJustPressed("jump"))
        {
            _jumpBufferTimer.Start();
            if (IsOnFloor() || !_coyoteTimer.IsStopped() || _hasDoubleJump)
            {
                PlayerJump();
            }
        }
        else if (IsOnFloor() && !_jumpBufferTimer.IsStopped())
        {
            PlayerJump();
        }

        if (!Input.IsActionPressed("jump") && _isJumping && _shortHopTimer.IsStopped())
        {
            _velocity.y = 0;
            _isJumping = false;
        }

        // Get the input direction.
        float direction = Input.GetAxis("move_left", "move_right");
        _velocity.x = direction * _speed;

        if (direction > 0)
        {
            _characterAnimation.FlipH = false;
        }
        else if (direction < 0)
        {
            _characterAnimation.FlipH = true;
        }

        // // Choose player animation
        // if (IsOnFloor() || !_coyoteTimer.IsStopped())
        // {    
        //     if (direction == 0) _characterAnimation.Play("idle");
        //     else _characterAnimation.Play("run");
        // }
        // else
        // {
        //     _characterAnimation.Play("jump");
        // }

        // Call MoveAndSlide
        bool wasOnFloor = IsOnFloor();
        _velocity = MoveAndSlide(_velocity, new Vector2(0, -1));

        // Start Coyote timer if not on floor
        if (wasOnFloor && !IsOnFloor())
        {
            _coyoteTimer.Start();
        }

        // Reset double jump?
        if (IsOnFloor())
        {
            _hasDoubleJump = true;
        }
    }

    private void PlayerJump()
    {
        _velocity.y = -_jumpSpeed;
        _jumpSound.Play();
        _isJumping = true;
        _shortHopTimer.Start();
        if (_hasDoubleJump && !IsOnFloor() && _coyoteTimer.IsStopped())
        {
            _hasDoubleJump = false;
        }
    }

    private void OnDeath()
    {
        _isAlive = false;
    }

}