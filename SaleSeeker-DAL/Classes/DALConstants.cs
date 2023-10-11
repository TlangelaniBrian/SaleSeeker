using SaleSeeker_DAL.Models;
using System.Collections.ObjectModel;

namespace SaleSeeker_DAL.Classes;

public class DALConstants
{
    public const string userOneID = "ca41fc55-2245-45ef-9344-3b410177e5c8";
    public const string userTwoID = "23d1e052-6455-4366-adc3-9528bc5852e6";
    public const string userThreeID = "7c205bc3-dac2-489a-873b-b5ff3479ef78";
    public const string userFourID = "5a251c9a-3c64-467b-b0c8-ced998e93b1b";

    public const string userRoleOneID = "74141dd4-94db-46ce-b6f4-7663e5cfc6a1";
    public const string userRoleTwoID = "0e297b8a-4806-4302-b59b-b84f8d9ec668";
    public const string userRoleThreeID = "08704695-35bb-42f3-b5dc-ce220c0824ef";
    public enum OrderStatus
    {
        Processing,
        Arriving, //this is usually followed by a date. Your package is on its way to you.
        OutForDelivery, // your package will be delivered today.
        Delivered, //your package has been delivered (remember to check your safe spaces too).
        FailedToDeliver
    }

    public enum PaymentMethod
    {
        StoreCredit,
        CreditCard,
        PayPal,
        ApplePay,
        GooglePay,
        SamsungPay
    }

    public class RoleData
    {
        public static ReadOnlyCollection<Role> RolesList { get; } =
            new ReadOnlyCollection<Role>(
                new[]
                {
                    new Role
                    {
                        Id = userRoleOneID,
                        Name = "Admin",
                        IsActive = true
                    },
                    new Role
                    {
                        Id = userRoleTwoID,
                        Name = "Seller",
                        IsActive = true
                    },
                    new Role
                    {
                        Id = userRoleThreeID,
                        Name = "Buyer",
                        IsActive = true
                    }
                }
            );
    }

    public class UserData
    {
        public static ReadOnlyCollection<User> UsersList { get; } =
            new ReadOnlyCollection<User>(
                new[]
                {
                    new User
                    {
                        Id = userOneID,
                        Name = "Brian",
                        SurName = "Mkhabela",
                        CreatedDateTime = DateTime.Now,
                        Email = "mrbtmkhabela@gmail.com",
                        PasswordHash = "123",
                        Salt = "",
                        PhoneNumber = "0810000003",
                        Address = "4 Sout Road, Cape Town, South Africa",
                        IsActive = true
                    },
                    new User
                    {
                        Id = userTwoID,
                        Name = "Brian-Seller",
                        SurName = "Mkhabela",
                        CreatedDateTime = DateTime.Now,
                        Email = "mrbtmkhabela+0@gmail.com",
                        PasswordHash = "123",
                        Salt = "",
                        PhoneNumber = "0810000002",
                        Address = "5 Mills Road, Cape Town, South Africa",
                        IsActive = true
                    },
                    new User
                    {
                        Id = userThreeID,
                        Name = "Brian-Buyer-1",
                        SurName = "Mkhabela-Buyer-1",
                        CreatedDateTime = DateTime.Now,
                        Email = "mrbtmkhabela+1@gmail.com",
                        PasswordHash = "123",
                        Salt = "",
                        PhoneNumber = "0810000001",
                        Address = "6 Sout Road, Cape Town, South Africa",
                        IsActive = true
                    },
                    new User
                    {
                        Id = userFourID,
                        Name = "Brian-Buyer-2",
                        SurName = "Mkhabela-Buyer-2",
                        CreatedDateTime = DateTime.Now,
                        Email = "mrbtmkhabela+2@gmail.com",
                        PasswordHash = "125",
                        Salt = "",
                        PhoneNumber = "0810000010",
                        Address = "7 Sout Road, Cape Town, South Africa",
                        IsActive = true
                    }
                }
            );
    }

    public class CategoryData
    {
        public static ReadOnlyCollection<Category> CategoriesList { get; } =
            new ReadOnlyCollection<Category>(new[]
                {
                    new Category
                    {
                        Id = 1,
                        Name = "audio"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "cellphones"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "computers"
                    }
                }
            );
    }

    public class ProductData
    {
        public static ReadOnlyCollection<Product> ProductsList { get; } =
           new ReadOnlyCollection<Product>(new[]
                    {
                    new Product
                    {
                        Id = 1,
                        Name = "Apple AirPods",
                        Brand = "Apple",
                        CategoryId = 1,
                        CreatedDatetime = DateTime.Now,
                        Description =
                            "Originally offered only on the AirPods Pro & Max, the 3rd generation of Apple AirPods with Charging Case now feature spatial audio technology with dynamic head tracking, and Dolby Atmos compatibilit",
                        Images = "https://media.techeblog.com/images/apple-airpods-3.jpg",
                        IsActive = true,
                        PricePerUnit = 4300.30M,
                        Quantity = 100,
                        UpdatedDatetime = DateTime.Now,
                        Variant = "(3rd generation)"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Apple iPhone 15 Plus 128GB",
                        Brand = "Apple",
                        CategoryId = 2,
                        CreatedDatetime = DateTime.Now,
                        Description =
                            "iPhone 15 Plus at its best with exceptional materials, super high-resolution photos, and Dynamic Is island",
                        Images = "https://m.xcite.com/media/catalog/product//i/p/iphone_14_pro_-_black_1_4.jpg",
                        IsActive = true,
                        PricePerUnit = 24200.50M,
                        Quantity = 50,
                        UpdatedDatetime = DateTime.Now,
                        Variant = "White"
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Apple Macbook PRO with M2 chip 12 core CPU 19 core GPU, 1TB SSD - Space Grey",
                        Brand = "Apple",
                        CategoryId = 3,
                        CreatedDatetime = DateTime.Now,
                        Description =
                            "macOS is the most advanced desktop operating system in the world. macOS Ventura makes the things you do most on Mac even better, so you can work smarter, play harder, and go further.",
                        Images =
                            "https://alphastore.com.kw/wp-content/uploads/2020/11/13-inch-MacBook-Pro-M1-chip-8-C-CPU-8GB-8-C-GPU-256GB-SSD_1-scaled.jpg",
                        IsActive = true,
                        PricePerUnit = 55500.00M,
                        Quantity = 20,
                        UpdatedDatetime = DateTime.Now,
                        Variant = "14inch"
                    }
           }
        );
    }

    public class StockData
    {
        public static ReadOnlyCollection<Stock> StockList { get; } =
        new ReadOnlyCollection<Stock>(new[]
                {
                    new Stock
                    {
                        Id = 1,
                        CreatedDatetime = DateTime.Now,
                        UpdatedDatetime = DateTime.Now,
                        AvailableQuantity = 10,
                        SoldQuantity = 100,
                        IsActive = true,
                        ProductId =1
                    },
                    new Stock
                    {
                        Id = 2,
                        CreatedDatetime = DateTime.Now,
                        UpdatedDatetime = DateTime.Now,
                        AvailableQuantity = 100,
                        SoldQuantity = 100,
                        IsActive = true,
                        ProductId = 2
                    },
                    new Stock
                    {
                        Id = 3,
                        CreatedDatetime = DateTime.Now,
                        UpdatedDatetime = DateTime.Now,
                        AvailableQuantity = 10,
                        SoldQuantity = 100,
                        IsActive = true,
                        ProductId = 3
                    }
                }
        );
    }

    public class ItemData
    {
        public static ReadOnlyCollection<Item> ItemList { get; } =
            new ReadOnlyCollection<Item>(new[]
            {
                new Item
                {
                    Id = 1,
                    ProductId = 1,
                    CartId = 1,
                    UserId = userRoleThreeID,
                    CreatedDatetime = DateTime.Now
                },
                new Item
                {
                    Id = 2,
                    ProductId = 2,
                    CartId = 1,
                    UserId = userRoleThreeID,
                    CreatedDatetime = DateTime.Now
                },
                new Item
                {
                    Id = 3,
                    ProductId = 1,
                    CartId = 2,
                    UserId = userFourID,
                    CreatedDatetime = DateTime.Now
                },
            }
        );
    }

    public class OrderData
    {
        public static ReadOnlyCollection<Order> OrdersList { get; } =
            new ReadOnlyCollection<Order>(new[]
                {
                    new Order
                    {
                        Id = 1,
                        CreatedDatetime = DateTime.Now,
                        UpdatedDatetime = DateTime.Now,
                        TotalBalance = 0.00M,
                        ShippingAddress = "",
                        Status = OrderStatus.OutForDelivery,
                        PaymentMethod = PaymentMethod.CreditCard,
                        InvoiceNumber = "INV-001",
                        UserId = userRoleThreeID,
                        Items= new List<Item>()
                    },
                    new Order
                    {
                        Id = 2,
                        CreatedDatetime = DateTime.Now,
                        UpdatedDatetime = DateTime.Now,
                        TotalBalance = 0.00M,
                        ShippingAddress = "",
                        Status = OrderStatus.Processing,
                        PaymentMethod = PaymentMethod.CreditCard,
                        InvoiceNumber = "INV-002",
                        UserId = userFourID,
                        Items= new List<Item>()
                    }
                }
            );
    }

    public class UserRoleData
    {
        public static ReadOnlyCollection<UserRole> UserRoleList { get; } =
            new ReadOnlyCollection<UserRole>(new[]
                {
                    new UserRole
                    {
                       Id = 1,
                       RoleId = userRoleOneID,
                       RoleName = "Admin",
                       UserId =userOneID
                    },
                    new UserRole
                    {
                       Id = 2,
                       RoleId = userRoleTwoID,
                       RoleName = "Seller",
                       UserId =userTwoID
                    },
                    new UserRole
                    {
                        Id =3,
                       RoleId = userRoleThreeID,
                       RoleName = "Buyer",
                       UserId = userThreeID
                    },
                    new UserRole
                    {
                        Id = 4,
                       RoleId = userRoleThreeID,
                       RoleName = "Buyer",
                       UserId = userFourID
                    }
                }
            );
    }
}
