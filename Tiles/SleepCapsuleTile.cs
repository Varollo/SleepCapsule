using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SleepCapsule.Tiles
{
    class SleepCapsuleTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sleep Capsule");
            AddMapEntry(new Color(125, 144, 200), name);

            disableSmartCursor = true;
        }

        public override bool HasSmartInteract()
        {
            return true;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 1;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 30, 48, ModContent.ItemType<Items.Placeable.SleepCapsuleItem>());
        }

        public override bool NewRightClick(int i, int j)
        {
            Main.PlaySound(SoundID.Item6, Main.LocalPlayer.position);

            if (!Main.dayTime)
            {
                Main.dayTime = true;
                Main.time = 0;

                if (!Main.raining)
                {
                    Main.NewText("You slept through the night.", Color.BlueViolet);
                }
            }
            else
            {
                Main.dayTime = false;
                Main.time = 0;

                if (!Main.raining)
                {
                    Main.NewText("You slept through the day.", Color.BlueViolet);
                }
            }

            if (Main.raining)
            {
                Main.raining = false;

                Main.NewText("You slept through the rain.", Color.BlueViolet);
            }

            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ModContent.ItemType<Items.Placeable.SleepCapsuleItem>();
        }
    }
}
