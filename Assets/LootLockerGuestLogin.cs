using LootLocker.Requests;
using LootLocker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class LootLockerGuestLogin : MonoBehaviour
{
   

    void Start()
    {
        

        /* Start guest session with an unique identifier tied to this device.
         * So if someone uninstall your game, they will be able to log in again when they reinstall to the 
         * same account as long as they are using the same device.
         */
       
    }
}
