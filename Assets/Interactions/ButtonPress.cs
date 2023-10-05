using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Animator buttonPress;
    public Transform elevator;
    public float elevatorSpeed = 0.1f;

    private bool isOnButton = false;

    private float elevatorStartHeight;
    public float elevatorDistance = 5f;
    private float elevatorEndHeight;

    private void Start()
    {
        elevatorStartHeight = elevator.position.y;
        elevatorEndHeight = elevatorStartHeight + elevatorDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallPlayer")
        {
            isOnButton = true;
            buttonPress.SetTrigger("Press");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallPlayer")
        {
            isOnButton = false;
            buttonPress.SetTrigger("Lift");
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallPlayer" && elevator.position.y <= elevatorEndHeight)
        {
            elevator.position += new Vector3(0, elevatorSpeed, 0) * Time.deltaTime;
        }
    }

    private void Update()
    {
        if (!isOnButton && elevator.position.y >= elevatorStartHeight)
        {
            elevator.position -= new Vector3(0, elevatorSpeed, 0) * Time.deltaTime;
        }
    }




}
