using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
// https://www.youtube.com/watch?v=HW8UePVtU5M&t=150s&ab_channel=Quickz


public class CameraEffect : MonoBehaviour
{
    public Material material;

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if ( material == null ) {
            Graphics.Blit(source,destination);
            return;
        }

        Graphics.Blit(source,destination, material);
    }
}
