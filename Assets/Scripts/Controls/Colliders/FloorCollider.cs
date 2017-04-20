using UnityEngine;

public class FloorCollider : PlayerCollider
{
    #region Unity CallBacks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Floor collision");
        _controller.OnFloor = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _controller.OnFloor = false;
    }

    #endregion Unity CallBacks
}