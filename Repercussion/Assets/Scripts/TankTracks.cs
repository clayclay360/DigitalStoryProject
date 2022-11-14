using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTracks : MonoBehaviour
{
    public float offsetSpeed;
    Renderer rend;
    float scaleX = 0;
    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    void Update()
    {
        // Animates main texture scale in a funky way!
        scaleX += offsetSpeed;
        float scaleY = Mathf.Sin(Time.time) * 0.5f + 1;
        rend.material.mainTextureOffset = new Vector2(scaleX, 0);
    }
}
