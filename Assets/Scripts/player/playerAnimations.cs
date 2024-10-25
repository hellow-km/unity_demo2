using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationString
{
    public static string IsWalking = "IsWalking";
    public static string isJumping = "isJumping";
    public static string airY = "airY";
    public static string isGround = "isGround";
}

public class playerAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private PlayerState playerState;


    private void Awake()
    {
        if (anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }

        if (!playerState)
        {
            playerState = PlayerState.Instance;
        }
    }

    public void ChangeIdle()
    {
        anim.SetBool(AnimationString.IsWalking, playerState.isWalking);
    }

    public void ChangeWalk()
    {
        anim.SetBool(AnimationString.IsWalking, playerState.isWalking);
    }

    public void SetJump(bool isJump)
    {
        anim.SetBool(AnimationString.isJumping, isJump);
    }

    public void setAirY(float airY)
    {
        anim.SetFloat(AnimationString.airY, airY);
    }

    public void SetIsGround(bool isGround)
    {
        anim.SetBool(AnimationString.isGround, isGround);
    }

    private void Update()
    {
        if (playerState.isGround)
        {
            if (playerState.isWalking)
            {
                ChangeWalk();
            }
            else
            {
                ChangeIdle();
            }
        }
        else
        {
            if (playerState.airY > 0)
            {
                SetJump(true);
            }
            else
            {
                SetJump(false);
            }
        }


    }
}
