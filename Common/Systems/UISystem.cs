
using EasyBuildMod.Content.UI;
using System.Collections.Generic;

namespace EasyBuildMod.Common.Systems
{
    public class UISystem : ModSystem
    {
        public static MenuUI CurrentMenuUI { get; set; }

        public static ItemPlaceHelperUI ItemPlaceHelperUI { get; set; }
        private static UserInterface _itemPlaceHelperInterface;


        public static void Init()
        {
            ItemPlaceHelperUI = new ItemPlaceHelperUI();
            _itemPlaceHelperInterface = new UserInterface();
            _itemPlaceHelperInterface.SetState(ItemPlaceHelperUI);
        }

        public override void Load()
        {
            Init();
        }

        public override void Unload()
        {
            ItemPlaceHelperUI = null;
            _itemPlaceHelperInterface = null;
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (ItemPlaceHelperUI.Visible)
            {
                _itemPlaceHelperInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text")); // 表示在鼠标文本之上
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "EasyBuildMod: ItemPlaceHelperUI",
                    delegate
                    {
                        if (ItemPlaceHelperUI.Visible)
                        {
                            _itemPlaceHelperInterface.Draw(Main.spriteBatch, new GameTime());
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public static void Hide()
        {
            CurrentMenuUI?.Hide();
        }
    }
}