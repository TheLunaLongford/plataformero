using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heart_bar : MonoBehaviour
{
    //public int max_health = 10;
    private List<GameObject> corazones = new List<GameObject>();
    [SerializeField] private GameObject img_cora;

    // Start is called before the first frame update
    void Start()
    {
        //update_hearts_UI(max_health);
        //update_hearts_UI(0);
    }
    public void update_hearts_UI(int heart_amount)
    {
        clear_bar(corazones);
        corazones.Clear();
        for (int i = 0; i < heart_amount; i++)
        {
            //Agregar un cora
            corazones.Add(Instantiate(img_cora, new Vector3(transform.position.x + (i + 0.1f), transform.position.y, transform.position.z), Quaternion.identity));
            corazones[i].transform.parent = this.transform;
        }
    }

    private void clear_bar(List<GameObject> lista)
    {
        for (int i = 0; i< lista.Count; i++)
        {
            Destroy(lista[i]);
        }
    }

    //public void update_hearts_UI(int max)
    //{
    //    int counter = corazones.Count;
    //    if (max_health > counter)
    //    {
    //        // Si tiene que mostar mas corazones
    //        int hearts_to_add = max_health - counter;
    //        for (int i = 0; i < hearts_to_add; i++)
    //        {
    //            //Agregar un cora
    //            corazones.Add(Instantiate(img_cora, new Vector3(transform.position.x + (i * 20), transform.position.y, transform.position.z), Quaternion.identity));
    //        }
    //    }
    //    else if (max_health < counter)
    //    {
    //        // Si tiene que retirar corazones
    //        int hearts_to_remove = counter - max_health;
    //        for (int i = 0; i < hearts_to_remove; i++)
    //        {

    //        }

    //    }

    //}
}
