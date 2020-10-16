namespace StoreWarehouse.DataAccess.EntityFramework.Models.Convertor
{
    class ModelConvertor
    {
        #region convert to core entities
        public static Core.Entities.SubCategory Convert(SubCategory sb)
        {
            return sb is null ? null : new Core.Entities.SubCategory { Id = sb.Id, Name = sb.Name, CategoryId = sb.Category?.Id };

        }

        public static Core.Entities.Category Convert(Category c)
        {
            return c is null ? null : new Core.Entities.Category { Name = c.Name, Id = c.Id };
        }

        public static Core.Entities.SubCategoryGood Convert(SubCategoryGood sbg)
        {
            return sbg is null ? null : new Core.Entities.SubCategoryGood { GoodId = sbg.GoodId, SubCategoryId = sbg.SubCategoryId };
        }

        #endregion

        #region convert to entity framework models
        public static SubCategory Convert(Core.Entities.SubCategory sb)
        {
            return sb is null ? null : new SubCategory { Id = sb.Id, Category = null, Name = sb.Name };
        }


        public static Category Convert(Core.Entities.Category c)
        {
            return c is null ? null : new Category { Id = c.Id, Name = c.Name };
        }



        public static SubCategoryGood Convert(Core.Entities.SubCategoryGood sbg)
        {
            return sbg is null ? null : new SubCategoryGood { GoodId = sbg.GoodId, SubCategoryId = sbg.SubCategoryId };
        }

        #endregion
    }
}
