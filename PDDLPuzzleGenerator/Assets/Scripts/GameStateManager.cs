using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameStateManager : MonoBehaviour
{
    string url = "http://solver.planning.domains/solve";
    private string responseText = "";

    void Start()
    {
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
            Debug.Log(responseText);
        }
    }


}
