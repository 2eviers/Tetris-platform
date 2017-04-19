using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    #region Fields

    protected PlayerController2D _controller;

    #endregion Fields

    #region Unity Callbacks

    private void Start()
    {
        _controller = GetComponentInParent<PlayerController2D>();
    }

    #endregion Unity Callbacks
}