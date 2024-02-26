using UnityEngine;

public interface IInput
{
    Vector2 direction { get; }
    Vector2 look { get; }
    Vector2 sensitivity { get; }

    bool startButtonDown { get; }
    bool startButton { get; }
    bool startButtonUp { get; }



    bool aButtonDown { get; }
    bool aButton { get; }
    bool aButtonUp { get; }

    bool bButtonDown { get; }
    bool bButton { get; }
    bool bButtonUp { get; }

    bool xButtonDown { get; }
    bool xButton { get; }
    bool xButtonUp { get; }

    bool yButtonDown { get; }
    bool yButton { get; }
    bool yButtonUp { get; }



    bool dPadDownButtonDown { get; }
    bool dPadDownButton { get; }
    bool dPadDownButtonUp { get; }

    bool dPadRightButtonDown { get; }
    bool dPadRightButton { get; }
    bool dPadRightButtonUp { get; }

    bool dPadLeftButtonDown { get; }
    bool dPadLeftButton { get; }
    bool dPadLeftButtonUp { get; }

    bool dPadUpButtonDown { get; }
    bool dPadUpButton { get; }
    bool dPadUpButtonUp { get; }



    bool fireButtonDown { get; }
    bool fireButton { get; }
    bool fireButtonUp { get; }

    bool subFireButtonDown { get; }
    bool subFireButton { get; }
    bool subFireButtonUp { get; }

    bool aimButtonDown { get; }
    bool aimButton { get; }
    bool aimButtonUp { get; }

    bool subAimButtonDown { get; }
    bool subAimButton { get; }
    bool subAimButtonUp { get; }
}