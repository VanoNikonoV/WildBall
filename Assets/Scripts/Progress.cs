using UnityEngine;
using UnityEngine.SceneManagement;
using WildBall.Controller;

public class Progress : MonoBehaviour
{
    /// <summary>
    /// ����� ��� ��������� ���������� ��� ������ ������
    /// </summary>
    private int �ollectedInPreviousLevel;

    private int sceneIndexCurrent;

    private int tempAllCoints;

    /// <summary>
    /// ���������� ����� � ������
    /// </summary>
    public int AllCoints { get; private set; }

    /// <summary>
    /// ������� ��������� �������
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
    /// ������������� ������ ��� ����� ������
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    private void RecalculationOfBonuses(Scene current, Scene next)
    {
        �ollectedInPreviousLevel = AllCoints; //��������� ��������� ����� ������

        sceneIndexCurrent = current.buildIndex;

        AllCoints += FindObjectsOfType<Coin>().Length; // �������� ��� ������ �� ������

        tempAllCoints = AllCoints; // ��� ���� ������� �� ������

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
    /// ������������� �������� ��������� ������� � ���������� ���� ������� �� ������� ������, 
    /// ��������� �� ������������ �������� �ollectedInPreviousLevel
    /// </summary>
    private void ResetCollectedCoins()
    {
        CollectedCoins = �ollectedInPreviousLevel;

        AllCoints = tempAllCoints;
    }

    
}
