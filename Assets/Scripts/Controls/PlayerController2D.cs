using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    #region Serialize Fields

    [SerializeField]
    private float _HorizontalCoeffcient;

    [SerializeField]
    private float _JumpCoefficient;

    #endregion Serialize Fields

    #region Fields

    private Rigidbody2D _rigidbody;
    private bool _onFloor;
    private bool _onWall;

    #endregion Fields

    #region Properties

    public bool OnFloor { set { _onFloor = value; } }
    public bool OnWall { set { _onWall = value; } }

    #endregion Properties

    #region Unity Callbacks

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.AddForce(Input.GetAxis("Horizontal") * _HorizontalCoeffcient * Vector2.right);

        if (Input.GetKeyDown(KeyCode.Space)) // A CHANGER
            _rigidbody.AddForce(Input.GetAxis("Jump") * _JumpCoefficient * Vector2.up);

        //Debug.Log("Floor : " + _onFloor + ", Wall : " + _onWall);
    }

    //private void FixedUpdate()
    //{
    //}

    ////A REFACTO surement
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    ContactPoint2D firstContactPoint = collision.contacts[0];
    //    ContactPoint2D lastContactPoint = collision.contacts[collision.contacts.Length - 1];

    //    //boolean de contact a enlever avec collision exit

    //    Debug.DrawLine(transform.position, firstContactPoint.point, Color.green, 1);
    //    Debug.DrawLine(transform.position, lastContactPoint.point, Color.red, 1);

    //    int result = FindContactType(firstContactPoint.point, lastContactPoint.point, (BoxCollider2D)collision.collider); // sinon void
    //    if (result == 1)
    //        _onFloor = true;
    //    else if (result == 2)
    //        _onWall = true;
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    _onWall = false;
    //    _onFloor = false;
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    ContactPoint2D firstContactPoint = collision.contacts[0];
    //    ContactPoint2D lastContactPoint = collision.contacts[collision.contacts.Length - 1];
    //    Debug.DrawLine(transform.position, firstContactPoint.point, Color.green);
    //    Debug.DrawLine(transform.position, lastContactPoint.point, Color.red);
    //}

    //#endregion Unity Callbacks

    //#region Private Methods

    //private int FindContactType(Vector2 firstContactPoint, Vector2 lastContactPoint, BoxCollider2D selfCollider)
    //{
    //    float width = selfCollider.size.x;
    //    float height = selfCollider.size.y;

    //    float a = Mathf.Abs(firstContactPoint.x - transform.position.x);
    //    float b = Mathf.Abs(lastContactPoint.x - transform.position.x);
    //    float c = firstContactPoint.y - transform.position.y;
    //    float d = lastContactPoint.y - transform.position.y;

    //    if (c <= transform.position.y - height + 0.01f && d <= transform.position.y - height + 0.01f)
    //        return 1;

    //    if (a >= width - 0.01f && b >= width - 0.01f)
    //        return 2;

    //    return 0;
    //}

    #endregion Unity Callbacks
}