using UnityEngine;

public class BlocksMove : MonoBehaviour {

    #region Serialize Fields

    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _rotationSpeed;

    #endregion

    #region Fields

    private bool _lockRotation;
    private float _targetRotation;

    #endregion

    #region Unity Callbacks
    
    //tant que le doigt bouge on vérifie le delta (direction) et on translate

    private void Update ()
    {
        transform.Translate(_speed * Time.deltaTime * transform.InverseTransformDirection(- Vector3.up));

        if ((int)transform.rotation.eulerAngles.z != _targetRotation % 360)
            transform.Rotate(0, 0, _rotationSpeed * 0.1f);
	}

    #endregion

    #region Public Methods

    public void AddRotation()
    {
        _targetRotation += 90;
    }

    #endregion

}