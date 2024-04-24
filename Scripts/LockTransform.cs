using UnityEngine;

public class LockTransform : MonoBehaviour
{
    private Vector3 initialPositionOffset;
    private Quaternion initialRotation;

    void Start()
    {
        // Store the initial offset from the world origin
        initialPositionOffset = transform.position;

        // Store the initial rotation relative to the world
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Update the position of the child object to maintain its initial offset from the world origin
        transform.position = initialPositionOffset;

        // Update the rotation of the child object to maintain its initial rotation relative to the world
        transform.rotation = initialRotation;
    }
}
