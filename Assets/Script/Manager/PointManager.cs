using UnityEngine;
using TMPro;
public class PointManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    public static int score = 0;
    //public static int highScore = 0;
    private static int scoreMilestone = 0;

    public static PointManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //LoadHighScore();
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        
  
        if (score / 100 > scoreMilestone)
        {
            scoreMilestone = score / 100;
            if (EnemySpawner.instance != null)
            {
                EnemySpawner.instance.IncreaseMaxEnemies();
            }
        }
    }
    
    
}
