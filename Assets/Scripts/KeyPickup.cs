using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 && pickedUp == false)
        {
            pickedUp = true;
            gameObject.SetActive(false);
        }
    }
}
