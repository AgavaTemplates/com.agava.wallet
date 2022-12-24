using UnityEngine;

namespace Agava.Wallet.Editor
{
    internal class WalletFactoryWindowStyles
    {
        private GUIStyle _titleTextStyle;
        private GUIStyle _labelTextStyle;
        private GUIStyle _defaultButtonStyle;

        internal GUIStyle TitleTextStyle()
        {
            return _titleTextStyle 
                ??= new GUIStyle
                {
                    fontSize = 20,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleLeft,
                    margin = new RectOffset(6, 0, 0, 0)
                };
        }
        
        internal GUIStyle LabelTextStyle()
        {
            return _labelTextStyle 
                ??= new GUIStyle
                {
                    fontSize = 12,
                    alignment = TextAnchor.MiddleLeft,
                    margin = new RectOffset(6, 0, 0, 0)
                };
        }
        
        internal GUIStyle DefaultButtonStyle()
        {
            if (_defaultButtonStyle != null)
                return _defaultButtonStyle;

            _defaultButtonStyle = GUI.skin.button;
            _defaultButtonStyle.margin = new RectOffset(3, 0, 0, 0);
            _defaultButtonStyle.fixedWidth = 150;

            return _defaultButtonStyle;
        }
    }
}