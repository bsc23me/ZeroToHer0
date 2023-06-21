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
        // Initialization
        objectives = GameManager.Instance.Objectives;
        objectiveText = new TextMeshProUGUI[objectives.Count];
        for (int i = 0; i < objectives.Count; i++)
        {
            GameObject go = Instantiate(textPrefab, transform); // Create Objective Text
            objectiveText[i] = go.GetComponent<TextMeshProUGUI>(); // Store a reference
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetText(); // Contains for loop
    }

    /// <summary>
    /// Defines the text that is displayed for each objective in the level
    /// </summary>
    void SetText()
    {
        
        for(int i = 0; i < objectives.Count; i++)
        {
            string t = "";
            SetFont(i);
            if (objectives[i].IsOptional) // Add a tab on optional objectives
                t += "\t";
            t += $"{objectives[i].Name}"; // Define text
            objectiveText[i].text = t; // Assign text
        }
    }

    /// <summary>
    /// Sets the style of the text so match the objective and its status
    /// </summary>
    /// <param name="i">the objective to alter</param>
    void SetFont(int i)
    {
        if (objectives[i].IsComplete)
        {
            objectiveText[i].color = Color.green;
            objectiveText[i].fontStyle = FontStyles.Strikethrough;
        }
        else if (objectives[i].IsOptional)
        {
            objectiveText[i].color = Color.gray;
            objectiveText[i].fontStyle = FontStyles.Italic;
            objectiveText[i].fontSize = 24;
        }
    }
}
