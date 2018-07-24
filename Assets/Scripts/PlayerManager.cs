using UnityEngine;

public class PlayerManager:MonoBehaviour
{
    #region UI_Elements
      public  UnityEngine.UI.Slider lifebar;
    #endregion
    public  TwoDPlayerController player;
    #region public_methods

        public void ResetLifebar()
        {
            lifebar.value = 1f;
        }

        public void TakeDamage( float damages )
        {
         //   lifebar.value -= damages / player.GetLifeMax();
        }

    #endregion
}
