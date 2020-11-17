using UnityEngine;

public class Cherry : Collectible
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.Instance.PlayerDidGetCherry();
        base.OnTriggerEnter2D(collision);
    }
}