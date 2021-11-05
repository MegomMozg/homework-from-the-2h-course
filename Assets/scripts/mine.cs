using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    [SerializeField] private float damage = 1000;
    public LayerMask layer;
    public ParticleSystem particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (((1 << other.gameObject.layer) & layer) != 0)
            {
                other.GetComponent<UnitHP>().Adjust(damage);

            }
            particle.Play();
            Destroy(gameObject);
        }
        
    }
}
    
