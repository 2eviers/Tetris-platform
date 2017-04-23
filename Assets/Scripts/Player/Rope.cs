using UnityEngine;

public class Rope : MonoBehaviour
{
    #region Serialize Fields

    [SerializeField]
    private float _ropeLenght;

    #endregion Serialize Fields

    #region Fields

    private DistanceJoint2D _distanceJoint;
    private LineRenderer _ropeRenderer;
    private bool _anchored;
    private Vector3 _connectorPosition;
    private Transform _jointTransform;

    #endregion Fields

    #region Unity Callbacks

    private void Start()
    {
        _ropeRenderer = GetComponent<LineRenderer>();
        _distanceJoint = GetComponent<DistanceJoint2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LayerMask layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit2D hitInfo = Physics2D.Raycast
                (
                transform.position, new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0) - transform.position,
                _ropeLenght,
                layerMask
                );

            if (hitInfo.collider != null)
            {
                _anchored = true;
                _jointTransform = hitInfo.collider.transform;
                _connectorPosition = hitInfo.collider.transform.InverseTransformPoint(hitInfo.point);

                _distanceJoint.enabled = true;
                _distanceJoint.connectedBody = hitInfo.collider.attachedRigidbody;
                _distanceJoint.connectedAnchor = _connectorPosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _anchored = false;
            _distanceJoint.enabled = false;
            _ropeRenderer.SetPosition(0, Vector3.zero);
            _ropeRenderer.SetPosition(1, Vector3.zero);
        }

        if (_anchored)
        {
            _ropeRenderer.SetPosition(0, transform.position);
            _ropeRenderer.SetPosition(1, _connectorPosition + _jointTransform.position);
        }
    }

    #endregion Unity Callbacks
}