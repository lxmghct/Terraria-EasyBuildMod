
using EasyBuildMod.Content.UI;
using System.Collections.Generic;

namespace EasyBuildMod.Common.Systems
{
    public class UISystem : ModSystem
    {
        private static MenuUI _currentMenuUI;
        public static MenuUI CurrentMenuUI
        {
            get => _currentMenuUI;
            set
            {
                if (_currentMenuUI != value)
                {
                    MenuUI oldMenuUI = _currentMenuUI;
                    _currentMenuUI = value;
                    oldMenuUI?.Close();
                }
            }
        }

        public static ItemPlaceHelperUI ItemPlaceHelperUI { get; set; }
        private static UserInterface _itemPlaceHelperInterface;

        public static ItemDestroyHelperUI ItemDestroyHelperUI { get; set; }
        private static UserInterface _itemDestroyHelperInterface;


        public static void Init()
        {
            ItemPlaceHelperUI = new ItemPlaceHelperUI();
            _itemPlaceHelperInterface = new UserInterface();
            _itemPlaceHelperInterface.SetState(ItemPlaceHelperUI);
            ItemDestroyHelperUI = new ItemDestroyHelperUI();
            _itemDestroyHelperInterface = new UserInterface();
            _itemDestroyHelperInterface.SetState(ItemDestroyHelperUI);
        }

        public override void Load()
        {
            Init();
        }

        public override void Unload()
        {
            ItemPlaceHelperUI = null;
            _itemPlaceHelperInterface = null;
            ItemDestroyHelperUI = null;
            _itemDestroyHelperInterface = null;
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (ItemPlaceHelperUI.Visible)
            {
                _itemPlaceHelperInterface.Update(gameTime);
            }
            if (ItemDestroyHelperUI.Visible)
            {
                _itemDestroyHelperInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text")); // 表示在鼠标文本之上
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "EasyBuildMod: MyMenuUI",
                    delegate
                    {
                        if (ItemPlaceHelperUI.Visible)
                        {
                            _itemPlaceHelperInterface.Draw(Main.spriteBatch, new GameTime());
                        }
                        if (ItemDestroyHelperUI.Visible)
                        {
                            _itemDestroyHelperInterface.Draw(Main.spriteBatch, new GameTime());
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