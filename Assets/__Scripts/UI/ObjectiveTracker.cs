using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveTracker : MonoBehaviour
{

    private List<Objective> objectives;

    [SerializeField] private TextMeshProUGUI objectiveText;

    // Start is called before the first frame update
    void Start()
    {
        objectives = GameManager.Instance.Objectives;
    }

    // Update is called once per frame
    void Update()
    {
        string t = "";
        foreach(Objective o in objectives)
        {
            t += $"{o.Name}\n";
        }
        objectiveText.text = t;
    }
}
