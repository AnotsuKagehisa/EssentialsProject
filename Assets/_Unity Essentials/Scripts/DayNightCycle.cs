using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Cycle Settings")]
    [Tooltip("Duration of a full day in seconds.")]
    [SerializeField] private float dayDuration = 60f; // Default duration for a full day in seconds

    private float rotationSpeed;

    void Start()
    {
        // Calculate the rotation speed in degrees per second (360 degrees in a full rotation)
        rotationSpeed = 360f / dayDuration;
    }

    void Update()
    {
        // Rotate the light around the X-axis based on the rotation speed and time
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
