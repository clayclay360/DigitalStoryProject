using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CanPlayer
{
    public bool controlCamera;
    public bool walk;
    public bool jump;
    public bool shoot;
}

public struct IsPlayer
{
    public bool walking;
    public bool jumping;
    public bool shooting;
}

public class GameManager
{
    public static CanPlayer canPlayer = new CanPlayer();
    public static IsPlayer isPlayer = new IsPlayer();
    public const float playerWalkSpeed = 1.75f;
    public const float playerSprintSpeed = 5f;
    public const float playerJumpMagnitude = 5000f;
}
