using UnityEngine;

namespace _Project.Aleksa.End
{
    public class LevelFinish
    {
        public void LoseGame()
        {
            Debug.Log("You lost");
            
            AudioHolder.Instance.PowerDown.Play();
            AudioHolder.Instance.AlarmStop();
        }
    }
}