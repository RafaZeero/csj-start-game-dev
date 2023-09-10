using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public PlayerItems playerItems;
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;
    private float _initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isChopping;
    private bool _isDigging;
    private bool _isWatering;

    private int _handlingObj = 1;

    // Reference the body
    private Rigidbody2D rig;
    // Reference the direction movements
    private Vector2 _direction;

    // Access direction
    public Vector2 Direction { get => _direction; set => _direction = value; }
    public bool IsRunning { get => _isRunning; set => _isRunning = value; }
    public bool IsRolling { get => _isRolling; set => _isRolling = value; }
    public bool IsChopping { get => _isChopping; set => _isChopping = value; }
    public bool IsDigging { get => _isDigging; set => _isDigging = value; }
    public bool IsWatering { get => _isWatering; set => _isWatering = value; }

    private void Start()
    {
        playerItems = GetComponent<PlayerItems>();
        rig = GetComponent<Rigidbody2D>();
        _initialSpeed = _speed;
    }

    private void Update()
    {
        ChangeHandObj();

        // +1 if RIGHT or UP, -1 if LEFT or DOWN
        OnInput();
        OnRun();
        OnRoll();
        OnChop();
        OnDig();
        OnWatering();
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
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _isRolling = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _isRolling = false;
        }
    }
    #endregion
    #region Actions
    void OnChop()
    {
        if (_handlingObj == 1)
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
    }

    void OnDig()
    {
        if (_handlingObj == 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isDigging = true;
                _speed = 0;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                _isDigging = false;
                _speed = _initialSpeed;
            }
        }
    }
    void OnWatering()
    {
        if (_handlingObj == 3)
        {
            if (Input.GetKeyDown(KeyCode.E) && playerItems.CurrentWater > 0)
            {
                _isWatering = true;
                _speed = 0;
                playerItems.CurrentWater--;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                _isWatering = false;
                _speed = _initialSpeed;
            }
        }
    }
    #endregion
    void ChangeHandObj()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { _handlingObj = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { _handlingObj = 2; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { _handlingObj = 3; }
    }
    void Jump() { }
    void Attack() { }

}
