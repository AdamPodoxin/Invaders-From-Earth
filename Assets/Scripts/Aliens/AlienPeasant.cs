using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPeasant : Alien
{
    public GameObject bullet;

    private float attackFrequency = 1f;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        if (humansInRange.Length > 0) Attack();
        yield return new WaitForSeconds(1f / attackFrequency);
        StartCoroutine(AttackLoop());
    }

    public override void Attack()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
