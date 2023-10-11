using Microsoft.EntityFrameworkCore;
using SaleSeeker_DAL.Models;
using static SaleSeeker_DAL.Classes.DALConstants;

namespace SaleSeeker_DAL.Configurations;

public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        //Seed Categories
        foreach (var category in CategoryData.CategoriesList)
        {
            _modelBuilder.Entity<Category>().HasData(category);
        }

        //Seed Roles
        foreach (var role in RoleData.RolesList)
        {
            _modelBuilder.Entity<Role>().HasData(role);
        }

        //Seed Users
        foreach (var user in UserData.UsersList)
        {
            _modelBuilder.Entity<User>().HasData(user);
        }

        //Seed Wallets
        foreach (var userRole in UserRoleData.UserRoleList)
        {
            _modelBuilder.Entity<UserRole>().HasData(userRole);
        }

        //Seed Products
        foreach (var product in ProductData.ProductsList)
        {
            _modelBuilder.Entity<Product>().Property<byte[]>("Version")
                .IsRowVersion();
            _modelBuilder.Entity<Product>().HasData(product);
        }

        //Seed Stocks
        foreach (var stock in StockData.StockList)
        {
            _modelBuilder.Entity<Stock>().Property<byte[]>("Version")
                .IsRowVersion();
            _modelBuilder.Entity<Stock>().HasData(stock);
        }
        //Set Item version for optimistic concurency issues
        _modelBuilder.Entity<Item>().Property<byte[]>("Version")
            .IsRowVersion();
    }
}