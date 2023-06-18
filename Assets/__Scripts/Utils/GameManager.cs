using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
        set
        {
            if(instance != null)
            {

            }
            instance = value;
        }
    }

    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;
    private GameObject player;

    public GameObject Player { get { return player; } }

    [SerializeField] private List<Objective> objectives;

    public List<Objective> Objectives { get { return objectives; } }

    private void Awake()
    {
        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    public void ClearObjective(Objective objective)
    {
        if (objectives.Contains(objective))
            objectives.Remove(objective);
    }

    private void Update()
    {
        if (objectives.Count <= 0)
            Win();
    }

    public void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
