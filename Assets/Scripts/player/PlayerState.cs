using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance;
    public UnityEvent<float> airYE;
    public UnityEvent<bool> isGroundE;

    public bool isWalking;
    private float _airY;
    public float airY
    {
        get
        {
            return _airY;
        }
        set
        {
            _airY = value;
            airYE.Invoke(airY);
        }
    }
    private bool _isGround = true;
    public bool isGround
    {
        get
        {
            return _isGround;
        }
        set
        {
            _isGround = value;
            isGroundE.Invoke(value);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }
}
