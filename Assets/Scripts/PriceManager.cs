using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    public uint price;
    public uint firstPrice = 50;

    private void Start()
    {
        price = firstPrice;
    }

    public uint GetPrice()
    {
        return price;
    }

    public uint Expensiver(uint nowPrice)
    {
        price = (uint)(nowPrice * 1.25f);
        return price;
    }
}
