using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Play the intro sound
        audioSource.Play();

        // Calculate the delay before loading the main scene
        float delay = audioSource.clip.length + 1f; // Add 1 second additional delay

        // Invoke LoadMainScene method after the calculated delay
        Invoke("LoadMainScene", delay);
    }

    void LoadMainScene()
    {
        // Load the main scene
        SceneManager.LoadScene("SampleScene");
    }
}
