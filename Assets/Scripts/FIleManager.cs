using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIleManager : MonoBehaviour
{
    public InputField textInput;    //txt ����� �Է�
    public InputField nameInput;    // json �̸�
    public InputField stageInput;   // json ��������
    public InputField scoreInput;   // json ���� 
    public Text outputText;         // ��� ���

    #region txt �Է� UI
    public void OnSaveText()
    {
        if(!string.IsNullOrEmpty(textInput.text))
        {
            FIleInOut.instance.SaveText(textInput.text);
            outputText.text = "txt ���� �Ϸ�";
        }
        else
        {
            outputText.text = "txt ���� ����";
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
            outputText.text = "text ���� �ε� ����";
        }
    }
    public void OnAppendText()
    {
        if(!string.IsNullOrEmpty(textInput.text))
        {
            FIleInOut.instance.UpdateFile(textInput.text);
            outputText.text = "txt ���� �Ϸ� ";
        }
        else
        {
            outputText.text = "text ���� ����";
        }
    }

    public void OnDeleteText()
    {
        FIleInOut.instance.DeleteFIle();
        outputText.text = "txt ���� �Ϸ�!";
    }
    #endregion
    


    #region json �Է� UI
    public void OnSaveJson()
    {
        try
        {
            PlayerData player = new PlayerData();
            player.Name = nameInput.text;
            player.Stage = int.Parse(stageInput.text);
            player.Score = int.Parse(scoreInput.text);

            FIleInOut.instance.SaveJson(player);
            outputText.text = "json ���� �Ϸ�";
        }
        catch(System.Exception e)
        {
            outputText.text = "json ���� ���� : " + e; 
        }
    }
    public void OnLoadJson()
    {
        PlayerData player = FIleInOut.instance.LoadJson();
        if(player != null )
        {
            outputText.text = "�̸� : " + player.Name + ", ���� : " + player.Stage + ", ���� : " + player.Score;
        }
        else
        {
            outputText.text = "json �ε� ����";
        }
    }
    public void OnUpdateJson()
    {
        try
        {
            FIleInOut.instance.UpdateJsonField(nameInput.text, int.Parse(stageInput.text), int.Parse(scoreInput.text));
            outputText.text = "Json ���� �Ϸ�";
        }
        catch(System.Exception e)
        {
            outputText.text = $"JSON ���� ���� : {e.Message}";
        }
    }
    public void OnDeleteJson()
    {
        FIleInOut.instance.DeleteFIle();
        outputText.text = "json ���� �Ϸ�!";
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
