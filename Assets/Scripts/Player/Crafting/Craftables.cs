using UnityEngine;
using System.Collections;

public class Craftables
{
    ItemData _torch = new ItemData(3,2,0,0);
    ItemData _furCoat = new ItemData(0, 0, 0, 4);

    public ItemData Torch
    {
        get
        {
            return _torch;
        }
    }

    public ItemData FurCoat
    {
        get
        {
            return _furCoat;
        }
    }
}
