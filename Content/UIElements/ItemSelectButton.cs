using ReLogic.Content;
namespace EasyBuildMod.Content.UIElements
{
    public class ItemSelectButton : UIElement
    {
        
        public Asset<Texture2D> Background { get; set; }

        public Asset<Texture2D> Content { get; set; }

        public ItemSelectButton()
        {
            Background = ModContent.Request<Texture2D>("EasyBuildMod/Content/UIElements/ItemSelectButton");
            Content = null;
            Width.Set(50, 0);
            Height.Set(50, 0);
        }

        public void SetContent(Asset<Texture2D> image)
        {
            Content = image;
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