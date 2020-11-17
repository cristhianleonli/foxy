using UnityEngine;

public class Frog : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag($"{ObjectTag.Player}"))
        {
            GameController.Instance.PlayerGotDamage();
        }
    }
}
