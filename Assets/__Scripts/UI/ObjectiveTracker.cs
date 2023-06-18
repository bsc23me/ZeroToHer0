using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveTracker : MonoBehaviour
{

    private List<Objective> objectives;

    [SerializeField] private GameObject textPrefab;
    private TextMeshProUGUI[] objectiveText;

    // Start is called before the first frame update
    void Start()
    {
        objectives = GameManager.Instance.Objectives;
        objectiveText = new TextMeshProUGUI[objectives.Count];
        for (int i = 0; i < objectives.Count; i++)
        {
            GameObject go = Instantiate(textPrefab, transform);
            objectiveText[i] = go.GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }

    void SetText()
    {
        for(int i = 0; i < objectives.Count; i++)
        {
            SetFont(i);
            objectiveText[i].text = $"{objectives[i].Name}\n";
        }
    }

    void SetFont(int i)
    {
        if (objectives[i].IsComplete)
        {
            objectiveText[i].color = Color.green;
            objectiveText[i].fontStyle = FontStyles.Strikethrough;

        }
    }
}
