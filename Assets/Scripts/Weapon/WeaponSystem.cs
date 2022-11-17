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
    
    [Header("Reference")]
    public Transform shootpoint;
    public RaycastHit rayHit;
    public GameObject BulletPrefab;
    

    [Header("Graphics")]
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI MagazineText;

    //Ignore Layer Weapon for RayCast, because bullets have a collider, and we want to ignore this collider, for the rayCast
    [Space(10)]
    [SerializeField] LayerMask IgnoreMask = 1 << 10 | 1 << 11;

    // Start is called before the first frame update
    void Start()
    {
        
        bulletsLeft = magazineSize;
        readyToShoot = true;
        

    }

    // Update is called once per frame
    private void Update()
    {
        
        myInput();

        try
        {
            SetTextMagazine(bulletsLeft);
        }
        catch (System.NullReferenceException) { }
        
       

    }

    private void myInput()
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
        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate direction with spread
        

        // Creates a Ray from this object, moving forward
        RaycastHit2D hit = Physics2D.Raycast(shootpoint.position, transform.TransformDirection(Vector2.right), 100f, ~IgnoreMask);
        

        //Test if a collider is hit
        if (hit)
        {
            Debug.Log(hit.collider.name);
        }

       
        Instantiate(BulletPrefab, shootpoint.position, shootpoint.rotation);
        
        
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
        
        MagazineText.SetText( bulletsLeft + " / " + magazineSize);
    }
}


