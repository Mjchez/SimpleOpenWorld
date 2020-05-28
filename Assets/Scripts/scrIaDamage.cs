using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrIaDamage : MonoBehaviour
{
    public int lives =10;
    public scrIaStar iaStar;
    
    
    void Update()
    {
      if(lives < 0)
      {
          iaStar.Dead();
          Destroy(gameObject,4);
      }  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PlayerProjectile"))
        {
            lives--;
            iaStar.Damage();
        }
    }

    public void ExplosionDamage()
    {
        lives =-1;
    }



}
