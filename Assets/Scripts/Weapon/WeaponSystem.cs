using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSystem : MonoBehaviour
{

    [Header("Weapons")]
    public int damage;
    public float timeBetweenShooting, reloadTime, timeBetweenShots;
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
    [SerializeField] ShakeCamera ShakeCamera_Script;


    public float maxRecoil = 10f;
    public float currentRecoil = 0f;
    float time_elapsed;


    //Ignore Layer Weapon for RayCast, because bullets have a collider, and we want to ignore this collider, for the rayCast
    [Space(10)]
    [SerializeField] LayerMask IgnoreMask = 1 << 10 | 1 << 11;

    // Start is called before the first frame update
    void Start()
    {
        ShakeCamera_Script = GameObject.FindObjectOfType<ShakeCamera>();
        bulletsLeft = magazineSize;
        readyToShoot = true;
        time_elapsed = 0f;
    }
   

   

    // Update is called once per frame
    private void Update()
    {
        print(time_elapsed);
        myInput();

        try
        {
            SetTextMagazine(bulletsLeft);
        }
        catch (System.NullReferenceException) { }

        //print(currentRecoil);

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
            StopCoroutine("ResetRecoil");
            Shoot();
            
        }
        //Reset recoil based on holding down button or not
        if(readyToShoot && !shooting && !reloading && bulletsLeft > 0 && allowButtonHold)
        {
            float recoilIncrement = (float)(maxRecoil * 0.1);
            currentRecoil = Mathf.Clamp((float)(currentRecoil - recoilIncrement), 0.0f, maxRecoil);
        }
        if (readyToShoot && !shooting && !reloading && bulletsLeft > 0 && !allowButtonHold)
        {
            //Not shooting for some time reset recoil
            StartCoroutine("ResetRecoil");
   
        }
    }

    private IEnumerator ResetRecoil()
    {
        yield return new WaitForSeconds(0.8f);
        float recoilIncrement = (float)(maxRecoil * 0.1);
        currentRecoil = Mathf.Clamp((float)(currentRecoil - recoilIncrement), 0.0f, maxRecoil);
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

    public float AddRecoil()
    {
        float recoilDegree = (float)(currentRecoil * 0.1);
        float randomDegree = Random.Range(-recoilDegree, recoilDegree);
        float recoilRadActual = Mathf.Deg2Rad * randomDegree;
        return recoilRadActual;
    }
    private void Shoot()
    {
        
        AddRecoil();
        //StartCoroutine(ShakeCamera_Script.Shake(1f, 1f));
        readyToShoot = false;
        
        
        //Recoil
        float recoilIncrement = (float)(maxRecoil * 0.1);
        currentRecoil = Mathf.Clamp((float)(currentRecoil + recoilIncrement), 0.0f, maxRecoil);

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


