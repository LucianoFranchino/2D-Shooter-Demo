using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadePool : MonoBehaviour
{
    [SerializeField] GameObject ghPrefab;
    [SerializeField] private int poolSize = 3;
    [SerializeField] private List<GameObject> ghList;

    private static GranadePool instance;
    public static GranadePool Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null)
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
        AddGranades(poolSize);
    }

    void AddGranades(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject granade = Instantiate(ghPrefab);
            granade.SetActive(false);
            ghList.Add(granade);
            granade.transform.parent = transform;
        }
    }

    public GameObject RequestGranade()
    {
        for (int i = 0; i < ghList.Count; i++)
        {
            if (!ghList[i].activeSelf)
            {
                ghList[i].SetActive(true);
                return ghList[i];
            }
        }
        return null;
    }

}
