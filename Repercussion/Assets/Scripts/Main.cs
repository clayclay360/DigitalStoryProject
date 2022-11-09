using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        GameManager.canPlayer.walk = true;
        GameManager.canPlayer.jump = true;
    }
}
