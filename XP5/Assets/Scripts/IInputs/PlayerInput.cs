using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInput : MonoBehaviour, IInput
{
    [SerializeField] private Vector2Variable playerSensitivity;
    [SerializeField] private GameObjectVariable cameraObject;

    private bool _canControl = true;



    public Vector2 direction
    {
        get
        {
            Vector2 gamepadMove = Vector2.zero;
            if (Gamepad.current != null)
            {
                StickControl stick = Gamepad.current.leftStick;
                gamepadMove = new Vector2(stick.right.value - stick.left.value, stick.up.value - stick.down.value);
                if (gamepadMove.magnitude < 0.5f)
                {
                    gamepadMove = Vector2.zero;
                }
            }
            Vector2 keyboardMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 move = keyboardMove + gamepadMove;
            Vector2 rotatedMove = Vector2.zero;

            if (cameraObject != null && cameraObject.Value != null)
            {
                float headAngle = Mathf.Deg2Rad * (360 - cameraObject.Value.transform.rotation.eulerAngles.y);

                Vector2 a = new Vector2(Mathf.Cos(headAngle), Mathf.Sin(headAngle));
                Vector2 b = new Vector2(-Mathf.Sin(headAngle), Mathf.Cos(headAngle));

                rotatedMove = move.x * a + move.y * b;
            }

            if (_canControl)
            {
                return cameraObject != null && cameraObject.Value != null ? rotatedMove : move;
            }
            else
            {
                return Vector2.zero;
            }
        }
    }

    public Vector2 look
    {
        get
        {
            if (!_canControl)
            {
                return Vector2.zero;
            }
            Vector2 gamepadLook = Vector2.zero;
            if (Gamepad.current != null)
            {
                StickControl stick = Gamepad.current.rightStick;
                gamepadLook = new Vector2(stick.up.value - stick.down.value, stick.right.value - stick.left.value);
            }
            Vector2 mouseLook = new Vector2(Mouse.current.delta.value.y, Mouse.current.delta.value.x) / 3;
            return mouseLook + gamepadLook;
        }
    }

    public Vector2 sensitivity
    {
        get
        {
            return playerSensitivity.Value != null ? playerSensitivity.Value : Vector2.zero;
        }
    }



    public bool startButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.startButton.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.Escape) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool startButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.startButton.isPressed;
                }
                return Input.GetKey(KeyCode.Escape) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool startButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.startButton.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.Escape) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }



    public bool aButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.buttonSouth.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.Space) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool aButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.buttonSouth.isPressed;
                }
                return Input.GetKey(KeyCode.Space) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool aButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.buttonSouth.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.Space) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }



    public bool bButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.buttonEast.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.LeftControl) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool bButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.buttonEast.isPressed;
                }
                return Input.GetKey(KeyCode.LeftControl) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool bButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.buttonEast.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.LeftControl) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }



    public bool xButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.buttonWest.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.E) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }

    public bool xButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.buttonWest.isPressed;
                }
                return Input.GetKey(KeyCode.E) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }

    public bool xButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.buttonWest.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.E) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }



    public bool yButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.buttonNorth.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.Q) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }

    public bool yButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.buttonNorth.isPressed;
                }
                return Input.GetKey(KeyCode.Q) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }

    public bool yButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.buttonNorth.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.Q) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }



    public bool dPadDownButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.dpad.down.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.DownArrow) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadDownButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.dpad.down.isPressed;
                }
                return Input.GetKey(KeyCode.DownArrow) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadDownButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.dpad.down.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.DownArrow) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }



    public bool dPadRightButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.dpad.right.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.RightArrow) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadRightButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.dpad.right.isPressed;
                }
                return Input.GetKey(KeyCode.RightArrow) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadRightButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadA = false;
                if (Gamepad.current != null)
                {
                    gamepadA = Gamepad.current.dpad.right.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.RightArrow) || gamepadA;
            }
            else
            {
                return false;
            }
        }
    }



    public bool dPadLeftButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.dpad.left.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.LeftArrow) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadLeftButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.dpad.left.isPressed;
                }
                return Input.GetKey(KeyCode.LeftArrow) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadLeftButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.dpad.left.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.LeftArrow) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }



    public bool dPadUpButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.dpad.up.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.UpArrow) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadUpButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.dpad.up.isPressed;
                }
                return Input.GetKey(KeyCode.UpArrow) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }

    public bool dPadUpButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadX = false;
                if (Gamepad.current != null)
                {
                    gamepadX = Gamepad.current.dpad.up.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.UpArrow) || gamepadX;
            }
            else
            {
                return false;
            }
        }
    }



    public bool fireButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadFire = false;
                if (Gamepad.current != null)
                {
                    gamepadFire = Gamepad.current.rightTrigger.wasPressedThisFrame;
                }
                return Input.GetMouseButtonDown(0) || gamepadFire;
            }
            else
            {
                return false;
            }
        }
    }

    public bool fireButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadFire = false;
                if (Gamepad.current != null)
                {
                    gamepadFire = Gamepad.current.rightTrigger.isPressed;
                }
                return Input.GetMouseButton(0) || gamepadFire;
            }
            else
            {
                return false;
            }
        }
    }

    public bool fireButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadFire = false;
                if (Gamepad.current != null)
                {
                    gamepadFire = Gamepad.current.rightTrigger.wasReleasedThisFrame;
                }
                return Input.GetMouseButtonUp(0) || gamepadFire;
            }
            else
            {
                return false;
            }
        }
    }



    public bool subFireButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadFire = false;
                if (Gamepad.current != null)
                {
                    gamepadFire = Gamepad.current.rightShoulder.wasPressedThisFrame;
                }
                return Input.GetKeyDown(KeyCode.Q) || gamepadFire;
            }
            else
            {
                return false;
            }
        }
    }

    public bool subFireButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadFire = false;
                if (Gamepad.current != null)
                {
                    gamepadFire = Gamepad.current.rightShoulder.isPressed;
                }
                return Input.GetKey(KeyCode.Q) || gamepadFire;
            }
            else
            {
                return false;
            }
        }
    }

    public bool subFireButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadFire = false;
                if (Gamepad.current != null)
                {
                    gamepadFire = Gamepad.current.rightShoulder.wasReleasedThisFrame;
                }
                return Input.GetKeyUp(KeyCode.Q) || gamepadFire;
            }
            else
            {
                return false;
            }
        }
    }



    public bool aimButtonDown
    {
        get
        {
            if (_canControl)
            {
                bool gamepadFire = false;
                if (Gamepad.current != null)
                {
                    gamepadFire = Gamepad.current.leftTrigger.wasPressedThisFrame;
                }
                return Input.GetMouseButtonDown(1) || gamepadFire;
            }
            else
            {
                return false;
            }
        }
    }

    public bool aimButton
    {
        get
        {
            if (_canControl)
            {
                bool gamepadAim = false;
                if (Gamepad.current != null)
                {
                    gamepadAim = Gamepad.current.leftTrigger.isPressed;
                }
                return Input.GetMouseButton(1) || gamepadAim;
            }
            else
            {
                return false;
            }
        }
    }

    public bool aimButtonUp
    {
        get
        {
            if (_canControl)
            {
                bool gamepadFire = false;
                if (Gamepad.current != null)
                {
                    gamepadFire = Gamepad.current.leftTrigger.wasReleasedThisFrame;
                }
                return Input.GetMouseButtonUp(1) || gamepadFire;
            }
            else
            {
                return false;
            }
        }
    }



    public bool subAimButtonDown
    {
        get
        {
            if (_canControl)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }

    public bool subAimButton
    {
        get
        {
            if (_canControl)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }

    public bool subAimButtonUp
    {
        get
        {
            if (_canControl)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}