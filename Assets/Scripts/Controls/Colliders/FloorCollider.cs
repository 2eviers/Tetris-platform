using UnityEngine;

public class FloorCollider : PlayerCollider
{
    #region Unity CallBacks

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("YOLO FLOOR TROU DE BALLE");
        _controller.OnFloor = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _controller.OnFloor = false;
    }

    #endregion Unity CallBacks
}