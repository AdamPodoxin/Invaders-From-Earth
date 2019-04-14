using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Collider2D[] humansInRange;

    [SerializeField]
    private float range = 10f;

    private SpriteRenderer spriteRenderer;

    private int humanLayer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        humanLayer = 1 << LayerMask.NameToLayer("Human");
    }

    private void Update()
    {
        CheckHumansInRange();
        LookAtHumanInRange();
    }

    private void CheckHumansInRange()
    {
        humansInRange = Physics2D.OverlapCircleAll(transform.position, range, humanLayer);
    }

    private void LookAtHumanInRange()
    {
        if (humansInRange.Length > 0)
        {
            Vector3 diff = humansInRange[0].transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            spriteRenderer.flipX = transform.eulerAngles.z > 180 || transform.eulerAngles.z < 0;
        }
    }

    public virtual void Attack()
    {
        //This method is overridable
    }
}
