using UnityEngine;

public class BlocksMove : MonoBehaviour
{
    #region Serialize Fields

    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _rotationSpeed;

    #endregion Serialize Fields

    #region Fields

    private bool _lockRotation;
    private float _targetRotation;
    //private Rigidbody2D _rigidbody;

    #endregion Fields

    #region Unity Callbacks

    //tant que le doigt bouge on vérifie le delta (direction) et on translate

    //private void Start()
    //{
    //    _rigidbody = GetComponent<Rigidbody2D>();
    //}

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * transform.InverseTransformDirection(-Vector3.up));

        if ((int)transform.rotation.eulerAngles.z != _targetRotation % 360)
            transform.Rotate(0, 0, _rotationSpeed * 0.1f);

        if (Input.GetKeyDown(KeyCode.Return))
            AddRotation();
    }

    //private void FixedUpdate()
    //{
    //    _rigidbody.MovePosition(_rigidbody.position - _speed * Vector2.up * Time.deltaTime);

    //    if ((int)_rigidbody.rotation != _targetRotation % 360)
    //        _rigidbody.MoveRotation(_rigidbody.rotation + _rotationSpeed * 0.1f);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Block")
        {
            FixeTransform();
            enabled = false;
        }
    }

    #endregion Unity Callbacks

    #region Private Methods

    private void FixeTransform()
    {
        int i = Mathf.RoundToInt(transform.rotation.eulerAngles.z / 90);
        transform.rotation = Quaternion.Euler(0, 0, i * 90);
    }

    #endregion Private Methods

    #region Public Methods

    public void AddRotation()
    {
        _targetRotation += 90;
    }

    #endregion Public Methods
}