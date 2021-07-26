using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
   public AIEnemyScript enemyScript;

   bool hitPlayer = false;
   float hitDelay;
   float hitDelayMax = 1f;

    public GameObject impactPrefab;

    // Start is called before the first frame update
    void Start()
    {
        hitDelay = hitDelayMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPlayer)
        {
            hitDelay -= Time.deltaTime;
            if(hitDelay < 0)
            {
                hitDelay = hitDelayMax;
                hitPlayer = false;
            }
        }
    }


    public void PlayNearAudio(string Audio)
    {       
        FindObjectOfType<AudioManager>().PlayClipAtPosition(Audio, gameObject.transform.position); 
    }

    public void OnTriggerEnter(Collider col)
    {
        if(enemyScript.isAttacking())
        {

        if(col.tag == "PlayerClose")
        {
            if(!hitPlayer)
            {
                hitPlayer = true;
                print("hit player");
                col.gameObject.GetComponent<PlayerHealthScript>().TakeDamage(40);
                Instantiate(impactPrefab, new Vector3(col.gameObject.transform.position.x, gameObject.transform.position.y, col.gameObject.transform.position.z), Quaternion.identity);
                int r = Random.Range(1,2);
                string hitSound = "HitLoud" + r.ToString();
                PlayNearAudio(hitSound);
            }

        }
        }
    }
}
