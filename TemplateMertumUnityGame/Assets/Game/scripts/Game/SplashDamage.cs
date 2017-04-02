using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDamage : MonoBehaviour {

    public int splashDamage = 10; //damage of splash effect
    public float radius = 2f; //radius of the splash damage effect
    public string targetsTag = "enemy"; //deals damage to objects with this tag
    public GameObject Explosion;

    public void DealSplashDamage()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetsTag);

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= radius)
            {
                enemy.GetComponent<hp>().CurrentHP -= splashDamage;
                Debug.Log("padaryta zala, liko gyvybiu: " + enemy.GetComponent<hp>().CurrentHP + ", atstumas: " + distanceToEnemy);
            }

        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("trigerina bomba enemy:");
        if (coll.gameObject.tag == targetsTag)
            Debug.Log(coll.gameObject);
            this.gameObject.GetComponent<SplashDamage>().DealSplashDamage();
            var exp = Instantiate(Explosion,this.transform.position,new Quaternion());
            Destroy(exp,5);
            Destroy(this.gameObject);
    }
}
