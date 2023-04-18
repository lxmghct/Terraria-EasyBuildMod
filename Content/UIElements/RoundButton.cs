using ReLogic.Content;
using Terraria.GameContent;
using Terraria.UI.Chat;
using EasyBuildMod.Common.Systems;
namespace EasyBuildMod.Content.UIElements
{
    public class RoundButton : UIElement
    {
        
        public Asset<Texture2D> Background { get; set; }

        public Asset<Texture2D> Content { get; set; }

        private static Asset<Texture2D> _backgroundNormal;

        private static Asset<Texture2D> _backgroundHighlight;

        private static Asset<Texture2D> _backgroundChosen;

        private string _hoverText;
        private bool _isMouseOver;
        private bool _isChosen;

        public RoundButton()
        {
            if (_backgroundNormal == null || _backgroundHighlight == null)
            {
                _backgroundNormal = ModContent.Request<Texture2D>("EasyBuildMod/Content/UIElements/RoundButton");
                _backgroundHighlight = ModContent.Request<Texture2D>("EasyBuildMod/Content/UIElements/RoundButtonHighlight");
                _backgroundChosen = ModContent.Request<Texture2D>("EasyBuildMod/Content/UIElements/RoundButtonChosen");
            }
            Content = null;
            Background = _backgroundNormal;
            Width.Set(50, 0);
            Height.Set(50, 0);
        }

        public void SetContent(Asset<Texture2D> image)
        {
            Content = image;
        }

        public void SetHoverText(string text)
        {
            _hoverText = text;
        }

        public void SetChosen(bool chosen)
        {
            _isChosen = chosen;
            if (_isChosen)
            {
                Background = _backgroundChosen;
            }
            else
            {
                Background = _backgroundNormal;
            }
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            _isMouseOver = true;
            if (!_isChosen)
            {
                Background = _backgroundHighlight;
            }
            UISystem.UsingUI = true;
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            base.MouseOut(evt);
            _isMouseOver = false;
            if (!_isChosen)
            {
                Background = _backgroundNormal;
            }
            UISystem.UsingUI = false;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            spriteBatch.Draw(Background.Value, GetDimensions().ToRectangle(), Color.White);
            if (Content != null)
            {
                CalculatedStyle d = GetDimensions();
                float size = 20;
                spriteBatch.Draw(Content.Value, new Rectangle((int) (d.X + d.Width / 2 - size / 2), (int) (d.Y + d.Height / 2 - size / 2), (int) size, (int) size), Color.White);
            }
            if (_isMouseOver && !string.IsNullOrEmpty(_hoverText))
            {
                Vector2 size = FontAssets.MouseText.Value.MeasureString(_hoverText);
                Vector2 position = Main.MouseScreen + new Vector2(16, -size.Y - 6);
                ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.MouseText.Value, _hoverText, position, Color.White, 0f, Vector2.Zero, Vector2.One);
            }
        }

    }
}