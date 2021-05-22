using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject explosion;
    [SerializeField] private LayerMask whatIsEnemies;

    //bullet force
    [SerializeField] internal float shootForce, upwardForce;

    //Stats
    [Range(0f, 1f)]
    [SerializeField] private float bounciness;
    [SerializeField] private bool useGravity, isExplosive;

    //Damage
    [SerializeField] private float damage;
    [SerializeField] private float explosionRange;
    [SerializeField] private float explosionForce;

    //LifeTime
    [SerializeField] private int maxCollisions;
    [SerializeField] private float maxLifeTime;
    [SerializeField] private float destroyDelay;

    [SerializeField] private bool onTouch =true;

    [SerializeField] private int collisions;
    PhysicMaterial physics_mat;

  

  
    // Start is called before the first frame update
    void Start()
    {
        //Create a new Physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<Collider>().material = physics_mat;

        //Set gravity
        rb.useGravity = useGravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (collisions > maxCollisions) Delay();

        maxLifeTime -= Time.deltaTime;
        if (maxLifeTime <= 0) Delay();
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions++; //Count up collisions

        if (collision.collider.CompareTag("Enemy") && onTouch)
        {
            if (!isExplosive)
            {
                collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            } 

            Delay();//Destroy if bullet hits an enemy
        }
    }

    private void Explode()
    {
        //Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemies 
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Get component of enemy and call Take Damage

            enemies[i].GetComponent<EnemyStats>().TakeDamage(damage);

            //Add explosion force (if enemy has a rigidbody)
            //   if (enemies[i].GetComponent<Rigidbody>())
            //       enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }

        //Add  delay
        Invoke("Destroy", destroyDelay);
    }

    private void Delay()
    {
        if (isExplosive) Explode();
        else Invoke("Destroy", destroyDelay);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    // Visualize the explosion range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
