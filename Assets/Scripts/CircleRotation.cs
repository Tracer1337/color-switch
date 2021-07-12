using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    public float speed = 100f;
    
    private void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
