using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletPool : MonoBehaviour
{
    [SerializeField] GameObject buletPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> buletList;

    private static BuletPool instance;
    public static BuletPool Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AddBulets(poolSize);
    }

    private void AddBulets(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bulet = Instantiate(buletPrefab);
            bulet.SetActive(false);
            buletList.Add(bulet);
            bulet.transform.parent = transform;
        }
    }
 
    public GameObject RequesBulet()
    {
        for(int i = 0; i < buletList.Count; i++)
        {
            if (!buletList[i].activeSelf)
            {
                buletList[i]. SetActive(true);
                return buletList[i];
            }
        }
        AddBulets(1);
        buletList[buletList.Count - 1].SetActive(true);
        return buletList[buletList.Count - 1];

    }
}
