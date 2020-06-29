using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameStateManager : MonoBehaviour
{
    string url = "http://solver.planning.domains/solve";
    private string responseText = "";
    GameManager gameManager;
    

    void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        StartCoroutine(PostRequest());
    }

    IEnumerator PostRequest()
    {
        TextAsset domain = Resources.Load<TextAsset>("PDDL/Domain");
        TextAsset problem = (TextAsset)Resources.Load("PDDL/Problem", typeof(TextAsset));

        WWWForm form = new WWWForm();
        form.AddField("problem", problem.text);
        form.AddField("domain", domain.text);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
            responseText = www.downloadHandler.text;
            //Debug.Log(responseText);
            ParseJson(responseText);
            gameManager.Initialize();
        }
        
    }

    void ParseJson(string jsonString)
    {
        //TextAsset text = Resources.Load<TextAsset>("PDDL/placeholderPlan");
        //string jsonString = text.text;
        JSONObject jsonObject = (JSONObject)JSON.Parse(jsonString);

        for (int i = 0; i < jsonObject["result"]["length"]; i++)
        {
            string parsedAction = jsonObject["result"]["plan"][i]["name"];
            parsedAction = parsedAction.Replace("(", string.Empty).Replace(")", string.Empty);
            string[] parameters = parsedAction.Split(' ');
            Action tempAction = new Action();
            for(int j = 0; j < parameters.Length; j++)
            {
                if(j == 0)
                {
                    tempAction.actionName = parameters[j];
                }
                else
                {
                    tempAction.actionParameters.Add(parameters[j]);
                }
            }
            
            gameManager.actionList.Add(tempAction);
        }
    }
}

