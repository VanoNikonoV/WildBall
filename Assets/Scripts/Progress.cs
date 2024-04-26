using UnityEngine;
using UnityEngine.SceneManagement;
using WildBall.Controller;

public class Progress : MonoBehaviour
{
    /// <summary>
    /// Нужна для обнуления результата при смерти игрока
    /// </summary>
    private int сollectedInPreviousLevel;

    private int sceneIndexCurrent;

    private int tempAllCoints;

    /// <summary>
    /// Количество монет в уровне
    /// </summary>
    public int AllCoints { get; private set; }

    /// <summary>
    /// Счетчик собранных бонусов
    /// </summary>
    public int CollectedCoins { get; set;} = 0;

    public static Progress Instance;

    private void Awake()
    {
        SceneManager.activeSceneChanged += RecalculationOfBonuses;

        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Пересчитывает бонусы при смене уровня
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    private void RecalculationOfBonuses(Scene current, Scene next)
    {
        сollectedInPreviousLevel = AllCoints; //записываю собранные ранее бонусы

        sceneIndexCurrent = current.buildIndex;

        AllCoints += FindObjectsOfType<Coin>().Length; // записыва все бонусы на уровне

        tempAllCoints = AllCoints; // кеш всех бонусов на уровне

        if (current.buildIndex > 0 ) 
        { 
            CollectedCoins = AllCoints; 
        }
    }



    private void OnDisable() 
    { 
        SceneManager.activeSceneChanged -= RecalculationOfBonuses;
        //SceneManager.sceneLoaded

        PlayerController.OnDeathPlayer -= ResetCollectedCoins;
    }

    private void OnEnable()
    {
        PlayerController.OnDeathPlayer += ResetCollectedCoins;
    }

    /// <summary>
    /// Перезаписывае значения собранных бонусов и количество всех бонусов на текущем уровне, 
    /// использую за кешированные значения сollectedInPreviousLevel
    /// </summary>
    private void ResetCollectedCoins()
    {
        CollectedCoins = сollectedInPreviousLevel;

        AllCoints = tempAllCoints;
    }

    
}
