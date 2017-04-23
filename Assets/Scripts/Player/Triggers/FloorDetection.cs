using UnityEngine;

public class FloorDetection : SurfaceDetection
{
    #region Unity Callbacks

    private void OnTriggerStay2D(Collider2D collision)
    {
        _controller.OnFloor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _controller.OnFloor = false;
    }

    #endregion
}