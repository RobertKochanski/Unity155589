using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private List<AmmoSlot> ammoSlots = new List<AmmoSlot>()
    {
        new AmmoSlot(AmmoType.bullets, 30),
        new AmmoSlot(AmmoType.shells, 15),
        new AmmoSlot(AmmoType.sniperBullets, 10),
    };

    [Serializable]
    public class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;

        public AmmoSlot(AmmoType ammoType, int ammoAmount)
        {
            this.ammoType = ammoType;
            this.ammoAmount = ammoAmount;
        }
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = GetAmmoType(ammoType);
        return ammoSlot.ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = GetAmmoType(ammoType);
        ammoSlot.ammoAmount--;
    }

    private AmmoSlot GetAmmoType(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
