using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] Material waterMat;
    private float offsetY = 0f;

    private void Update() {
        offsetY += Time.deltaTime/4f;
        waterMat.mainTextureOffset = new Vector2(0, -offsetY);
    }
}
