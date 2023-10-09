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

    private float elevatorSpeed = 0.9f;
    private float elevatorStartHeight;  
    private float elevatorEndHeight;

    // Player
    public string playerSize;
    private bool isOnButton = false;

    private void Start()
    {
        elevatorStartHeight = elevator.position.y;
        elevatorEndHeight = elevatorStartHeight + elevatorDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerSize)
        {
            isOnButton = true;
            spriteRenderer.sprite = downState;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerSize)
        {
            isOnButton = false;
            spriteRenderer.sprite = upState;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerSize && elevator.position.y <= elevatorEndHeight)
        {
            elevator.position += new Vector3(0, elevatorSpeed, 0) * Time.deltaTime;
        }
    }

    private void Update()
    {
        if (!isOnButton && elevator.position.y >= elevatorStartHeight && retractable)
        {
            elevator.position -= new Vector3(0, elevatorSpeed, 0) * Time.deltaTime;
        }
    }





}
