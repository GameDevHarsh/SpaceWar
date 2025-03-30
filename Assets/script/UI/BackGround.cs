using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
   [SerializeField] private Renderer meshrender;
  [SerializeField] private float speed = 0.1f;
    void Update()
    {
        Vector2 offset = meshrender.material.mainTextureOffset;
        offset = offset + new Vector2(0, speed * Time.deltaTime);
        meshrender.material.mainTextureOffset = offset;
    }
}
