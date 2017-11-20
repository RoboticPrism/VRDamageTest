using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

    public Transform muzzleLocation;
    public GameObject laser;
    public bool isRight;
    Coroutine turnOffLaser = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.5f && !isRight && turnOffLaser == null)
        {
            Shoot();
        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.5f && isRight && turnOffLaser == null)
        {
            Shoot();
        }
    }

    IEnumerator TurnOffLaser()
    {
        yield return new WaitForSeconds(.2f);
        laser.SetActive(false);
        yield return new WaitForSeconds(.2f);
        turnOffLaser = null;
    }

    public void Shoot()
    {
        laser.SetActive(true);
        StopCoroutine("TurnOffLaser");
        turnOffLaser = StartCoroutine(TurnOffLaser());
        RaycastHit hit;
        if (Physics.Raycast(muzzleLocation.position, transform.TransformDirection(Vector3.right), out hit, 100)) {
            if (hit.transform.gameObject.GetComponent<Enemy>())
            {
                hit.transform.gameObject.GetComponent<Enemy>().OnShot();
            }
        }
    }
}
