using UnityEngine;

public class RightWallDetection : SurfaceDetection
{
    #region Unity Callbacks

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Border")
        {
            _controller.OnWall = true;
            _controller.WallDirection = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _controller.OnWall = false;
    }

    #endregion
}