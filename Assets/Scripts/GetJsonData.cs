using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class GetJsonData : MonoBehaviour {

    public TextAsset jsonData;
    public Dictionary<string, object> unitData;
    public GameObject unit;

	void Start ()
    {   //json은 MiniJSon스크립트에 선언된 함수다.
        var dict = Json.Deserialize(jsonData.ToString()) as Dictionary<string, object>;//텍스트 에섯으로 선언한 jsondata를 투스트링으로 형변환하여 dictionary안에 있는 dict에다 집어넣는다.
        List<object> unitInfo = dict["UnitInfo"] as List<object>;//list에다가  위에 dict안에 집어넣은 json을 넣는다.
        for (int i = 0; i < unitInfo.Count; i++)
        {
            Dictionary<string, object> unitData = unitInfo[i] as Dictionary<string, object>;
            GameObject unitObj = Instantiate(unit) as GameObject;
            unitObj.GetComponent<UnitScript>().unitName =unitData["이름"].ToString();
            unitObj.GetComponent<UnitScript>().unitHP = int.Parse(unitData["체력"].ToString());
            unitObj.GetComponent<UnitScript>().unitMP = int.Parse(unitData["마나"].ToString());
            unitObj.GetComponent<UnitScript>().unitATK = int.Parse(unitData["공격력"].ToString());
            unitObj.GetComponent<UnitScript>().unitDEF = int.Parse(unitData["방어력"].ToString());
        }
	}
}
