using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    // Sprites
    public SpriteRenderer spriteRenderer;
    public Sprite upState;
    public Sprite downState;

    // Elevator
    public Transform elevator;
    public float elevatorDistance = 5f;
    public bool retractable = true;

    private float elevatorSpeed = 1.2f;
    private float elevatorStartHeight;  
    private float elevatorEndHeight;

    // Player
    public string playerSize;
    private bool isOnButton = false;
    private LayerMask playerLayer;

    private void Start()
    {
        elevatorStartHeight = elevator.position.y;
        elevatorEndHeight = elevatorStartHeight + elevatorDistance;
        playerLayer = LayerMask.NameToLayer("Player");
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

    private void OnButton()
    {
        isOnButton = true;
        spriteRenderer.sprite = downState;
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

    private void OffButton()
    {
        isOnButton = false;
        spriteRenderer.sprite = upState;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerSize == "All" && collision.gameObject.layer == playerLayer && elevator.position.y <= elevatorEndHeight)
        {
            MoveUp();
        }
        else if (collision.gameObject.tag == playerSize && elevator.position.y <= elevatorEndHeight)
        {
            MoveUp();
        }
    }

    private void MoveUp()
    {
        elevator.position += new Vector3(0, elevatorSpeed, 0) * Time.deltaTime;
    }

    private void Update()
    {
        if (!isOnButton && elevator.position.y >= elevatorStartHeight && retractable)
        {
            elevator.position -= new Vector3(0, elevatorSpeed, 0) * Time.deltaTime;
        }
    }





}
