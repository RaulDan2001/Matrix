using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float FireRate = 5f;


    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;

    private float NextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
            ShootAutomatic();
            NextTimeToFire = Time.time + 1f / FireRate;
        }
    }

    void ShootAutomatic()
    {
        MuzzleFlash.Play();
        RaycastHit hit;
        //generam o raza incepand de la pozitia camerei si o trimitem in directia in care se uita camera
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            //instantiem sistemul de particule pe punctul lovit si rotim sistemul sa arate in afara suprafetei lovite
            Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }
}
