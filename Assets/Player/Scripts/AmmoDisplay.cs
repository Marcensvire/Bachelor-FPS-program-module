using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textAmmo;
    [SerializeField] private Projectile_weapon gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = this.GetComponent<Projectile_weapon>();
        // Debug.Log(gameObject.name);
        textAmmo = GameObject.Find(gameObject.name + "Body/Canvas/Ammo").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gun.enabled == true)
        {
            textAmmo.text = gun.bulletsLeft.ToString() + "/" + gun.magazineSize +"\n"+"Ammo";
        }
        else
        {
            textAmmo.text = " ";
        }
    }
}
