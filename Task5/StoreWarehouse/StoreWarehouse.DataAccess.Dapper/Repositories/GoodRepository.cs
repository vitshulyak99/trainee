using Dapper;
using StoreWarehouse.Core.Entities;
using StoreWarehouse.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace StoreWarehouse.DataAccess.Dapper.Repositories
{
    public class GoodRepository : IDapperGoodsRepository, IRepository<Good>
    {
        private string _connectionString = string.Empty;
        private bool isCreated = false;

        public GoodRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Good item)
        {
            if (!isCreated)
                CreateTable();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query<Good>("insert into Goods values(@Id,@Name,@ManufacturingDate,@ExpireDate,@Count)", item);
            }

        }

        public bool CheckName(Good item)
        {
            if (!isCreated)
                CreateTable();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Good>("select * from Goods where Id = @Id", item).Count() > 0;
            }
        }

        public Good Get(Guid id)
        {
            if (!isCreated)
                CreateTable();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Good>("select * from Goods where Id = @id", id).FirstOrDefault();
            }
        }

        public IQueryable<Good> GetAll()
        {
            if (!isCreated)
                CreateTable();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Good>("select * from Goods ").AsQueryable();
            }
        }

        public IEnumerable<Good> GetAllByCountLessX(int x)
        {
            if (!isCreated)
                CreateTable();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Good>("select * from Goods where Count < @X", new { X = x });
            }
        }

        public IEnumerable<Good> GetAllByExpireBeforeXDate(DateTime xDate)
        {
            if (!isCreated)
                CreateTable();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Good>("select * from Goods where ExpireDate < @Date", new { Date = xDate });
            }
        }

        public void Remove(Good item)
        {
            if (!isCreated)
                CreateTable();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query<Good>("delete from Goods where Id = @Id", item).FirstOrDefault();
            }
        }

        public void Update(Good newV)
        {
            if (!isCreated)
                CreateTable();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query<Good>("update Goods " +
                    "set " +
                    "Name=@Name," +
                    "ManufacturingDate=@ManufacturingDate," +
                    "ExpireDate=@ExpireDate," +
                    "Count=@Count", newV);
            }
        }

        private void CreateTable()
        {
            if (!isCreated)
            {

                var query = "SELECT TABLE_NAME  FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Goods'";

                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var results = db.Query<string>(query);

                    if (results.Count() == 0)
                    {
                        using (StreamReader reader = new StreamReader("CreateGoodsTable.sql"))
                        {
                            var q = reader.ReadToEnd();
                            db.Query(q);
                        }
                    }
                }

                isCreated = true;
            }
        }
    }
}
