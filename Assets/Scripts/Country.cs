﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : ScriptableObject
{
    public string countryName;

    public int population;
    public int size;

    public float difficulty;


    public float GetEnemyDamageMelee()
    {
        float damage = 5;

        return damage;
    }

    public float GetEnemyDamageRanged()
    {
        float damage = 5;

        return damage;
    }

    public int GetHousesObjetive()
    {
        int houses = 10;

        return houses;
    }

    public int GetWheatObjetive()
    {
        int wheat = 10;

        return wheat;
    }

    public List<Country> countries;
}
