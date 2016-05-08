using UnityEngine;
using System.Collections;


[System.Serializable]
public struct Keys
{
    public KeyCode forwardKey;
    public KeyCode backKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

}

public class playermovement : MonoBehaviour
{
    public enum InputType
    {
        kbm,
        gamepad,
    };
    public InputType inputType;

    Keys keys;
    public float moveSpeed;

    Transform anchor;
    Transform cam;

    bool forward;
    bool back;
    bool left;
    bool right;
    public float xMove;
    public float zMove;

    float camXRote;
    public float camYRote;
    public float camSensitivity;

    Rigidbody reggie;
	void Start ()
	{
        anchor = GameObject.Find("camAnchor").transform;
        cam = Camera.main.transform;
        reggie = GetComponent<Rigidbody>();

        keys.forwardKey = KeyCode.W;
        keys.backKey = KeyCode.S;
        keys.leftKey = KeyCode.A;
        keys.rightKey = KeyCode.D;
	}
	
	void Update ()
	{
        checkMove();
        moveCam();
	}
    void FixedUpdate()
    {
        move(transform.forward, forward);
        move(-transform.forward, back);
        move(transform.right, right);
        move(-transform.right, left);

        if(forward && back
        || left && right)
        {
            move(Vector3.zero);
        }

        move(transform.forward + transform.right, forward, right);
        move(transform.forward - transform.right, forward, left);
        move(-transform.forward + transform.right, back, right);
        move(-transform.forward - transform.right, back, left);

        if (inputType == InputType.gamepad)
        {
            Vector3 direction = Vector3.zero;
            if (zMove > 0.3
            || zMove < -0.3)
            {
                direction += transform.forward * zMove * moveSpeed;
            }
            if (xMove > 0.3
            || xMove < -0.3)
            {
                direction += transform.right * xMove * moveSpeed;
            }

            move(direction);
        }
    }

    public void checkMove()
    {
        cam.position = anchor.position;
        switch (inputType)
        {
            case InputType.kbm:
                forward = Input.GetKey(keys.forwardKey);
                back = Input.GetKey(keys.backKey);
                left = Input.GetKey(keys.leftKey);
                right = Input.GetKey(keys.rightKey);

                camXRote = Input.GetAxisRaw("Mouse Y") * camSensitivity;
                camYRote = Input.GetAxisRaw("Mouse X") * camSensitivity;
                break;

            case InputType.gamepad:
                xMove = Input.GetAxisRaw("LStick X");
                zMove = Input.GetAxisRaw("LStick Y");
                camXRote = Input.GetAxisRaw("RStick Y") * camSensitivity;
                camYRote = Input.GetAxisRaw("RStick X") * camSensitivity;
                break;
            default:
                break;
        }

    }

    public void move(Vector3 _direction, bool _input1 = true , bool _input2 = true)
    {
        if(_input1
        && _input2)
        {
            transform.position = Vector3.Slerp(transform.position, transform.position + _direction * moveSpeed, 0.2f);
        }
    }
    public void moveCam()
    {
        if(camYRote > 0.3
        || camYRote < -0.3)
        {
            transform.Rotate(0, camYRote, 0);
        }        

    //  anchor.Rotate(-camXRote, 0, 0);
        if (cam.rotation != anchor.rotation)
        {
            cam.rotation = Quaternion.Lerp(cam.rotation, anchor.rotation, 0.2f);
        }
    //  cam.rotation = anchor.rotation;
    }
}
