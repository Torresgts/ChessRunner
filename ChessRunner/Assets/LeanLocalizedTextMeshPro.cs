/*
This file is my contribution to use the Lean Localization asset with TextMeshProUGUI, 
I'm not the owner of the main asset, All copyrights are their respective owners.
Please check the original license of the package if you have any questions regarding that.
You can get the asset free on the assetstore:
http://www.assetstore.unity3d.com/#!/content/28504

22.11.2017 K.S.A
github.com/ksnnacar
*/



using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Lean.Localization
{
    // This component will update a Text component with localized text, or use a fallback if none is found
    [ExecuteInEditMode]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LeanLocalizedTextMeshPro : LeanLocalizedBehaviour
    {
        [Tooltip("If PhraseName couldn't be found, this text will be used")]
        public string FallbackText;
        // This gets called every time the translation needs updating
        public override void UpdateTranslation(LeanTranslation translation)
        {
            // Get the TextMeshUI component attached to this GameObject
            var textMesh = GetComponent<TextMeshProUGUI>();

            // Use translation?
            if (translation != null)
            {
                    textMesh.text = LeanTranslation.FormatText((string)translation.Data, textMesh.text, this);
            }
            // Use fallback?
            else
            {
                    textMesh.text = FallbackText;
            }
        }

        protected virtual void Awake()
        {
            // Should we set FallbackText?
            if (string.IsNullOrEmpty(FallbackText) == true)
            {
                // Get the TextMeshUI component attached to this GameObject
                var textMesh = GetComponent<TextMeshProUGUI>();

                // Copy current text to fallback
                    FallbackText = textMesh.text;

            }
        }

    }
}