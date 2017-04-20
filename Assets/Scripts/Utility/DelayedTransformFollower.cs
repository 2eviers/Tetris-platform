using UnityEngine;

public class DelayedTransformFollower : MonoBehaviour
{
    #region Serialize Fieds

    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Vector3 _Offset;

    #endregion

    #region Unity Callbacks

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetTransform.position + _Offset, Time.deltaTime);
    }

    #endregion
}
