using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCheck : MonoBehaviour
{
    [SerializeField]private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
       // characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(characterController.center.x, characterController.center.y, characterController.center.z);
    }
}
