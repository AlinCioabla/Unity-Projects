using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;


public enum FireMode
{
    Single,
    Burst,
    Auto
}

public class GunController : MonoBehaviour
{

    private Bullet bulletPrefab;
    private Transform shootingPoint;
    public FireMode currentState;
    public Text bulletCount;

    public float burstFireRate = 0.2f;
    public float autoFireRate = 0.1f;
    public int burstAmount = 3;

    private int initialBulletCount;


    public void InitWithPrefab(Bullet _bullet, Transform _shootingPoint, int _initialBulletCount)
    {
        bulletPrefab = _bullet;
        shootingPoint = _shootingPoint;
        initialBulletCount = _initialBulletCount;
        UpdateBullets();
    }

    public void StopFire()
    {
        StopAllCoroutines();
    }

    public void Fire()
    {
        switch (currentState)
        {
            case FireMode.Single:
                CreateBullet();
                break;
            case FireMode.Burst:
                StartCoroutine(FireBurst());
                break;
            case FireMode.Auto:
                break;
        }
    }


    public void ChangeState()
    {

        if ((int)currentState < Enum.GetValues(typeof(FireMode)).Length - 1)
        {
            currentState++;
        }
        else
        {
            currentState = 0;
        }
    }

    private IEnumerator FireBurst()
    {
        for (int i = 0; i < burstAmount; i++)
        {
            CreateBullet();
            yield return new WaitForSeconds(burstFireRate);
        }
    }

    public void Auto()
    {
        StartCoroutine(AutoFire());
    }

    private IEnumerator AutoFire()
    {
        while (true)
        {
            CreateBullet();
            yield return new WaitForSeconds(autoFireRate);
        }
    }

    private void CreateBullet()
    {
        if(CanFire())
        {
            Bullet tmpBullet = Instantiate(bulletPrefab);
            tmpBullet.transform.position = shootingPoint.position;
            tmpBullet.transform.rotation = transform.rotation;
            Rigidbody bulletRb = tmpBullet.GetComponent<Rigidbody>();
            bulletRb.velocity = -tmpBullet.transform.forward * tmpBullet.firePower;
            ChangeBulletCount(-1);
        }
    }

    void UpdateBullets()
    {
        bulletCount.text = " x " + initialBulletCount.ToString();
    }

    public void ChangeBulletCount(int bulletAmount)
    {
        initialBulletCount += bulletAmount;
        UpdateBullets();
    }

    public bool CanFire()
    {
        return initialBulletCount > 0;
    }
}
