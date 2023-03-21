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
    //public GameObject BulletPrefab;
    public List<GameObject> BulletPrefabs = new List<GameObject>();
    RecoilSystem recoilSystem_script;
    SwitchWeapon switchWeapon_script;
    LevelUpMenu levelUpMenu_script;

    [Header("Graphics")]
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI MagazineText;
    [SerializeField] ShakeCamera ShakeCamera_Script;

    public float currentRecoil = 0f;

    //Ignore Layer Weapon for RayCast, because bullets have a collider, and we want to ignore this collider, for the rayCast
    [Space(10)]
    [SerializeField] LayerMask IgnoreMask = 1 << 10 | 1 << 11;

    // Start is called before the first frame update
    void Start()
    {
        ShakeCamera_Script = GameObject.FindObjectOfType<ShakeCamera>();
        switchWeapon_script = GameObject.FindObjectOfType<SwitchWeapon>();
        recoilSystem_script = GameObject.FindObjectOfType<RecoilSystem>();
        levelUpMenu_script = GameObject.FindObjectOfType<LevelUpMenu>();
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
            StopCoroutine("ResetRecoil");
            Shoot();
            
        }
        //Reset recoil based on holding down button or not
        if(readyToShoot && !shooting && !reloading && bulletsLeft > 0 && allowButtonHold)
        {
            float recoilIncrement = (float)(recoilSystem_script.distance * 0.2);
            currentRecoil = Mathf.Clamp((float)(currentRecoil - recoilIncrement), 0.0f, recoilSystem_script.distance);
        }
        if (readyToShoot && !shooting && !reloading && bulletsLeft > 0 && !allowButtonHold)
        {
            //Not shooting for some time reset recoil
            StartCoroutine("ResetRecoil");
   
        }
    }

    private IEnumerator ResetRecoil()
    {
        //Reset the recoil after a certain time after shoot function is not called.
        yield return new WaitForSeconds(0.8f);
        float recoilIncrement = (float)(recoilSystem_script.distance * 0.2);
        currentRecoil = Mathf.Clamp((float)(currentRecoil - recoilIncrement), 0.0f, recoilSystem_script.distance);
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
        //muzzleFlash.Play();
        AddRecoil();
        

        //Camera Shake Based on the weapon.
        if(switchWeapon_script.GetWeaponName() == "pistol")
        {
            ShakeCamera_Script.Shake(0.1f, 0.1f);
        }
        if (switchWeapon_script.GetWeaponName() == "Ak")
        {
            ShakeCamera_Script.Shake(0.05f, 0.1f);
        }
        if (switchWeapon_script.GetWeaponName() == "Thompson")
        {
            ShakeCamera_Script.Shake(0.02f, 0.1f);
        }
        if (switchWeapon_script.GetWeaponName() == "Famas")
        {
            ShakeCamera_Script.Shake(0.1f, 0.1f);
        }
        if (switchWeapon_script.GetWeaponName() == "Awp")
        {
            ShakeCamera_Script.Shake(0.2f, 0.3f);
        }
        readyToShoot = false;
        
        
        //Recoil
        float recoilIncrement = (float)(recoilSystem_script.distance * 0.1);
        currentRecoil = Mathf.Clamp((float)(currentRecoil + recoilIncrement), 0.0f, recoilSystem_script.distance);

        //Calculate direction with spread
        

        // Creates a Ray from this object, moving forward
        RaycastHit2D hit = Physics2D.Raycast(shootpoint.position, transform.TransformDirection(Vector2.right), 100f, ~IgnoreMask);
        

        //Test if a collider is hit
        if (hit)
        {
            Debug.Log(hit.collider.name);
            
        }
        //Instantiate the right bullet according to the buff selected.
        if(levelUpMenu_script.GetBuffName == "Bouncy_Bullet")
        {
            Instantiate(BulletPrefabs[1], shootpoint.position, shootpoint.rotation);
            
        }
        else if(levelUpMenu_script.GetBuffName == "Explosive_Bullet")
        {
            Instantiate(BulletPrefabs[2], shootpoint.position, shootpoint.rotation);
        }
        else if (levelUpMenu_script.GetBuffName == "default")
        {
            Instantiate(BulletPrefabs[0], shootpoint.position, shootpoint.rotation);
        }
        else
        {
            Instantiate(BulletPrefabs[0], shootpoint.position, shootpoint.rotation);
        }
        
        
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


