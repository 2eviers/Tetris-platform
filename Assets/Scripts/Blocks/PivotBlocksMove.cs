using UnityEngine;

public class PivotBlocksMove : MonoBehaviour
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
    private Transform _rotationTransform;

    #endregion Fields

    #region Unity Callbacks

    //tant que le doigt bouge on vérifie le delta (direction) et on translate
    private void Start()
    {
        _rotationTransform = transform.GetChild(0);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * transform.InverseTransformDirection(-Vector3.up));

        if ((int)_rotationTransform.rotation.eulerAngles.z != _targetRotation % 360)
            _rotationTransform.Rotate(0, 0, _rotationSpeed * 0.1f);

        if (Input.GetKeyDown(KeyCode.Return))
            AddRotation();
    }

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
        int i = Mathf.RoundToInt(_rotationTransform.rotation.eulerAngles.z / 90);
        _rotationTransform.rotation = Quaternion.Euler(0, 0, i * 90);

        transform.position = new Vector2(Mathf.RoundToInt(transform.position.x), transform.position.y);
        //attention, ça dépend de la rotation et du nb de blocks horizontales
        //Sinon faut jouer avec un pivot en plus
    }

    #endregion Private Methods

    #region Public Methods

    public void AddRotation()
    {
        _targetRotation += 90;
    }

    #endregion Public Methods
}