using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using UnityEngine.UI;

public class GetUserData : MonoBehaviour {

    public TextAsset userData;
    public Text[] userDT;
    public float winSC = 0;
    public float loseSC = 0;
    public float shiftSC;
	void Start ()
    {
        var dict = Json.Deserialize(userData.ToString()) as Dictionary<string, object>;
        shiftSC = winSC / (winSC + loseSC) * 100;
        int totalSC = (int)shiftSC;
        //Debug.Log(dict["userid"]);
        //Debug.Log(dict["username"]);
        //Debug.Log(dict["win"]);
        //Debug.Log(dict["lose"]);
        //Debug.Log(dict["lastedConnect"]);
        userDT[0].text = "유저 ID :" + dict["userid"].ToString();
        userDT[1].text = "유저이름 :" + dict["username"].ToString();
        userDT[2].text = "승리 :"+dict["win"].ToString();
        userDT[3].text = "패배 : " + dict["lose"].ToString();
        userDT[4].text = "마지막접속시간 :" + dict["lastedConnect"].ToString();
        userDT[5].text ="승률 :"+ totalSC +"%".ToString();
    }
}
