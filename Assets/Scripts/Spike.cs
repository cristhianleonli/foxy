﻿using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag($"{ObjectTag.Player}"))
        {
            GameController.Instance.PlayerGotDamage();
        }
    }
}
