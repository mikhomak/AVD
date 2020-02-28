using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float racoonSpeed;
    [SerializeField] private float additionalGravity;
    [SerializeField] private float maximumDownSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float eagleJumpForce;
    [SerializeField] private float eagleSpeed = 15f;
    [SerializeField] private float groundDistanceCheck;

    public float Speed {
        get => speed;
        set => speed = value;
    }


    public float RacoonSpeed {
        get => racoonSpeed;
        set => racoonSpeed = value;
    }

    public float AdditionalGravity {
        get => additionalGravity;
        set => additionalGravity = value;
    }

    public float JumpForce {
        get => jumpForce;
        set => jumpForce = value;
    }

    public float GroundDistanceCheck {
        get => groundDistanceCheck;
        set => groundDistanceCheck = value;
    }

    public float EagleSpeed {
        get => eagleSpeed;
        set => eagleSpeed = value;
    }

    public float EagleJumpForce {
        get => eagleJumpForce;
        set => eagleJumpForce = value;
    }

    public float MaximumDownSpeed {
        get => maximumDownSpeed;
        set => maximumDownSpeed = value;
    }
}