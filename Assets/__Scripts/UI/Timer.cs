using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = string.Format("Time: {0:00}:{1:00}",(int)Time.timeSinceLevelLoad / 60,(int)Time.timeSinceLevelLoad % 60);
    }
}
