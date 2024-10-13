using System.Collections;
using BabySound;
using UnityEngine;

public class StartApp : MonoBehaviour
{
   private IEnumerator Start()
   {
      yield return new WaitForSeconds(2);
      SceneLoader.Instance.StartGame(Constants.MENU_SCENE);
   }
}
