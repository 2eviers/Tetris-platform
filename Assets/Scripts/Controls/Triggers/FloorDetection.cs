using UnityEngine;

public class FloorDetection : SurfaceDetection
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    _controller.OnFloor = true;
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        _controller.OnFloor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _controller.OnFloor = false;
    }
}