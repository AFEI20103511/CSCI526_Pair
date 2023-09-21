using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{   
    public float scroll_speed = 0.1f;
    private MeshRenderer mesh_Renderer;
    private float scrollDirection = 1f; // Positive value means scroll up

    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    public void ToggleScrollDirection()
    {
        scrollDirection *= -1f; // Toggle between 1 and -1
    }

    void Scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += scrollDirection * scroll_speed * Time.deltaTime;
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
