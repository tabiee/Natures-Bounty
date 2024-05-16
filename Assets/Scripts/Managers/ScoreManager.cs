using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int scrapScore;
    [SerializeField] private TextMeshProUGUI text;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);

            Debug.LogWarning("There was more than one ScoreManager in the scene");
        }
        instance = this;

        
    }

    private void Start()
    {
        
    }
    public void UpdateScrapCount(int amount)
    {
        scrapScore += amount;
        text.text = "" + scrapScore;
    }
}
