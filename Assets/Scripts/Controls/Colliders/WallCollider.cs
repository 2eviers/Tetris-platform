using UnityEngine;

public class WallCollider : PlayerCollider
{
    #region Unity CallBacks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("wall collision");
        if (collision.contacts.Length != 0)
            _controller.WallDirection = (int)Mathf.Sign(collision.contacts[0].point.x - transform.position.x);
        _controller.OnWall = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _controller.OnWall = false;
    }

    #endregion Unity CallBacks
}