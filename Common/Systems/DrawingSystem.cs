
using EasyBuildMod.Content.UI;
using System.Collections.Generic;
namespace EasyBuildMod.Common.Systems
{
    /// <summary>
    /// 用于绘制: (1)在鼠标末尾画物块预览 (2)矩形区域预览 (3) 矩形大小显示
    /// </summary>
    public class DrawingSystem : ModSystem
    {
        private static SelectedAreaDrawing _selectedAreaDrawing;

        public override void Unload()
        {
            _selectedAreaDrawing = null;
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            // 在标尺层之上
            int layerIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Ruler"));
            if (layerIndex != -1)
            {
                layers.Insert(layerIndex, new LegacyGameInterfaceLayer(
                    "EasyBuildMod: DrawingSystem",
                    delegate
                    {
                        if (_selectedAreaDrawing != null)
                        {
                            _selectedAreaDrawing.Draw();
                        }
                        return true;
                    },
                    InterfaceScaleType.Game)
                );
            }
        }

        public override void PostUpdateEverything()
        {
        }

        public static void Init()
        {
            if (_selectedAreaDrawing == null)
            {
                _selectedAreaDrawing = new SelectedAreaDrawing();
            }
        }

        public static void StartDraw(Rectangle area)
        {
            Init();
            _selectedAreaDrawing.DrawSelectedArea(area);
        }

        public static void StopDraw()
        {
            _selectedAreaDrawing?.StopDrawing();
        }

        public static void Close()
        {
            _selectedAreaDrawing = null;
        }

    }

}