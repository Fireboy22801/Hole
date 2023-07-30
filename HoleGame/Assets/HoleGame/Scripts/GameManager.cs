using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int targetPoints;

    public float points = 0;

    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 9999;
    }

    public void GameOver()
    {
        UI.Instance.GameOverMenu();
    }

    public void CheckPoints()
    {
        if(points >= targetPoints)
            GameOver();
    }    
}
