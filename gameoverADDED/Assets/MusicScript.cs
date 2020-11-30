using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicScript : MonoBehaviour
{
    public GameObject theManager;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("mymethod", 600f);

    }

    // Update is called once per frame
    void mymethod()
    {
        SceneManager.LoadScene("first");
        DontDestroyOnLoad(theManager);
    }
}
