using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerControllerMy : MonoBehaviour
{
    //public CharacterController characterController;
    //public float speed = 5.0f;

    //required input
    private InputHandler _input;

    //optional
    [SerializeField]
    private bool RotateTowardMouse;

    //player option
    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;

    //cam for player
    [SerializeField]
    private Camera Camera;

    //gun summon bullet
    //[SerializeField] private Transform Spawnpoint; 

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    void Update()
    {
        //PlayerMove();

        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector);

        //if (!RotateTowardMouse) //avoid annoying non-intention hit, by remove player rotation
        //{
        //    RotateTowardMovementVector(movementVector);
        //}
        //if (RotateTowardMouse)
        //{
        //    RotateFromMouseVector();
        //}

        if (Input.GetKeyDown(KeyCode.Mouse0)) //left mouse click for draging block, later on
        {

        }
    }

    /*
    private void PlayerMove()
    {
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * HorizontalMove + transform.right * VerticalMove;
        characterController.Move(speed * Time.deltaTime * move);   
    }
    */

    private void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if (movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }
}
