using StoreWarehouse.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StoreWarehouse.UI.UserInterface
{
    using Parsers;
    using StoreWarehouse.Core.Entities;
    using StoreWarehouse.Core.Exceptions;

    class UInterface
    {
        DataManager dataManager;

        public UInterface(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        #region main menu
        public void MainMenu()
        {
            bool loop = true;

            while (loop)
            {
                int mainMenuChoice = Choice(MainMenuInfo);
                MainMenuSwitch(mainMenuChoice, out loop);
            }
        }

        private void MainMenuSwitch(int mainMenuChoice, out bool loop)
        {
            loop = true;

            switch (mainMenuChoice)
            {
                case 1:
                    {
                        GoodsMenu();
                    }
                    break;
                case 2:
                    {
                        CategoriesMenu();
                    }
                    break;
                case 3:
                    {
                        SubCategoriesMenu();
                    }
                    break;
                case 0:
                    {
                        loop = false;
                    }
                    break;

                default:
                    {
                        Console.WriteLine("invalid choice! please try again");
                    }
                    break;
            }
        }

        private string MainMenuInfo =>
          "\n1 - goods \n"
          + "2 - categories \n"
          + "3 - subcategories \n"
          + "0 - exit\n";

        #endregion

        #region goods menu
        private void GoodsMenu()
        {
            bool loop = true;

            while (loop)
            {
                var choice = Choice(GoodMenuInfo);
                GoodsMenuSwitch(choice, out loop);
            }

        }

        private void GoodsMenuSwitch(int choice, out bool loop)
        {
            loop = true;

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("\n## All goods list ");
                        var goods = dataManager.GetAllGoods();
                        Print(goods);
                        Console.WriteLine("## end list ");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("\n## Adding good");
                        Good good = CreateGood();

                        try
                        {
                            dataManager.AddGood(good);
                        }
                        catch (InvalidExpirationDateException ex)
                        {
                            Console.WriteLine("expiration date can't be less manufacturing date. action cannot be complete");
                        }

                        Console.WriteLine("## End adding good");

                    }
                    break;
                case 3:
                    {

                        Console.WriteLine("\n## Edit good");
                        var goods = dataManager.GetAllGoods();
                        var item = SelectItem(goods);
                        item = EditGood(item);

                        try
                        {
                            dataManager.UpdateGood(item);
                        }
                        catch (InvalidExpirationDateException ex)
                        {
                            Console.WriteLine("expiration date can't be less manufacturing date. action cannot be complete");
                        }

                        Console.WriteLine("\n## End edit good");

                    }
                    break;
                case 4:
                    {

                        Console.WriteLine("\n## Remove good");
                        var goods = dataManager.GetAllGoods();
                        var good = SelectItem(goods);
                        Console.WriteLine("## End remove ");
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine("\n## Get all goods by expiration date before xDate");

                    enterExDateAgain:
                        var xDateStr = Input("Enter xDate. (format: mm/dd/yyyy)");
                        var xDate = Parser.ParseDate(xDateStr);

                        if (xDate is null)
                        {
                            Console.WriteLine("invalid input. please try again.");
                            goto enterExDateAgain;
                        }
                        else
                        {
                            var goods = dataManager.GetAllGoodsWhereExpireDateBefore(xDate.Value);
                            Print(goods);
                        }

                        Console.WriteLine("## end list by expire date");
                    }
                    break;
                case 6:
                    {
                        Console.WriteLine("\n## Get all goods by amount less xCount ");
                    enterExCountAgain:

                        var xCountStr = Input("enter xCount. (integer)");
                        var xCount = Parser.ParseInt(xCountStr);

                        if (xCount is null)
                        {
                            Console.WriteLine("invalid input. pls try again.");
                            goto enterExCountAgain;
                        }
                        else
                        {
                            var goods = dataManager.GetAllGoodsWhereCount(xCount.Value);
                            Print(goods);
                        }

                        Console.WriteLine("## ");
                    }
                    break;
                case 0:
                    {
                        Console.WriteLine("\n## Back <--");
                        loop = false;
                    }
                    break;
                default:
                    {
                        Console.WriteLine("invalid choice! please try again ");
                    } break;
            }
        }

        private Good EditGood(Good good)
        {
            string tmp = string.Empty;

        enterNameAgain:
            Console.WriteLine("enter new name pls. '-' to skip. \n");

            tmp = Console.ReadLine();

            if (tmp != "-")
            {
                var name = tmp;

                if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("invalid name value! pls try again\n");
                    goto enterNameAgain;
                }
                else
                {
                    good.Name = name;
                }
            }

        enterManufacturingDateAgain:
            Console.WriteLine("enter new manufacturing date pls. '-' to skip. (format:mm//dd//yyyy)\n");

            tmp = Console.ReadLine();

            if (tmp != "-")
            {
                var mDate = Parser.ParseDate(tmp);

                if (mDate is null)
                {
                    Console.WriteLine("invalid manufacturing date value! pls try again\n");
                    goto enterManufacturingDateAgain;
                }
                else
                {
                    good.ManufacturingDate = mDate.Value;
                }
            }

        enterExpireDateAgain:
            Console.WriteLine("enter expiration date pls. (format:mm//dd//yyyy)\n");

            tmp = Console.ReadLine();

            if (tmp != "-")
            {
                var eDate = Parser.ParseDate(tmp);

                if (eDate is null)
                {
                    Console.WriteLine("invalid expiration date value! pls try again\n");
                    goto enterExpireDateAgain;
                }
                else
                {
                    good.ExpireDate = eDate.Value;
                }
            }

        enterCountAgain:
            Console.WriteLine("enter amount pls");

            tmp = Console.ReadLine();

            if (tmp != "-")
            {
                var count = Parser.ParseInt(tmp);

                if (count is null)
                {
                    Console.WriteLine("invalid amount value! pls try again\n");
                    goto enterCountAgain;
                }
                else
                {
                    good.Count = count.Value;
                }
            }

            return good;
        }

        private string GoodMenuInfo =>
          "\n1 - all goods\n"
          + "2 - add good\n"
          + "3 - edit good\n"
          + "4 - remove good\n"
          + "5 - get goods by expiration date before xdate\n"
          + "6 - get goods by amount less xcount\n"
          + "0 - back";

        private Good CreateGood()
        {

            Good good = new Good { Id = Guid.NewGuid() };

        enterNameAgain:
            Console.WriteLine("enter name pls\n");

            var name = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("invalid name value! pls try again\n");
                goto enterNameAgain;
            }
            else
            {
                good.Name = name;
            }

        enterManufacturingDateAgain:
            Console.WriteLine("enter manufacturing date pls. (format:mm//dd//yyyy)\n");
            
            var mDate = Parser.ParseDate(Console.ReadLine());

            if (mDate is null)
            {
                Console.WriteLine("invalid manufacturing date value! pls try again\n");
                goto enterManufacturingDateAgain;
            }
            else
            {
                good.ManufacturingDate = mDate.Value;
            }

        enterExpireDateAgain:
            Console.WriteLine("enter expiration date pls. (format:mm//dd//yyyy)\n");
            
            var eDate = Parser.ParseDate(Console.ReadLine());

            if (eDate is null)
            {
                Console.WriteLine("invalid expiration date value! pls try again\n");
                goto enterExpireDateAgain;
            }
            else
            {
                good.ExpireDate = eDate.Value;
            }

        enterCountAgain:
            Console.WriteLine("enter amount pls");
            
            var count = Parser.ParseInt(Console.ReadLine());

            if (count is null)
            {
                Console.WriteLine("invalid amount value! pls try again\n");
                goto enterCountAgain;
            }
            else
            {
                good.Count = count.Value;
            }

            return good;

        }

        #endregion



        #region subcategories menu

        private void SubCategoriesMenu()
        {
            bool loop = true;

            while (loop)
            {
                var choice = Choice(SubCategoryMenuInfo);
                SubCategoriesMenuSwitch(choice, out loop);
            }
        }

        private void SubCategoriesMenuSwitch(int choice, out bool loop)
        {
            loop = true;

            switch (choice)
            {
                case 1:
                    {

                        Console.WriteLine("\n## all subcategoris list");
                        var subcategories = dataManager.GetAllSubCategories();
                        Print(subcategories);
                        Console.WriteLine("## end subcategoris list");

                    }
                    break;

                case 2:
                    {
                        Console.WriteLine("\n## add subcategory");
                        var categories = dataManager.GetAllCategories();

                        if (categories.Count() < 1)
                        {
                            Console.WriteLine("pls add at least one category to continue working with subcategories");
                        }
                        else
                        {
                            SubCategory subCategory = CreateSubCategory(categories);
                            try
                            {
                                dataManager.AddSubCategory(subCategory);
                            }
                            catch (ExistCategoryNameException ex)
                            {
                                Console.WriteLine("subcategory with the same name already exist\n action cannot be completed");
                            }
                        }
                        Console.WriteLine("## end add subcategory");

                    }
                    break;

                case 3:
                    {
                        Console.WriteLine("\n## edit subcategory");
                        var subcategories = dataManager.GetAllSubCategories();
                        var categories = dataManager.GetAllCategories();
                        var subcategory = SelectItem(subcategories);

                        var newSubcategory = EditSubCategory(subcategory, categories);
                      
                        try
                        {
                            dataManager.UpdateSubCategory(newSubcategory);

                        }
                        catch (ExistSubCategoryNameException ex)
                        {
                            Console.WriteLine("subcategory with the same name already exist\n action cannot be completed");
                        }
                       
                        Console.WriteLine("## end edit subcategory");

                    }
                    break;

                case 4:
                    {
                        Console.WriteLine("\n## remove subcategory");
                        var subcategories = dataManager.GetAllSubCategories();
                        var subcategory = SelectItem(subcategories);

                        dataManager.RemoveSubCategory(subcategory);

                        Console.WriteLine("## end remove subcategory");
                    }
                    break;

                case 5:
                    {
                        Console.WriteLine("\n## add good to subcategory");
                        var subcategories = dataManager.GetAllSubCategories();
                        var goods = dataManager.GetAllGoods();

                        Console.WriteLine("select subcategory");
                        var subcategory = SelectItem(subcategories);

                        Console.WriteLine("select good");
                        var good = SelectItem(goods);

                        dataManager.AddGoodToSubCaategory(good, subcategory);

                        Console.WriteLine("## end add good to subcategory ");
                    }
                    break;

                case 0:
                    {
                        Console.WriteLine("\n## back <--");

                        loop = false;
                    }
                    break;

            }
        }

        private SubCategory EditSubCategory(SubCategory subcategory,IEnumerable<Category> categories)
        {
        againName:
            var nameStr = Input("enter new name or enter '-' to back\n");

            if (nameStr != "-")
            {
                if (string.IsNullOrEmpty(nameStr) || string.IsNullOrWhiteSpace(nameStr))
                {
                    Console.WriteLine("\ninvalid input. pls try again");
                    goto againName;
                }
                else
                {
                    subcategory.Name = nameStr;
                }
            }

        againCategory:

            var categoryStr = Input("any - choice Category, '-' - skip");

            if (categoryStr != "-")
            {
                var category = SelectItem(categories);
                subcategory.CategoryId = category.Id;
            }

            return subcategory;
        }

        private SubCategory CreateSubCategory(IEnumerable<Category> categories)
        {
            SubCategory subCategory = new SubCategory { Id = Guid.NewGuid() };

        enterNameAgain:

            var name = Input("Enter name pls");

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("invalid input. pls try again.");
                goto enterNameAgain;
            }
            else
            {
                subCategory.Name = name; 
            }

            var category = SelectItem(categories);

            subCategory.CategoryId = category?.Id;

            return subCategory;
        }

        private string SubCategoryMenuInfo =>
           "\n1 - all subcategories\n"
           + "2 - add subcategories\n"
           + "3 - edit subcategories\n"
           + "4 - remove subcategories\n"
           + "5 - add good to subcategory\n"
           + "0 - back";

        #endregion

        #region categories menu
        private void CategoriesMenu()
        {
            bool loop = true;

            while (loop)
            {
                var choice = Choice(CategoryMenuInfo);
                CategoryMenuMenuSwitch(choice, out loop);
            }
        }

        private void CategoryMenuMenuSwitch(int choice, out bool loop)
        {
            loop = true;

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("\n## all categoriies list");

                        var categories = dataManager.GetAllCategories();

                        Print(categories);

                        Console.WriteLine("## end all categoriies");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("\n## add category");
                        var category = CreateCategory();
                        try
                        {
                            dataManager.AddCategory(category);
                        }
                        catch (ExistCategoryNameException ex)
                        {
                            Console.WriteLine("category with it name is exist. action cannot be complete");
                        }
                        Console.WriteLine("## end add category");
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("\n## edit category");
                        var categories = dataManager.GetAllCategories();
                        var category = SelectItem(categories);
                        var newCategory = EditCategory(category);

                        try
                        {
                            dataManager.UpdateCategory(category);
                        
                        } catch (ExistCategoryNameException ex)
                        {
                            Console.WriteLine("category with this name is already exist. action cannot be copmlete");
                        } 
                        Console.WriteLine("## end edit category");
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("\n## remove category");
                        var categories = dataManager.GetAllCategories();
                        Console.WriteLine("select category to remove");
                        var category = SelectItem(categories);
                        dataManager.RemoveCategory(category);
                        Console.WriteLine("\n## end remove category");
                    }
                    break;
                case 0:
                    {
                        Console.WriteLine("\n## back <--");
                        loop = false;
                    }
                    break;
            }

        }

        private Category EditCategory(Category category)
        {

        again:
            var str = Input("enter new name or enter '-' to back\n");
            if (str == "-")
            {
                return null;
            }
            else if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("\ninvalid input. pls try again");
                goto again;
            }
            else
            {
                category.Name = str;
                return category;
            }

        }

        private Category CreateCategory()
        {
            Category category = new Category() { Id = Guid.NewGuid() };
            string name;
        again:
            name = Input("Enter category Name");

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("\ninvalid input. Name can't be empty or white space or null. try again\n");

                goto again;
            }
            else
            {
                category.Name = name;

                return category;
            }

        }

        private string CategoryMenuInfo =>
            "\n1 - all categories\n"
            + "2 - add categories\n"
            + "3 - edit categories\n"
            + "4 - remove categories\n"
            + "0 - back <--";


        #endregion

        private int Choice(string MenuInfo)
        {
            Console.WriteLine(MenuInfo);


        ChoiceAgain:
            var choiceStr = Console.ReadLine();

            var choice = Parser.ParseInt(choiceStr);

            if (choice is null)
            {
                Console.WriteLine("invalid input. please enter integer value");
                goto ChoiceAgain;
            }

            return choice.Value;
        }


        private void Print<T>(IEnumerable<T> items)
        {
            if (items.Count() > 0)
            {
                int i = 0;
                foreach (var item in items)
                {
                    Console.WriteLine($"$index: {i++} item: { item.ToString()} \n#\n\n");
                }
            }
            else
            {
                Console.WriteLine("table no contains records\n");
            }
        }

        private T SelectItem<T>(IEnumerable<T> items)
        {
            int count = items.Count();

            Print(items);

            string indexString = Input("input index of item");

            var index = Parsers.Parser.ParseInt(indexString);

            if (index is null)
            {
                Console.WriteLine("invalid input index value");

                return default;
            }
            else
            {
                return items.ElementAt(index.Value);
            }
        }

        private string Input(string message)
        {
            Console.WriteLine(message + '\n');

            return Console.ReadLine();
        }

        //private int CreatePropertyValueInt(string val, string propertyName, string format)
        //{
        //again:
        //    Console.WriteLine($"enter {propertyName} pls. format : {format}");

        //    var v = Parser.ParseInt(val);
        //    if (v is null)
        //    {
        //        Console.WriteLine($"invalid {propertyName} value! pls try again\n");
        //        goto again;
        //    }
        //    else
        //    {
        //        return v.Value;
        //    }
        //}

        //private DateTime CreatePropertyValueDate(string val, string propertyName, string format)
        //{
        //again:
        //    Console.WriteLine($"enter {propertyName} pls. format : {format}");

        //    var v = Parser.ParseDate(val);

        //    if (v is null)
        //    {
        //        Console.WriteLine($"invalid {propertyName} value! pls try again\n");
        //        goto again;
        //    }
        //    else
        //    {
        //        return v.Value;
        //    }
        //}

        //private string CreatePropertyValueString(string val ,string propertyName, string format)
        //{
        //again:
        //    Console.WriteLine($"enter {propertyName} pls. format : {format}");

        //    if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val))
        //    {
        //        Console.WriteLine($"invalid {propertyName} value! pls try again\n");
        //        goto again;
        //    }
        //    else
        //    {
        //        return val;
        //    }
        //}
    }
}
