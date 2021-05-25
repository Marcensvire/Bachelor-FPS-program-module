using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI textDisplay;
    [SerializeField]private PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        textDisplay = GameObject.Find("Canvas/Hp_text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textDisplay.text ="Health: "+stats.health.ToString() +"\n"+ "Stamina: " + stats.stamina.ToString("#") + "\n" + "Thirst: " +stats.thirst.ToString("#.##") +"\n"+ "Hunger: " +stats.hunger.ToString("#.##");
    }
}
