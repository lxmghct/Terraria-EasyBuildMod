
using Terraria.GameContent;
using Terraria.UI.Chat;
using EasyBuildMod.Common.Systems;
using System.Collections.Generic;
namespace EasyBuildMod.Content.UI
{
    /// <summary>
    /// 用于绘制: (1)在鼠标末尾画物块预览 (2)矩形区域预览 (3) 矩形大小显示
    /// </summary>
    public class SelectedAreaDrawing
    {
        private Rectangle _rectangle;

        private Texture2D _areaTexture;

        public bool IsDrawing;
        
        public SelectedAreaDrawing()
        {
            _rectangle = new Rectangle();
            IsDrawing = false;
        }

        public void DrawSelectedArea(Rectangle rectangle)
        {
            IsDrawing = true;
            _rectangle = rectangle;
            _areaTexture = new Texture2D(Main.graphics.GraphicsDevice, 1, 1); // 1x1的纯色纹理
        }

        /// <summary>
        /// 绘制物块预览
        /// </summary>
        private void drawItemPreview()
        {
            if (UISystem.ItemPlaceHelperUI is null || UISystem.ItemPlaceHelperUI.itemPlaceHelper is null)
            {
                return;
            }
            int itemId = UISystem.ItemPlaceHelperUI.itemPlaceHelper.PlaceItemType;
            if (itemId == 0)
            {
                return;
            }
            Vector2 position = Main.MouseScreen + new Vector2(32, 32);
            Texture2D texture = TextureAssets.Item[itemId].Value;
            Main.spriteBatch.Draw(texture, position, null, Color.White, 0f, texture.Size() / 2, 1f, SpriteEffects.None, 0f);
        }

        private void drawRectanglePreview()
        {
            Vector2 leftTop = _rectangle.TopLeft() * 16 - Main.screenPosition;
            Vector2 size = _rectangle.Size() * 16;
            Color color = Color.White * 0.7f;
            _areaTexture.SetData(new Color[] { color });
            Main.spriteBatch.Draw(_areaTexture, leftTop, null, color, 0f, Vector2.Zero, size, SpriteEffects.None, 0f);

        }

        private void drawRectangleSize()
        {
            string sizeText = $"{_rectangle.Width} x {_rectangle.Height}";
            Vector2 size = FontAssets.MouseText.Value.MeasureString(sizeText);
            Vector2 position = Main.MouseScreen + new Vector2(16, -size.Y - 6);
            ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.MouseText.Value, sizeText, position, Color.White, 0f, Vector2.Zero, Vector2.One);
        }

        public void Draw()
        {
            drawItemPreview();
            if (IsDrawing)
            {
                drawRectanglePreview();
                drawRectangleSize();
            }
        }

        public void StopDrawing()
        {
            IsDrawing = false;
        }

    }
}