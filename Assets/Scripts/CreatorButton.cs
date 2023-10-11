using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorButton : MonoBehaviour
{
    // Sprites
    public SpriteRenderer spriteRenderer;
    public Sprite upState;
    public Sprite downState;

    // Remover
    public GameObject objectToCreate;
    public bool stayCreated = true;

    private BoxCollider2D bc;
    private SpriteRenderer sr;

    // Player
    public string playerSize;
    private LayerMask playerLayer;
    private LayerMask defaultLayer;
    private LayerMask groundLayer;

    private void Start()
    {
        bc = objectToCreate.GetComponent<BoxCollider2D>();
        sr = objectToCreate.GetComponent<SpriteRenderer>();
        playerLayer = LayerMask.NameToLayer("Player");
        defaultLayer = LayerMask.NameToLayer("Default");
        groundLayer = LayerMask.NameToLayer("Ground");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerSize == "All" && collision.gameObject.layer == playerLayer)
        {
            OnButton();
        }
        else if (collision.gameObject.tag == playerSize)
        {
            OnButton();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerSize == "All" && collision.gameObject.layer == playerLayer)
        {
            OffButton();
        }
        else if (collision.gameObject.tag == playerSize)
        {
            OffButton();
        }

    }

    private void OnButton()
    {
        spriteRenderer.sprite = downState;
        bc.isTrigger = false;

        Color objectColour = sr.color;
        objectColour.a = 1f;
        sr.color = objectColour;

        objectToCreate.layer = groundLayer;
    }

    private void OffButton()
    {
        spriteRenderer.sprite = upState;

        if (!stayCreated)
        {
            bc.isTrigger = true;

            Color objectColour = sr.color;
            objectColour.a = 0.5f;
            sr.color = objectColour;

            objectToCreate.layer = defaultLayer;
        }
    }





}
