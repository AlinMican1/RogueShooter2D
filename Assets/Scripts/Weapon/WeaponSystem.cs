using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSystem : MonoBehaviour
{

    [Header("Weapons")]
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    int bulletsLeft, bulletsShot;
    bool shooting, readyToShoot, reloading, switchedWeapon;
    public bool allowButtonHold;
    public GameObject shootpoint;
    


    [Header("Reference")]
    public Transform attackPoint;
    public RaycastHit rayHit;


    [Header("Graphics")]
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI text;
    public TrailRenderer BulletTrail;

    // Start is called before the first frame update
    void Start()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;

    }

    // Update is called once per frame
    void Update()
    {

        myInput();
        SetTextMagazine(bulletsLeft);
    }

    void myInput()
    {
        //Check if we are able to shoot, if so call shoot function.
        //Check if we can reload.
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }

        //Check if we are allowed to hold mouse button to shoot otherwise only tap shoot.
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);

        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        }
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }

    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    private void Shoot()
    {
        readyToShoot = false;
        Debug.Log("shoot");
        
        // Creates a Ray from this object, moving forward
        RaycastHit2D hit = Physics2D.Raycast(shootpoint.transform.position, transform.TransformDirection(Vector2.up), 100f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 100f, Color.red);

        //Test if i hit something
        if (hit)
        {
            Debug.Log(hit.collider.name);
        }

        //TrailRenderer trail = Instantiate(BulletTrail, shootpoint.transform.position, transform.rotation);

        bulletsLeft--;
        bulletsShot--;
        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }

    }

    private void ResetShot()
    {

        readyToShoot = true;
    }

    public void SetTextMagazine(int bulletsLeft)
    {
        text.SetText(bulletsLeft + " / " + magazineSize);
    }
}


