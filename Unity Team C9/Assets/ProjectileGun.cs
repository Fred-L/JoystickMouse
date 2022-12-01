// SHOOTING with BULLETS + CUSTOM PROJECTILES || Unity 3D Tutorial (#1)
// https://www.youtube.com/watch?v=wZ2UUOC17AY&list=RDCMUCIWlCE2kt0RXCJLRp8HjhiQ&index=13

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileGun : MonoBehaviour
{
    public Controller messageController;
    public string message;

    bool messagePog;

    public GameObject bullet;
    public GameObject bullet2;

    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading, reloadInput;

    public Camera fpsCam;
    public Transform attackPoint;

    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;
    public TextMeshProUGUI scrollWheel;

    public bool allowInvoke = true;

    public bool scroll = true;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        messagePog = true;
        messageController = GameObject.Find("Player").GetComponent<Controller>();
    }

    private void Update()
    {
        message = messageController.message;
        //Debug.Log(message);
        
        ScrollWheel();

        
        PlayerInput();

        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText("Ammo: " + bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap); 
        
    }

    private void PlayerInput()
    {
        if (allowButtonHold)
        {
            if (message == "Mouse 1" || Input.GetKey(KeyCode.Mouse0))
                shooting = true;
            else
                shooting = false;

        }
        //shooting = Input.GetKey(KeyCode.Mouse0);

        else
        {
            if (message == "Mouse 1" || Input.GetKey(KeyCode.Mouse0))
                shooting = true;
            else
                shooting = false;
        }
        //shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (message == "Mouse 2")
            reloadInput = true;
        else
            reloadInput = false;

        if (reloadInput && bulletsLeft < magazineSize && !reloading)
            Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
            Reload();


        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            if (scroll)
                Shoot();
            else
                Shoot2();
        }
        
    }

    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        currentBullet.transform.forward = directionWithoutSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void Shoot2()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet2, attackPoint.position, Quaternion.identity);

        currentBullet.transform.forward = directionWithoutSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
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

    private void ScrollWheel()
    {

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if (scrollWheel != null)
                scrollWheel.SetText("Scroll Wheel Up Fire");

            scroll = true;
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if (scrollWheel != null)
                scrollWheel.SetText("Scroll Wheel Down Water");

            scroll = false;
        }
        //else
        //{ 
        //    if (scrollWheel != null)
        //    scrollWheel.SetText("Scroll Wheel Neutral");
        //}
    }
}
