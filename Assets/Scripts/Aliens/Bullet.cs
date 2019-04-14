using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;

    public float speed = 5f;

    private int humanLayer;

    private void Start()
    {
        humanLayer = LayerMask.NameToLayer("Human");

        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(humanLayer))
        {
            collision.GetComponent<Human>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
