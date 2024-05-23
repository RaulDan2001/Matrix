using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class BossShoting : MonoBehaviour
{
    [Header("General")]

    public Transform shootPoint; // de unde incepe raza

    public Transform gunPoint; // de unde incepe efectul vizual

    public LayerMask layerMask; // stradul pentru masca

    public PlayerStats healthbar;

    public ParticleSystem MuzzleFlash;

    public int damage;

    [Header("Gun")]

    public Vector3 spread = new Vector3(0.04f, 0.04f, 0.04f);

    public AudioSource audioSource;
    public AudioClip audioClip;

    public int ammo = 30;

    private BossReferences bossReferences;

    private int currentAmmo;

    void Awake()
    {
        bossReferences = GetComponent<BossReferences>();
        audioSource.clip = audioClip;
        Reload();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossShoot()
    {
        if (ShouldReload()) return; 

        Vector3 direction = GetDirection();
        MuzzleFlash.Play();
        audioSource.Play();
        if (Physics.Raycast(shootPoint.position, direction, out RaycastHit hit, float.MaxValue, layerMask))
        {
            Debug.DrawLine(shootPoint.position, shootPoint.position + direction * 100f, Color.red, 1f);

            NewBehaviourScript player = hit.transform.GetComponent<NewBehaviourScript>();
            if (player != null)
            {
                TakeDamage(damage);
            }


            currentAmmo -= 1;
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

    public void TakeDamage(int damage)
    {
        healthbar.CurrentHealth -= damage;

        healthbar.SetHealth(healthbar.CurrentHealth);
    }

    public bool ShouldReload()
    {
        return currentAmmo <= 0;
    }

    public void Reload()
    {
        Debug.Log("Reload");
        currentAmmo = ammo;

    }
}
