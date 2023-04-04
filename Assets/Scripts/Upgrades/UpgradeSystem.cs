using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{

    public List<Upgrade> possibleUpgrades;

    private List<Upgrade> upgrade_instance;

    public GameObject uiItem1, uiItem2, uiItem3;
    public Upgrade one, two, three;

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateUpgrades()
    {
        upgrade_instance = possibleUpgrades;

        Upgrade tmp = upgrade_instance[Random.Range(0, upgrade_instance.Count)];
        one = tmp;
        upgrade_instance.Remove(tmp);

        tmp = upgrade_instance[Random.Range(0, upgrade_instance.Count)];
        two = tmp;
        upgrade_instance.Remove(tmp);

        tmp = upgrade_instance[Random.Range(0, upgrade_instance.Count)];
        three = tmp;
        upgrade_instance.Remove(tmp);


        PopulateUI();
    }

    public void PopulateUI()
    {
        uiItem1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = one.upgrade_name;
        uiItem1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = one.upgrade_desc;

        uiItem2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = two.upgrade_name;
        uiItem2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = two.upgrade_desc;
        
        uiItem3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = three.upgrade_name;
        uiItem3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = three.upgrade_desc;
        
    }

    public void Select_One()
    {
        one.Apply();
    }
    public void Select_Two()
    {
        two.Apply();
    }
    public void Select_Three()
    {
        three.Apply();
    }


}
