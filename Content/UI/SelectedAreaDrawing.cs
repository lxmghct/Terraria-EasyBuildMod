
using Terraria.GameContent;
using Terraria.UI.Chat;
namespace EasyBuildMod.Content.UI
{
    /// <summary>
    /// 用于绘制: (1)在鼠标末尾画物块预览 (2)矩形区域预览 (3) 矩形大小显示
    /// </summary>
    public class SelectedAreaDrawing
    {
        private Item _item;
        private Rectangle _rectangle;
        public bool IsDrawing { get; set; }
        
        public SelectedAreaDrawing()
        {
            _item = new Item();
            _rectangle = new Rectangle();
            IsDrawing = false;
        }

        public void DrawSelectedArea(int itemId, Rectangle rectangle)
        {
            _item.SetDefaults(itemId);
            _rectangle = rectangle;
            IsDrawing = true;
        }

        private void drawItemPreview()
        {
            if (!IsDrawing)
            {
                return;
            }

        }

        private void drawRectanglePreview()
        {
            if (!IsDrawing)
            {
                return;
            }
            // Vector2 leftTop = _rectangle.TopLeft() * 16 - Main.screenPosition;
            // Vector2 size = _rectangle.Size() * 16;
            // // 绘制实心矩形
            // List<VertexPositionColorTexture> vertexList = new List<VertexPositionColorTexture>();
            // vertexList.Add(new VertexPositionColorTexture(new Vector3(leftTop.X, leftTop.Y, 0), Color.White, new Vector2(0, 0)));
            // vertexList.Add(new VertexPositionColorTexture(new Vector3(leftTop.X + size.X, leftTop.Y, 0), Color.White, new Vector2(1, 0)));
            // vertexList.Add(new VertexPositionColorTexture(new Vector3(leftTop.X + size.X, leftTop.Y + size.Y, 0), Color.White, new Vector2(1, 1)));
            // vertexList.Add(new VertexPositionColorTexture(new Vector3(leftTop.X, leftTop.Y + size.Y, 0), Color.White, new Vector2(0, 1)));
            // Main.graphics.GraphicsDevice.DrawUserPrimitives(0, vertexList.ToArray(), 0, 2, VertexPositionColorTexture.VertexDeclaration);

        }

        private void drawRectangleSize()
        {
            if (!IsDrawing)
            {
                return;
            }
            string sizeText = $"{_rectangle.Width+1} x {_rectangle.Height+1}";
            Vector2 size = FontAssets.MouseText.Value.MeasureString(sizeText);
            Vector2 position = Main.MouseScreen + new Vector2(16, -size.Y + 6);
            ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.MouseText.Value, sizeText, position, Color.White, 0f, Vector2.Zero, Vector2.One);
        }

        public void Draw()
        {
            drawItemPreview();
            drawRectanglePreview();
            drawRectangleSize();
        }

        public void Stop()
        {
            IsDrawing = false;
        }
    }
}