using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PixelPerfectSetup : MonoBehaviour
{
    void Start()
    
    {

        Debug.Log("PixelPerfectSetup script started.");
        PixelPerfectCamera pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
        Debug.Log(pixelPerfectCamera);
        if (pixelPerfectCamera != null)
        {
            // Configure Pixel Perfect Camera settings
            pixelPerfectCamera.assetsPPU = 32; // Adjust to match your sprite's pixels per unit
            pixelPerfectCamera.refResolutionX = 640; // Set your target reference resolution width
            pixelPerfectCamera.refResolutionY = 360; // Set your target reference resolution height
            pixelPerfectCamera.upscaleRT = true; // Enable Upscale Render Texture
            pixelPerfectCamera.pixelSnapping = true; // Enable Pixel Snapping

            // Debug logs to verify settings
            Debug.Log("Pixel Perfect Camera Configured");
            Debug.Log("Upscale Render Texture: " + pixelPerfectCamera.upscaleRT);
            Debug.Log("Pixel Snapping: " + pixelPerfectCamera.pixelSnapping);
        }
        else
        {
            Debug.LogWarning("Pixel Perfect Camera component not found on this GameObject.");
        }
    }
}
