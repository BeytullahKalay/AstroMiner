using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerRenderer;
    
    public bool IsSpriteFlipped => playerRenderer.flipX;

    internal void RenderPlayer(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.x) > 0.1f)
            playerRenderer.flipX = Vector3.Dot(transform.right, movementVector) < 0;
    }
}
