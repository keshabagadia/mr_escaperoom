using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public static WinCondition instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);

    }

    public bool WinFlag;
    public bool tile11 = false;
    public bool tile12 = false;
    public bool tile13 = false;
    public bool tile21 = false;
    public bool tile22 = false;
    public bool tile23 = false;
    public bool tile31 = false;
    public bool tile32 = false;

    public bool tile11Free = true;
    public bool tile12Free = true;
    public bool tile13Free = true;
    public bool tile21Free = true;
    public bool tile22Free = true;
    public bool tile23Free = true;
    public bool tile31Free = true;
    public bool tile32Free = false;
    public bool tile33Free = true;

    private void Update()
    {
        if (!WinFlag)
        {
            if (tile11 && tile12 && tile13)
            {

            }
        }
    }
}
