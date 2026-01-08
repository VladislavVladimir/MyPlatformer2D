using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int SPEED_X = Animator.StringToHash("SpeedX");
    private readonly int SPEED_Y = Animator.StringToHash("SpeedY");

    [SerializeField] private Animator _animator;

    public void SetSpeedX(float speedX)
    {
        _animator.SetFloat(SPEED_X, speedX);
    }

    public void SetSpeedY(float speedY)
    {
        _animator.SetFloat(SPEED_Y, speedY);
    }
}