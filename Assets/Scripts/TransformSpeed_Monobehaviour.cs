using UnityEngine;

public class TransformSpeed_Monobehaviour : MonoBehaviour
{
    public Vector3 speed;
    public Vector3 rotationSpeed;

    void Update()
    {
        var deltaTime = Time.deltaTime;

        transform.Translate(speed * deltaTime);
        transform.Rotate(rotationSpeed * deltaTime);
    }
}
