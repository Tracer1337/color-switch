using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] levels;
    public float circleMinSpeed = 30f;
    public float circleMaxSpeed = 300f;
    public float offset = 5f;
    public float levelHeight = 5f;

    private Queue<GameObject> activeLevels = new Queue<GameObject>();
    private int totalLevelsSpawned = 0;

    public void AddLevel()
    {
        var position = transform.position + new Vector3(0, levelHeight + offset, 0) * totalLevelsSpawned;
        var level = levels[Random.Range(0, levels.Length)];
        var instance = Instantiate(level, position, Quaternion.identity);
        
        var circleRotation = instance.GetComponentInChildren<CircleRotation>();
        circleRotation.speed = Random.Range(circleMinSpeed, circleMaxSpeed);
        circleRotation.speed *= Random.value > 0.5 ? 1 : -1;
        
        totalLevelsSpawned++;
        activeLevels.Enqueue(instance);
    }

    public void RemoveLevel()
    {
        var level = activeLevels.Dequeue();
        Destroy(level);
    }
}
