using UnityEngine;

public class MoveBetweenObjects : MonoBehaviour
{
    public Transform object1; // Reference to the first object
    public Transform object2; // Reference to the second object

    void Update()
    {
        if (object1 != null && object2 != null)
        {
            // Calculate the midpoint between the two objects
            Vector3 midpoint = (object1.position + object2.position) / 2f;

            // Move the object to the midpoint position
            transform.position = midpoint;
        }
        else
        {
            Debug.LogWarning("One or both objects are not assigned!");
        }
    }
}