using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heart_bar : MonoBehaviour
{
    private List<GameObject> corazones = new List<GameObject>();
    [SerializeField] private GameObject img_cora;

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

}
