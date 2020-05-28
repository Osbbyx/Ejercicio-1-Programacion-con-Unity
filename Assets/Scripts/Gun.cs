using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform playerCamera;
    public float shootDistance = 10f;
    public float impactForce = 5f;
    public LayerMask shootMask;
    public ParticleSystem shootParticles;
    public GameObject hitEffect;
    public GameObject destroyEffect;

    private RaycastHit shootRaycastHit;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        shootParticles.Play();
        if(Physics.Raycast(playerCamera.position, playerCamera.forward, out shootRaycastHit, shootDistance, shootMask))
        {
            Instantiate(hitEffect, shootRaycastHit.point, Quaternion.LookRotation(shootRaycastHit.normal), shootRaycastHit.transform);
        
        if(shootRaycastHit.collider.GetComponent<Rigidbody>() != null)
            {
                shootRaycastHit.collider.GetComponent<Rigidbody>().AddForce(- shootRaycastHit.normal * impactForce);
            }
            if (shootRaycastHit.collider.CompareTag("Barrel"))
            {
                LevelManager.Instance.levelScore++;
                Instantiate(destroyEffect, shootRaycastHit.point, Quaternion.LookRotation(shootRaycastHit.normal));
                Destroy(shootRaycastHit.collider.gameObject);
            }
        }
    }
}
