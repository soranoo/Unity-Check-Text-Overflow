# Unity-Check-Text-Overflow
Project start on 26-02-2022

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
![GitHub top language](https://img.shields.io/github/languages/top/soranoo/Unity-Check-Text-Overflow)

A Text(support Text Mesh Pro) class extension to check if the content overflows.

(Text Mesh Pro text doesn't support vertical overflow checking)

### Portal ↠ [Usage](#usage) ↞

## Requirements
* `TextMeshPro` (Unity Plugin)

## Development Environment
* Unity Editor 2020.3.26f1

<a name="usage"></a>
## Usage
In `Unity built-in text`
```
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Text UnityBuiltIn_Text;

    private void Start()
    {
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
```

In `Text Mesh Pro` (Requires `TextMeshPro`(Unity Plugin) installed.)
```
using UnityEngine;
using TMPro;

public class Example : MonoBehaviour
{
    public TMP_Text TextMeshPro_Text;

    private void Start()
    {
        // Text Mesh Pro text
        print(TextMeshPro_Text.IsOverflowingHorizontal());
        // or
        print(TextExtension.IsOverflowingHorizontal(TextMeshPro_Text));
    }
}
```

Or check out the [`Example.cs`](Example.cs)

## TODO
* Support Text Mesh Pro text vertical overflow checking.

## Known Issues
* No known issues
