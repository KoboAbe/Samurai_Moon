using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FogCamera : MonoBehaviour
{
    public Color fogColor = Color.gray;    // Color de la niebla
    public float fogDensity = 0.02f;        // Densidad de la niebla

    private void Start()
    {
        // Asegurarse de que la cámara tiene un fondo transparente
        Camera cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = Color.clear;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Configurar el shader de niebla en la imagen renderizada
        Material fogMaterial = new Material(Shader.Find("Hidden/FogShader"));
        fogMaterial.SetColor("_FogColor", fogColor);
        fogMaterial.SetFloat("_FogDensity", fogDensity);

        // Renderizar la imagen con el efecto de niebla
        Graphics.Blit(source, destination, fogMaterial);
    }
}
