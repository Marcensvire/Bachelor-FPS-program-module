using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_sphere_destroyer : MonoBehaviour
{

    [SerializeField] private float destroyDelay;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", destroyDelay);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
