using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace SleepCapsule.Items.Placeable
{
    class SleepCapsuleItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Put your body to sleep to skip time.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 48;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 2000;
            item.createTile = ModContent.TileType<Tiles.SleepCapsuleTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddTile(TileID.GlassKiln);

            recipe.AddIngredient(ItemID.IronBar, 4);
            recipe.AddIngredient(ItemID.Glass, 10);

            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
