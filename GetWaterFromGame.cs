using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetWaterFromGame : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    public WaterPump WaterScript;

    public float resource_Water;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        textMesh.text = Mathf.RoundToInt(PlayerData.WaterResource_).ToString();
        resource_Water = Mathf.RoundToInt(PlayerData.WaterResource_);
    }
}
