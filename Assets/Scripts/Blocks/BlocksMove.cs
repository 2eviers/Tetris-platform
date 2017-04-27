using UnityEngine;
using System.Linq;

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
    private Bounds _boundingBox;
    //private Rigidbody2D _rigidbody;

    #endregion Fields

    #region Unity Callbacks

    //tant que le doigt bouge on vérifie le delta (direction) et on translate

    private void Start()
    {
        //_rigidbody = GetComponent<Rigidbody2D>();
        SetBoundingBox();
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * transform.InverseTransformDirection(-Vector3.up));

        if ((int)transform.rotation.eulerAngles.z != _targetRotation % 360) //ATTENTION A LA SYNCHRO COLLISION UPDATE, légère différence à l'arrivé.
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

            //Il faut rechecker la collision après transform
            enabled = false;
            //UTILISER LES CONTRAINTES AUSSI
        }
    }

    #endregion Unity Callbacks

    //Utiliser raycast all plus tard quand un piece s'arrete completement
    //dans le meme event, checker si on est enfermé

    #region Private Methods

    private void FixeTransform()
    {
        int i = Mathf.RoundToInt(transform.rotation.eulerAngles.z / 90);
        transform.rotation = Quaternion.Euler(0, 0, i * 90);

        //transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), transform.position.y);
        //en fonction de la taille et de la rotation, regarder si on arrondie sur 0.5 ou 1;
        float horizontalSize = transform.rotation.z % 180 == 0 ? _boundingBox.size.x : _boundingBox.size.y;
        if (horizontalSize % 2 == 0)
        {
            transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), transform.position.y); //FACTORISER SUREMENT
        }
        else
        {
            //autre
            //utiliser le modulo je pense
        }
    }

    private void SetBoundingBox()
    {
        Transform[] childstransform = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            childstransform[i] = transform.GetChild(i);

        float extendX = childstransform.Max(tr => tr.localPosition.x + tr.localScale.x / 2);
        float extendY = childstransform.Max(tr => tr.localPosition.y + tr.localScale.y / 2);
        Vector3 size = new Vector3(extendX * 2, extendY * 2, 0);
        _boundingBox = new Bounds(transform.position, size);
    }

    #endregion Private Methods

    #region Public Methods

    public void AddRotation()
    {
        _targetRotation += 90;
    }

    #endregion Public Methods
}