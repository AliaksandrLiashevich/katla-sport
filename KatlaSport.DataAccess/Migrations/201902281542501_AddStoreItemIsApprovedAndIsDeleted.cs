using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations
{
    /// <summary>
    /// Partial class
    /// </summary>
    public partial class AddStoreItemIsApprovedAndIsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product_store_items", "product_store_item_is_approved", c => c.Boolean(nullable: false));
            AddColumn("dbo.product_store_items", "product_store_item_is_deleted", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.product_store_items", "product_store_item_is_deleted");
            DropColumn("dbo.product_store_items", "product_store_item_is_approved");
        }
    }
}
