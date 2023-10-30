using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject target;
    public Quaternion nextRotation;
    public Vector2 _move;
    public Vector2 _look;
    public Vector3 nextPosition;

    public float rotationPower = 0.1f;
    public float rotationLerp = 0.3f;
    public float speed = 0.3f;
    public static bool isPaused;

    public void OnLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }
    public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }
    
	void Update ()
	{
        if (!PauseMenuToggle.isPaused) {
                    Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        transform.rotation *= Quaternion.AngleAxis(mouseDelta.x * rotationPower, Vector3.up);
        target.transform.rotation *= Quaternion.AngleAxis(-mouseDelta.y * rotationPower, Vector3.right);



        transform.rotation *= Quaternion.AngleAxis(_look.x * rotationPower, Vector3.up);

        target.transform.rotation *= Quaternion.AngleAxis(_look.y * rotationPower, Vector3.right);
        var angles = target.transform.localEulerAngles;
        angles.z = 0;
        //clamping
        var angle = target.transform.localEulerAngles.x;

        //Clamp the Up/Down rotation
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if(angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        transform.transform.localEulerAngles = angles;
        
        nextRotation = Quaternion.Lerp(target.transform.rotation, nextRotation, Time.deltaTime * rotationLerp);

        if (_move.x == 0 && _move.y == 0) {
            nextPosition = transform.position;
            return; 
        }

        //rotation
        float moveSpeed = speed / 100f;
        Vector3 position = (transform.forward * _move.y * moveSpeed) + (transform.right * _move.x * moveSpeed);
        nextPosition = transform.position + position; 

        transform.rotation = Quaternion.Euler(0, target.transform.rotation.eulerAngles.y, 0);
        target.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
        }
    }

}
