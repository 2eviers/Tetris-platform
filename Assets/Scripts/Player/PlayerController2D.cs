using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    #region Serialize Fields

    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private float _groundMoveForce;

    [SerializeField]
    private float _airMoveForce;

    [SerializeField]
    [Range(1, 3)]
    private float _turnOverCoefficient;

    [SerializeField]
    private float _floorJumpForce;

    [SerializeField]
    private float _wallJumpUpForce;

    [SerializeField]
    private float _wallJumpRightForce;

    #endregion Serialize Fields

    #region Fields

    private Rigidbody2D _rigidbody;
    private bool _onFloor;
    private bool _onWall;
    private int _wallDirection;
    private bool _jumpAxisDown;

    #endregion Fields

    #region Properties

    public bool OnFloor { set { _onFloor = value; } }
    public bool OnWall { set { _onWall = value; } }
    public int WallDirection { set { _wallDirection = value; } }

    #endregion Properties

    #region Unity Callbacks

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float jumpInput = Input.GetAxis("Jump");

        if (Mathf.Sign(horizontalInput) != Mathf.Sign(_rigidbody.velocity.x))
            horizontalInput = horizontalInput * _turnOverCoefficient;

        if (_onFloor)
            _rigidbody.AddForce(horizontalInput * _groundMoveForce * Vector2.right);
        else
            _rigidbody.AddForce(horizontalInput * _airMoveForce * Vector2.right);

        if (jumpInput == 0)
            _jumpAxisDown = false;
        else if (!_jumpAxisDown)
        {
            _jumpAxisDown = true;
            if (_onFloor)
                _rigidbody.AddForce(jumpInput * _floorJumpForce * Vector2.up);
            else if (_onWall)
                _rigidbody.AddForce(jumpInput * _wallJumpUpForce * Vector2.up - _wallDirection * _wallJumpRightForce * Vector2.right);
        }

        if (Mathf.Abs(_rigidbody.velocity.x) > _maxSpeed)
            _rigidbody.velocity = new Vector2(Mathf.Sign(_rigidbody.velocity.x) * _maxSpeed, _rigidbody.velocity.y);
    }

    #endregion Unity Callbacks
}