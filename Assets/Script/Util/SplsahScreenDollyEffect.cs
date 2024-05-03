using UnityEngine;

public class SplsahScreenDollyEffect : MonoBehaviour
{
    public float dollySpeed = 0.01f;
    public float maxScale = 1.1f;
    public float minScale = 1f;

    private RectTransform rectTransform;
    private bool isDollyingIn = true;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Calculate the new scale based on dollySpeed
        float newScale = rectTransform.localScale.x + (isDollyingIn ? dollySpeed : -dollySpeed) * Time.deltaTime;

        // Clamp the scale to the specified range
        newScale = Mathf.Clamp(newScale, minScale, maxScale);

        // Set the new scale
        rectTransform.localScale = new Vector3(newScale, newScale, 1f);

        // Reverse direction if reached max or min scale
        if (newScale >= maxScale || newScale <= minScale)
        {
            isDollyingIn = !isDollyingIn;
        }
    }
}
