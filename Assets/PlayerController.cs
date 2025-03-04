using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController Controller;

    [SerializeField]
    private float _speed = 6.0f;

    private float _jumpSpeed = 10.0f;

    [SerializeField]
    private Transform _cameraTransform;

    private Transform _playerTransform;

    private bool isGrounded = false;
    private bool hasDoubleJump = false;
    private Vector3 velocity;

    void Start()
    {
        _playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        _playerTransform.rotation = Quaternion.AngleAxis(_cameraTransform.rotation.eulerAngles.y, Vector3.up);

        Vector3 forward = _cameraTransform.forward;
        Vector3 right = Vector3.Cross(Vector3.up, forward);

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += right;
        }

        isGrounded = Controller.isGrounded;

        if (isGrounded)
        {
            velocity.y = 0f;
            hasDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                velocity.y = _jumpSpeed;
            }
            else if (hasDoubleJump)
            {
                velocity.y = _jumpSpeed;
                hasDoubleJump = false;
            }
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;

        moveDirection = moveDirection.normalized;

        Vector3 finalMove = moveDirection * _speed;
        finalMove.y = velocity.y;

        Controller.Move(finalMove * Time.deltaTime);
    }
}
