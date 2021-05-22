using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntDoor : Interactable
{
    [SerializeField] private bool isOpen;
    [SerializeField] Vector3 targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = new Vector3 (-90, 0, 89);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), 5f * Time.deltaTime);
    }

    public override void OnInteraction()
    {
        
        if (!isOpen)
        {
            
            isOpen = true;
            targetRotation =new Vector3(-90, 0, 180);
        }
        else
        {
            isOpen = false;
            targetRotation = new Vector3(-90, 0, 90);
        }
    }
}
