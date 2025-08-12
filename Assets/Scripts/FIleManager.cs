using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIleManager : MonoBehaviour
{
    public InputField textInput;    //txt 저장용 입력
    public InputField nameInput;    // json 이름
    public InputField stageInput;   // json 스테이지
    public InputField scoreInput;   // json 점수 
    public Text outputText;         // 경과 출력

    #region txt 입려 UI
    public void OnSaveText()
    {
        if(!string.IsNullOrEmpty(textInput.text))
        {
            FIleInOut.instance.SaveText(textInput.text);
            outputText.text = "txt 저장 완료";
        }
        else
        {
            outputText.text = "txt 저장 실패";
        }
    }

    public void OnLoadText()
    {
        string result = FIleInOut.instance.LoadText();

        if(result != null )
        {
            outputText.text = result;
        }
        else
        {
            outputText.text = "text 파일 로드 실패";
        }
    }
    public void OnAppendText()
    {
        if(!string.IsNullOrEmpty(textInput.text))
        {
            FIleInOut.instance.UpdateFile(textInput.text);
            outputText.text = "txt 수정 완료 ";
        }
        else
        {
            outputText.text = "text 수정 실패";
        }
    }

    public void OnDeleteText()
    {
        FIleInOut.instance.DeleteFIle();
        outputText.text = "txt 삭제 완료!";
    }
    #endregion
    


    #region json 입력 UI
    public void OnSaveJson()
    {
        try
        {
            PlayerData player = new PlayerData();
            player.Name = nameInput.text;
            player.Stage = int.Parse(stageInput.text);
            player.Score = int.Parse(scoreInput.text);

            FIleInOut.instance.SaveJson(player);
            outputText.text = "json 저장 완료";
        }
        catch(System.Exception e)
        {
            outputText.text = "json 저장 실패 : " + e; 
        }
    }
    public void OnLoadJson()
    {
        PlayerData player = FIleInOut.instance.LoadJson();
        if(player != null )
        {
            outputText.text = "이름 : " + player.Name + ", 레밸 : " + player.Stage + ", 점수 : " + player.Score;
        }
        else
        {
            outputText.text = "json 로드 실패";
        }
    }
    public void OnUpdateJson()
    {
        try
        {
            FIleInOut.instance.UpdateJsonField(nameInput.text, int.Parse(stageInput.text), int.Parse(scoreInput.text));
            outputText.text = "Json 수정 완료";
        }
        catch(System.Exception e)
        {
            outputText.text = $"JSON 수정 실패 : {e.Message}";
        }
    }
    public void OnDeleteJson()
    {
        FIleInOut.instance.DeleteFIle();
        outputText.text = "json 삭제 완료!";
    }
    #endregion


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
