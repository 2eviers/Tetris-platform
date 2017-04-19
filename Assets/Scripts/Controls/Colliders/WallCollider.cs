using UnityEngine;

public class WallCollider : PlayerCollider
{
    #region Unity CallBacks

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("WALL ENCULE");
        _controller.OnWall = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _controller.OnWall = false;
    }

    #endregion Unity CallBacks
}