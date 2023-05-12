using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public GameObject Player;
    private int ChosenCharacter = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && ChosenCharacter > 0)
        {
            DeSelectCharacter();
            ChosenCharacter--;
            SelectCharacter();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && ChosenCharacter < gameObject.transform.childCount - 1)
        {
            DeSelectCharacter();
            ChosenCharacter++;
            SelectCharacter();
        }

        void DeSelectCharacter()
        {
            var srOld = gameObject.transform.GetChild(ChosenCharacter).GetComponent<Image>();
            srOld.color = new Color(1f, 1f, 1f, 0.392f);
        }

        void SelectCharacter()
        {
            var srNew = gameObject.transform.GetChild(ChosenCharacter).GetComponent<Image>();
            srNew.color = new Color(1f, 1f, 1f, 1f);

            var srPlayer = Player.GetComponent<SpriteRenderer>();
            srPlayer.sprite = srNew.sprite;
        }
    }
}