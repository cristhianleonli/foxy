using UnityEngine;

public class Diamond : Collectible
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.Instance.PlayerDidGetDiamond();
        base.OnTriggerEnter2D(collision);
    }
}
