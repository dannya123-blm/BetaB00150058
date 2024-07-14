// This code is based on from Robert Smith's Github Video:
using UnityEngine;

public class Github : MonoBehaviour
{
 
    public string url = "https://github.com/dannya123-blm/SummerIMMB00150058.git";
    public string urlBeta = "https://github.com/dannya123-blm/BetaB00150058.git";

    public void OpenGitHubRepo()
    {
        Application.OpenURL(url);
        Application.OpenURL(urlBeta);
    }
}
