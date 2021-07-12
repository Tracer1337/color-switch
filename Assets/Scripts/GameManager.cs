using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerColor playerColor;
    public LevelSpawner spawner;
    public Score score;
    public GameObject menu;
    public int concurrentLevels = 3;

    private bool hasPassedFirstLevel = false;

    private void Start()
    {
        for (var i = 0; i < concurrentLevels; i++)
        {
            spawner.AddLevel();
        }
        playerColor.PickRandomColor();
    }

    public void Play()
    {
        menu.SetActive(false);
    }

    public void NextIteration()
    {
        if (!hasPassedFirstLevel)
            hasPassedFirstLevel = true;
        else
        {
            spawner.RemoveLevel();
            spawner.AddLevel();
        }
        score.AddToScore();
        playerColor.PickRandomColor();
    }

    public void End()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
