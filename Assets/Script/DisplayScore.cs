using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class DisplayScore : MonoBehaviour
{
    public List<TextMeshProUGUI> scoreTexts;
 
    void Start()
    {
        UpdateUI();
        InvokeRepeating("UpdateUI", 0f, 0.1f);
    }
    
    void UpdateUI()
    {
        foreach (TextMeshProUGUI textElement in scoreTexts)
        {
            if (textElement != null)
            {
                textElement.text = "Score: " + PointManager.score;
            }
        }
        
 
    }
}
