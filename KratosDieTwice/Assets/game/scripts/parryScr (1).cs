using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class parryScr : MonoBehaviour
{
    //Parry ya da blockla ilgili bir þey yapmak isterseniz if(parry) yazmanýz yeter
    public bool blocking, parry, cooldown;

    //Bu test için
    public Material mavi;
    
    //Süreleri burdan ayarlayabilirsiniz
    public float cooldownTime = 0.5f, parryGap = 0.2f;
    public float timerCooldown = 0, timerParry = 0;

    private void Start()
    {
        mavi.color = Color.yellow;
    }

    private void Update()
    {
        if (cooldown)
        {
            timerCooldown += Time.deltaTime;
            if (timerCooldown >= cooldownTime)
            {
                cooldown = false;
                timerCooldown = 0;
            }
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !cooldown)
        {
            blocking = true;
            parry = true;
            timerParry = 0;
        }

        if (Keyboard.current.spaceKey.isPressed && blocking)
        {
            if (parry)
            {
                timerParry += Time.deltaTime;
                if (timerParry >= parryGap)
                {
                    parry = false;
                }
            }
        }

        if (Keyboard.current.spaceKey.wasReleasedThisFrame && blocking)
        {
            blocking = false;
            parry = false;

            cooldown = true;
            timerCooldown = 0;
        }


        //Bu kýsým test için
        if (parry)
        {
            mavi.color = Color.red;
        }
        else if (blocking)
        {
            mavi.color = Color.blue;
        }
        else
        {
            mavi.color = Color.yellow;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (parry)
        {
            Destroy(other.gameObject);
            print("PARRY");
        }
        else if (blocking)
        {
            Destroy(other.gameObject);
            print("BLOCKED");
        }
    }
}