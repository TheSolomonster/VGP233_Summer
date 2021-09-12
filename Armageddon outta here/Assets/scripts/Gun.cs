

using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject slider;
    public float damage = 10f;
    public float range = 200f;
    public float fireRate = 2.0f;
    public float impactForce = 50.0f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    private float nextTimeToFire = 0.0f;
    public AudioSource source;
    public AudioClip clip;
    public GameObject manager;
    // Update is called once per frame
    void Update()
    {
        ReloadBar reloadBar = slider.transform.GetComponent<ReloadBar>();
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !manager.GetComponent<gameManager>().GameWon && !manager.GetComponent<gameManager>().GameOver)
        {
            slider.SetActive(true);
            nextTimeToFire = Time.time + 1.0f/fireRate;
            reloadBar.setMaxMin(Time.time, nextTimeToFire);
            Shoot();
        }
        if (slider.active)
        {
            reloadBar.setValue(Time.time);
        }
        if (Time.time - nextTimeToFire >= 0.5f) slider.SetActive(false);
    }
    void Shoot ()
    {
        RaycastHit hit;
        muzzleFlash.Play();
        source.PlayOneShot(clip);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }
    }
}
