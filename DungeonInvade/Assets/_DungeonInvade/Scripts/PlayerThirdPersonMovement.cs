using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSmoothTime = 0.1f;
    [SerializeField] private float _gravity;
    Vector3 moveDirection = Vector3.zero;
    float _turnSmoothVelocity;

    [SerializeField] private Transform _camera;
    CharacterController _characterController;

    public bool isWalking = false;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirection.y -= _gravity * Time.deltaTime;
            Vector3 velocity = moveDirection.normalized * _speed;

            _characterController.Move(velocity * Time.deltaTime);
            isWalking = true;
        }
        else
            isWalking = false;

        //applying gravity when idle, and not grounded
        if (!_characterController.isGrounded)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.down;
            moveDirection.y -= _gravity * Time.deltaTime;
            Vector3 velocity = moveDirection.normalized * _speed;
            _characterController.Move(velocity * Time.deltaTime);
        }
    }
}
