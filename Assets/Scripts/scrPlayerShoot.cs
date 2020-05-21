using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerShoot : MonoBehaviour
{
    public GameObject[] projectilesPrefab;
    int indexWeapon;
    public GameObject target;
    public GameObject laserpoint;


    void Start()
    {
        float movx = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-movx,0,0));

        if (Input.GetKey(KeyCode.Alpha1)){
        	indexWeapon = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2)){
        	indexWeapon = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3)){
        	indexWeapon = 2;
        }
        if (Input.GetKey(KeyCode.Alpha4)){
        	indexWeapon = 3;
        }
        if (Input.GetKey(KeyCode.Alpha5)){
        	indexWeapon = 4;
        }
        if (Input.GetKey(KeyCode.Alpha6)){
        	indexWeapon = 5;
        }
        if (Input.GetKey(KeyCode.Alpha7)){
        	indexWeapon = 6;
        }
        if (Input.GetKey(KeyCode.Alpha8)){
        	indexWeapon = 7;
        }

        if(Input.GetButtonDown("Fire1"))
        {
        	GameObject myprojectile=
            Instantiate(projectilesPrefab[indexWeapon], transform.position+transform.forward,transform.rotation);

            if (myprojectile.GetComponent<scrGuidedBomb>())
            {
                myprojectile.GetComponent<scrGuidedBomb>().target = laserpoint;
            }
            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }

        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit))
        {
            laserpoint.transform.position = hit.point;
        }
        else
        {
            laserpoint.transform.position = transform.position + transform.forward * 100;
        }
        
    }
}
