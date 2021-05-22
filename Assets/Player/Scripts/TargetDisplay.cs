using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHP;
    [SerializeField] private EnemyStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponent<EnemyStats>();
       // Debug.Log(gameObject.name);
        textHP = GameObject.Find(gameObject.name+"/Canvas/HP").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textHP.text = stats.health.ToString();
    }
}
