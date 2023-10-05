using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Animator buttonPress;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buttonPress.SetTrigger("Press");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonPress.SetTrigger("Lift");
    }

    
}
