using UnityEngine;
using System.Collections;

public class ItemData
{
    public int wood;
    public int stones;
    public int meat;
    public int fur;

    public ItemData(int _wood, int _stones, int _meat, int _fur)
    {
        wood = _wood;
        stones = _stones;
        meat = _meat;
        fur = _fur;
    }
}
