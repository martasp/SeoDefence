using UnityEngine;

namespace Assets.Game.scripts.Game
{
    public class SplashDamage : MonoBehaviour {

        public int splashDamage = 10; //damage of splash effect
        public float radius = 2f; //radius of the splash damage effect
        public string targetsTag = "enemy"; //deals damage to objects with this tag
        public GameObject Explosion;

        public void DealSplashDamage()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetsTag);
            int killcount = 0;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy <= radius)
                {
                    enemy.GetComponent<hp>().CurrentHP -= splashDamage;
                    if (enemy.GetComponent<hp>().CurrentHP <= 0) killcount++;
                }             
            }
            GameObject.Find("GameManager").GetComponent<AchievmentManager>().addSplashRAD(killcount);
            if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkSplashedEnemies())
                GameObject.Find("nukeem").GetComponent<onScreenAchievment>().showUp();
            var explosion = Instantiate(Explosion, this.transform.position, new Quaternion());
            Destroy(explosion, 5);
            Destroy(this.gameObject);
        }
        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == targetsTag)
                Debug.Log(coll.gameObject);
            this.gameObject.GetComponent<SplashDamage>().DealSplashDamage();
            
        }
    }
}
