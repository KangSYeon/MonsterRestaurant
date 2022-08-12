using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenManager : MonoBehaviour
{
    Dictionary<int, string> Monsters = new Dictionary<int, string>();
    Dictionary<int, int[]> Tables = new Dictionary<int, int[]>();
    int[] Table1 = new int[3];

    void Start()
    {
        Monsters.Add(1, "Monster1");
        Monsters.Add(2, "Monster2");
        Monsters.Add(3, "Monster3");
        Monsters.Add(4, "Monster4");

        Table1[0] = 1;
        Table1[1] = 1;
        Table1[2] = 1;

        Tables.Add(1, Table1);
    }
}
