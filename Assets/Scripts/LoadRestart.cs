using UnityEngine;
using System.Collections;
   
public class LoadRestart : MonoBehaviour
{
    public GameObject art;
    public GameObject prog;
    public GameObject desi;

    void Start() {
        play();
    }
    void update() {
        //play();
    }

    public void play()
    {
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        /*art.SetActive(true);
        prog.SetActive(true);
        desi.SetActive(true);
        yield return new WaitForSeconds(10);
        art.SetActive(false);
        prog.SetActive(false);
        desi.SetActive(false);*/
        yield return new WaitForSeconds(15);
        Application.LoadLevel("MainMenu");
    }

}
