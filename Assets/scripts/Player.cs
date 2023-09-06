using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;
    private float _initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isChopping;
    private bool _isDigging;

    // Reference the body
    private Rigidbody2D rig;
    // Reference the direction movements
    private Vector2 _direction;

    // Access direction
    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool IsRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool IsRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }
    public bool IsChopping { get => _isChopping; set => _isChopping = value; }
    public bool IsDigging { get => _isDigging; set => _isDigging = value; }


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        _initialSpeed = _speed;
    }

    private void Update()
    {
        // +1 if RIGHT or UP, -1 if LEFT or DOWN
        OnInput();
        OnRun();
        OnRoll();
        OnChop();
        OnDig();
    }

    private void FixedUpdate()
    {
        // Get current position + Add direction * Speed for movement speed
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }
    void OnRun()
    {
        // * Make player run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = _runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _initialSpeed;
            _isRunning = false;
        }

    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _speed * Time.fixedDeltaTime * _direction);

    }

    void OnRoll()
    {
        // Right click
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
        }
    }
    #endregion

    void OnChop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _isChopping = true;
            _speed = 0;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            _isChopping = false;
            _speed = _initialSpeed;
        }
    }

    void OnDig()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _isDigging = true;
            _speed = 0;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            _isDigging = false;
            _speed = _initialSpeed;
        }
    }
    void Jump() { }
    void Attack() { }

}
