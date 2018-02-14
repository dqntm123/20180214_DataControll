using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCSVRead : MonoBehaviour
{

    public string csvFlieName;
    public GameObject unitPrefab;
    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(csvFlieName);
        //Debug.Log(0 + " 번의 " + " 종족은 ::: " + data[0]["종족"] + " 이름은 ::: " + data[0]["유닛이름"] + " HP ::: " + data[0]["체력"]);
        //for (var i = 0; i < data.Count; i++)
        //{
        //    Debug.Log(i + " 번의 " + " 종족은 ::: " + data[i]["종족"] + " 이름은 ::: " + data[i]["유닛이름"] + " HP ::: " + data[i]["체력"]);
        //}

        for (int i = 0; i < data.Count; i++)
        {
            GameObject unitOBJ = Instantiate(unitPrefab)as GameObject;
            UnitScript unitDetail = unitOBJ.GetComponent<UnitScript>();
            switch (data[i]["종족"].ToString())
            {
                case "프로토스":
                    unitDetail.unitTribe = UnitScript.UNITTRIBE.PROTOSS;
                    break;
                case "저그":
                    unitDetail.unitTribe = UnitScript.UNITTRIBE.ZERG;
                    break;
                case "테란":
                    unitDetail.unitTribe = UnitScript.UNITTRIBE.TERRAN;
                    break;
            }
            unitDetail.unitName = data[i]["유닛이름"].ToString();
            unitDetail.unitHP = int.Parse(data[i]["체력"].ToString());
            unitDetail.unitMP = int.Parse(data[i]["마나"].ToString());
            unitDetail.unitATK = int.Parse(data[i]["공격력"].ToString());
            unitDetail.unitDEF = int.Parse(data[i]["방어력"].ToString());
            unitDetail.unitSHD = int.Parse(data[i]["쉴드"].ToString());
            unitDetail.unitATSP = float.Parse(data[i]["공격속도"].ToString());
            unitDetail.unitMSP = float.Parse(data[i]["이동속도"].ToString());
            unitDetail.unitRange = float.Parse(data[i]["사거리"].ToString());
        }
    }
}