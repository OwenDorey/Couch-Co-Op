using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonLeft : MonoBehaviour
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
    private float elevatorStartX;  
    private float elevatorEndX;

    // Player
    public string playerSize;
    private bool isOnButton = false;
    private LayerMask playerLayer;

    private void Start()
    {
        elevatorStartX = elevator.position.x;
        elevatorEndX = elevatorStartX - elevatorDistance;
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
        if (playerSize == "All" && collision.gameObject.layer == playerLayer && elevator.position.x >= elevatorEndX)
        {
            MoveUp();
        }
        else if (collision.gameObject.tag == playerSize && elevator.position.x >= elevatorEndX)
        {
            MoveUp();
        }
    }

    private void MoveUp()
    {
        elevator.position -= new Vector3(elevatorSpeed, 0, 0) * Time.deltaTime;
    }

    private void Update()
    {
        if (!isOnButton && elevator.position.x <= elevatorStartX && retractable)
        {
            elevator.position += new Vector3(elevatorSpeed, 0, 0) * Time.deltaTime;
        }
    }





}
