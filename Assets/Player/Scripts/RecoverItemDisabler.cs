using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverItemDisabler : MonoBehaviour
{
    [SerializeField] RecoverItem item;
    [SerializeField] IntPickUpAndDrop equipScript;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<RecoverItem>();
        equipScript = this.GetComponent<IntPickUpAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (equipScript.equipped == true)
        {
            this.item.enabled = true;
        }
        else
        {
            this.item.enabled = false;
        }
    }
}
