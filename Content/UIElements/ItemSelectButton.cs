using ReLogic.Content;
namespace EasyBuildMod.Content.UIElements
{
    public class ItemSelectButton : UIElement
    {
        
        public Asset<Texture2D> Background { get; set; }

        public Asset<Texture2D> Content { get; set; }

        private static Asset<Texture2D> _backgroundNormal;

        private static Asset<Texture2D> _backgroundHighlight;

        public ItemSelectButton()
        {
            if (_backgroundNormal == null || _backgroundHighlight == null)
            {
                _backgroundNormal = ModContent.Request<Texture2D>("EasyBuildMod/Content/UIElements/ItemSelectButton");
                _backgroundHighlight = ModContent.Request<Texture2D>("EasyBuildMod/Content/UIElements/ItemSelectButtonHighlight");
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

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            Background = _backgroundHighlight;
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            base.MouseOut(evt);
            Background = _backgroundNormal;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            spriteBatch.Draw(Background.Value, GetDimensions().ToRectangle(), Color.White);
            if (Content != null)
            {
                spriteBatch.Draw(Content.Value, GetDimensions().ToRectangle(), Color.White);
            }
        }

        public override void Click(UIMouseEvent evt)
        {
            base.Click(evt);
        }


    }
}