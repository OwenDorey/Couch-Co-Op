using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoverButton : MonoBehaviour
{
    // Sprites
    public SpriteRenderer spriteRenderer;
    public Sprite upState;
    public Sprite downState;

    // Remover
    public GameObject objectToRemove;
    public bool stayRemoved = true;

    private BoxCollider2D bc;
    private SpriteRenderer sr;

    // Player
    public string playerSize;

    private void Start()
    {
        bc = objectToRemove.GetComponent<BoxCollider2D>();
        sr = objectToRemove.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerSize)
        {
            spriteRenderer.sprite = downState;
            bc.isTrigger = true;
 
            Color objectColour = sr.color;
            objectColour.a = 0.5f;
            sr.color = objectColour;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerSize)
        {
            spriteRenderer.sprite = upState;

            if (!stayRemoved)
            {
                bc.isTrigger = false;

                Color objectColour = sr.color;
                objectColour.a = 1f;
                sr.color = objectColour;
            }
        }

    }





}
