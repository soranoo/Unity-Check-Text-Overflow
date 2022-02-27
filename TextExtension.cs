using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// ----------------Script-Info--------------------
/// Reference:
/// http://answers.unity.com/answers/1776175/view.html
/// -------------------END-------------------------


public static class TextExtension
{
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
        const string _smallestSymbol = "|"; // 20.3 units

        // Save original setting
        bool _wordWrapping = text.enableWordWrapping;
        string _originalText = text.text;

        // start calculating
        text.text = _smallestSymbol;
        text.enableWordWrapping = true;
        float _maximumPreferredHeight = LayoutUtility.GetPreferredHeight(text.rectTransform);
        float _currentPreferredHeight = 0;
        while (_maximumPreferredHeight >= _currentPreferredHeight)
        {
            text.text += _smallestSymbol;
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
    /// <param name="useMaxWidth">If true, the overflow calculation will include all the potential width of the text. (When "Best Fit" is enabled)</param>
    /// <returns></returns>
    public static bool IsOverflowingHorizontal(this Text text, bool useMaxWidth = false)
    {
        float _permissibleWidth = useMaxWidth ? Get_MaxWidth(text) : text.gameObject.GetComponent<RectTransform>().rect.width;
        return LayoutUtility.GetPreferredWidth(text.rectTransform) > _permissibleWidth;
    }

    private static float Get_MaxWidth(Text text)
    {
        const string _smallestSymbol = "|"; // 4 units

        // Save original setting
        HorizontalWrapMode _wordWrapping = text.horizontalOverflow;
        string _originalText = text.text;

        // start calculating
        text.text = _smallestSymbol;
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        float _maximumPreferredHeight = LayoutUtility.GetPreferredHeight(text.rectTransform);
        float _currentPreferredHeight = 0;
        while (_maximumPreferredHeight >= _currentPreferredHeight)
        {
            text.text += _smallestSymbol;
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

    /// <summary>
    /// Check if the text is overflowing vertically.
    /// </summary>
    /// <param name="text">Unity built-in text</param>
    /// <returns></returns>
    public static bool IsOverflowingVertical(this Text text)
    {
        float _permissibleHeight = text.gameObject.GetComponent<RectTransform>().rect.height;
        return LayoutUtility.GetPreferredHeight(text.rectTransform) > _permissibleHeight;
    }
}
