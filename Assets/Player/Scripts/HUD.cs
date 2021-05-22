using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI textHP;
    [SerializeField]private PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        textHP = GameObject.Find("Canvas/Hp_text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textHP.text ="Health: "+stats.health.ToString() +"\n" + "Thirst: " +stats.thirst.ToString("#.##") +"\n"+ "Hunger: " +stats.hunger.ToString("#.##");
    }
}
