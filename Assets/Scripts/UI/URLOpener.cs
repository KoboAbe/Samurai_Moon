using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLOpener : MonoBehaviour
{
    public void OpenLink(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
    }
}
