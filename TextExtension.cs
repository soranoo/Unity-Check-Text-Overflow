using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// ----------------Script-Info--------------------
/// script-based by N/A
///
/// Reference:
/// http://answers.unity.com/answers/1776175/view.html
/// -------------------END-------------------------


public static class TextExtension
{
    // Text Mesh Pro text
    private static string SmallestSymbol_TMP = "|"; // 20.3 units
    // Unity built-in text
    private static string SmallestSymbol_Text = "|"; // 4 units


    /// <summary>
    /// Check if the text is overflowing horizontally.
    /// </summary>
    /// <param name="text">Text Mesh Pro text</param>
    /// <returns></returns>
    public static bool IsOverflowingHorizontal(this TMP_Text text)
    {
        return LayoutUtility.GetPreferredWidth(text.rectTransform) > Get_PermissibleWidth(text);
    }

    private static float Get_PermissibleWidth(TMP_Text text)
    {
        // Save original setting
        bool _wordWrapping = text.enableWordWrapping;
        string _originalText = text.text;

        // start calculating
        text.text = SmallestSymbol_TMP;
        text.enableWordWrapping = true;
        float _maximumPreferredHeight = LayoutUtility.GetPreferredHeight(text.rectTransform);
        float _currentPreferredHeight = 0;
        while (_maximumPreferredHeight >= _currentPreferredHeight)
        {
            text.text += SmallestSymbol_TMP;
            _currentPreferredHeight = LayoutUtility.GetPreferredHeight(text.rectTransform);
            if (_currentPreferredHeight < _maximumPreferredHeight)
                _maximumPreferredHeight = _currentPreferredHeight;
        }
        text.text = text.text.Substring(0, text.text.Length - 1);
        float _permissibleWidth = LayoutUtility.GetPreferredWidth(text.rectTransform); // accuracy +- 20.3 units

        // restore original setting
        text.text = _originalText;
        text.enableWordWrapping = _wordWrapping;

        return _permissibleWidth;
    }


    /// <summary>
    /// Check if the text is overflowing horizontally.
    /// </summary>
    /// <param name="text">Unity built-in text</param>
    /// <returns></returns>
    public static bool IsOverflowingHorizontal(this Text text)
    {
        return LayoutUtility.GetPreferredWidth(text.rectTransform) > Get_PermissibleWidth(text);
    }

    private static float Get_PermissibleWidth(Text text)
    {
        // Save original setting
        HorizontalWrapMode _wordWrapping = text.horizontalOverflow;
        string _originalText = text.text;

        // start calculating
        text.text = SmallestSymbol_Text;
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        float _maximumPreferredHeight = LayoutUtility.GetPreferredHeight(text.rectTransform);
        float _currentPreferredHeight = 0;
        while (_maximumPreferredHeight >= _currentPreferredHeight)
        {
            text.text += SmallestSymbol_Text;
            _currentPreferredHeight = LayoutUtility.GetPreferredHeight(text.rectTransform);
            if (_currentPreferredHeight < _maximumPreferredHeight)
                _maximumPreferredHeight = _currentPreferredHeight;
        }
        text.text = text.text.Substring(0, text.text.Length - 1);
        float _permissibleWidth = LayoutUtility.GetPreferredWidth(text.rectTransform); // accuracy +- 4 units

        // restore original setting
        text.text = _originalText;
        text.horizontalOverflow = _wordWrapping;

        return _permissibleWidth;
    }
}
