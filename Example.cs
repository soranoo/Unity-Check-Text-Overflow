using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Example : MonoBehaviour
{
    public TMP_Text TextMeshPro_Text;
    public Text UnityBuiltIn_Text;

    private void Start()
    {
        // Text Mesh Pro text
        // (Horizontal)
        print(TextMeshPro_Text.IsOverflowingHorizontal());
        // or
        print(TextExtension.IsOverflowingHorizontal(TextMeshPro_Text));



        // Unity built-in text
        // (Horizontal)
        print(UnityBuiltIn_Text.IsOverflowingHorizontal());
        // or
        print(TextExtension.IsOverflowingHorizontal(UnityBuiltIn_Text));

        // (Vertical)
        print(UnityBuiltIn_Text.IsOverflowingVertical());
        // or
        print(TextExtension.IsOverflowingVertical(UnityBuiltIn_Text));
    }
}
