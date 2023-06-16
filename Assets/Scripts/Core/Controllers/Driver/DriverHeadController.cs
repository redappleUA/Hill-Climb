using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverHeadController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameOverController.instance.GameOver();
        }
    }
}
