using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class DamageDealer : MonoBehaviour
{
    [Tooltip("Amount of damage dealt by this object")]
    public float Damage = 1;
    [Tooltip("Tags of game objects to which this game object can deal damage")]
    public string[] Tags;

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in Tags)
        {
            if (collision.gameObject.tag == tag)
            {
                Health health = collision.gameObject.GetComponent<Health>();
                health.DealDamage(Damage);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        foreach (string tag in Tags)
        {
            if (collider.tag == tag)
            {
                Health health = collider.GetComponent<Health>();
                health.DealDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
