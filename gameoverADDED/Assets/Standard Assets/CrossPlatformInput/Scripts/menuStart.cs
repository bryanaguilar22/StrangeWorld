using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;

public class menuStart : MonoBehaviour
{
    // Start is called before the first frame update
   public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
