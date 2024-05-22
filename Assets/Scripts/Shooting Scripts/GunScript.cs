using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float FireRate = 5f;

    public Text AmmoAmount;

    public int maxAmmo = 12;
    private int currentAmmo;
    public float reloadTime = 2f;

    public Vector3 spread = new Vector3(0.03f, 0.03f, 0.03f);

    private bool IsReloading = false;

    public AudioSource audioSource;
    public AudioClip ShootClip;
    public AudioClip ReloadClip;

    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;

    private float NextTimeToFire = 0f;

    public Animator animator;

    void Start()
    {
        AmmoAmount.text = maxAmmo.ToString();
        audioSource.clip = ShootClip;
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        IsReloading = false;
        animator.SetBool("Reloading", false);
        AmmoAmount.text = currentAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsReloading) return;

        if(currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
            Shoot();
            NextTimeToFire = Time.time + 1f / FireRate;
        }
    }

    IEnumerator Reload()
    {
        IsReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);
        audioSource.clip = ReloadClip;
        audioSource.Play();

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);
        audioSource.clip = ShootClip;

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        AmmoAmount.text = maxAmmo.ToString();

        IsReloading = false;
    }

    void Shoot()
    {
        Vector3 direction = GetDirection();
        MuzzleFlash.Play();
        audioSource.Play();

        currentAmmo--;
        AmmoAmount.text = currentAmmo.ToString();

        if (ScopeScript.IsScoped == false)
        {
            RaycastHit hit;
            //generam o raza incepand de la pozitia camerei si o trimitem in directia in care se uita camera
            if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                TargetBoss targetBoss = hit.transform.GetComponent<TargetBoss>();
                if (targetBoss != null)
                {
                    targetBoss.TakeDamage(damage);
                }

                //instantiem sistemul de particule pe punctul lovit si rotim sistemul sa arate in afara suprafetei lovite
                Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        else
        {
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

                TargetBoss targetBoss = hit.transform.GetComponent<TargetBoss>();
                if (targetBoss != null)
                {
                    targetBoss.TakeDamage(damage);
                }

                //instantiem sistemul de particule pe punctul lovit si rotim sistemul sa arate in afara suprafetei lovite
                Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = transform.forward;
        direction += new Vector3(
            Random.Range(-spread.x, spread.x),
            Random.Range(-spread.y, spread.y),
            Random.Range(-spread.z, spread.z)
            );
        direction.Normalize();
        return direction;
    }
}
