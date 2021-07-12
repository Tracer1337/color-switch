using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    private float maxY;
    
    private void Update()
    {
        if (player.position.y <= maxY)
            return;
        
        var newPosition = player.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
        maxY = newPosition.y;
    }
}
