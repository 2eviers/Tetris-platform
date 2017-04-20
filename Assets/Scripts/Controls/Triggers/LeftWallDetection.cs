using UnityEngine;

public class LeftWallDetection : SurfaceDetection
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _controller.OnWall = true;
        _controller.WallDirection = -1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _controller.OnWall = false;
    }
}