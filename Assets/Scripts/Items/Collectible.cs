using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag($"{ObjectTag.Player}"))
        {
            animator.SetBool("collected", true);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
