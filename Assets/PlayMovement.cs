using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    private CharacterController character_controller;
    private Vector3 move_direction;
    public float speed = 5f;
    private float gravity = 20f;
    public float jump_force = 10f;
    private float vertical_velocity;

    void Awake()
    {
        character_controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }

    void MoveThePlayer()
    {
        move_direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move_direction = transform.TransformDirection(move_direction); // from local st world
        move_direction *= speed * Time.deltaTime;
        character_controller.Move(move_direction);
    }

}
