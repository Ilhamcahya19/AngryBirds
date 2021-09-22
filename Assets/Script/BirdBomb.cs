using UnityEngine;

public class BirdBomb : Bird
{
    public float fielddoImpact;
    public float force;
    public GameObject ExplosionEffect;
    public LayerMask LayerToHit;
    public bool _hasBoost = false;

    public void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,fielddoImpact,LayerToHit);
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            GameObject ExplosioEffectIns = Instantiate(ExplosionEffect,transform.position,Quaternion.identity);
            Destroy(ExplosioEffectIns,5);
            Destroy(gameObject);
            _hasBoost = true;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,fielddoImpact);    
    }

    public override void OnTap()
    {
        explode();
    }
    
}
