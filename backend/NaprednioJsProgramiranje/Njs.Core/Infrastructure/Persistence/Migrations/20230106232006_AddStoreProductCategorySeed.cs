using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Njs.Core.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreProductCategorySeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DecimalPlaces",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DecimalSeparator",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Formatting",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GroupSeparator",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Nihil enim at autem pariatur dolores.", "https://picsum.photos/640/480/?image=572", "Baby" },
                    { 2, "Animi voluptate est libero dignissimos sunt qui totam quae.", "https://picsum.photos/640/480/?image=634", "Clothing" },
                    { 3, "Et magnam magnam libero praesentium voluptatem sed sunt id fugiat.", "https://picsum.photos/640/480/?image=238", "Computers" },
                    { 4, "Excepturi molestiae quae veritatis deleniti minus est.", "https://picsum.photos/640/480/?image=813", "Books" },
                    { 5, "Illum reiciendis rerum quasi.", "https://picsum.photos/640/480/?image=374", "Shoes" },
                    { 6, "Quo sint sit commodi tenetur accusantium placeat sunt.", "https://picsum.photos/640/480/?image=904", "Baby" },
                    { 7, "Rerum aliquam est sapiente ut sunt ut omnis maiores.", "https://picsum.photos/640/480/?image=1019", "Clothing" },
                    { 8, "Aut quia sed iste exercitationem enim omnis.", "https://picsum.photos/640/480/?image=233", "Grocery" },
                    { 9, "Ut molestiae quos sint iure.", "https://picsum.photos/640/480/?image=769", "Kids" },
                    { 10, "Nesciunt eum ipsam quo culpa officia quae.", "https://picsum.photos/640/480/?image=1058", "Tools" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "DecimalPlaces", "DecimalSeparator", "Formatting", "GroupSeparator", "Sign" },
                values: new object[,]
                {
                    { 1, "EUR", 2, ".", 0, ",", "€" },
                    { 2, "ISK", 0, ",", 3, ".", "kr." }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "HashedPassword",
                value: "AQAAAAIAAYagAAAAEDMkxkZkRHtpx9JDKSK/5jJWy9d2aODDEZ5S81hBZxM4au5NfpP8RRH2AqCrQM5DAA==");

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "CountryCode", "CurrencyId", "DisplayName", "TenantId" },
                values: new object[,]
                {
                    { 1, "HR", 1, "Croatia", ".1" },
                    { 2, "IS", 2, "Iceland", ".2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ArchivedAtUtc", "Description", "ModifiedAtUtc", "StoreId", "Title" },
                values: new object[,]
                {
                    { 1, null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 1, "Unbranded Cotton Car" },
                    { 2, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 1, "Awesome Granite Pizza" },
                    { 3, null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, 1, "Sleek Steel Car" },
                    { 4, null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 2, "Refined Fresh Salad" },
                    { 5, null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 2, "Gorgeous Rubber Bacon" },
                    { 6, null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 1, "Small Metal Keyboard" },
                    { 7, null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, 2, "Licensed Granite Pizza" },
                    { 8, null, "The Football Is Good For Training And Recreational Purposes", null, 2, "Awesome Granite Bike" },
                    { 9, null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, 2, "Sleek Cotton Shoes" },
                    { 10, null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 1, "Fantastic Wooden Computer" },
                    { 11, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 1, "Handmade Soft Bacon" },
                    { 12, null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, 1, "Practical Metal Computer" },
                    { 13, null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, 2, "Refined Concrete Shirt" },
                    { 14, null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 2, "Gorgeous Granite Car" },
                    { 15, null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, 2, "Tasty Soft Bacon" },
                    { 16, null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, 1, "Practical Cotton Pants" },
                    { 17, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 2, "Incredible Granite Towels" },
                    { 18, null, "The Football Is Good For Training And Recreational Purposes", null, 1, "Fantastic Wooden Table" },
                    { 19, null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 2, "Intelligent Cotton Hat" },
                    { 20, null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 2, "Generic Rubber Sausages" },
                    { 21, null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 1, "Gorgeous Granite Ball" },
                    { 22, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 1, "Fantastic Plastic Mouse" },
                    { 23, null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 2, "Incredible Plastic Pizza" },
                    { 24, null, "The Football Is Good For Training And Recreational Purposes", null, 1, "Generic Cotton Pants" },
                    { 25, null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, 1, "Rustic Granite Car" },
                    { 26, null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 1, "Handcrafted Plastic Sausages" },
                    { 27, null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 2, "Fantastic Plastic Shirt" },
                    { 28, null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, 2, "Licensed Frozen Pizza" },
                    { 29, null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 1, "Ergonomic Granite Chair" },
                    { 30, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 1, "Intelligent Frozen Gloves" },
                    { 31, null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, 1, "Gorgeous Soft Keyboard" },
                    { 32, null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, 2, "Intelligent Plastic Fish" },
                    { 33, null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 2, "Generic Concrete Tuna" },
                    { 34, null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, 2, "Generic Wooden Chicken" },
                    { 35, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 1, "Gorgeous Fresh Bacon" },
                    { 36, null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 2, "Awesome Fresh Towels" },
                    { 37, null, "The Football Is Good For Training And Recreational Purposes", null, 2, "Handmade Rubber Soap" },
                    { 38, null, "The Football Is Good For Training And Recreational Purposes", null, 1, "Unbranded Fresh Sausages" },
                    { 39, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 1, "Incredible Soft Ball" },
                    { 40, null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 2, "Generic Metal Bike" },
                    { 41, null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 1, "Handcrafted Granite Sausages" },
                    { 42, null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 2, "Intelligent Rubber Keyboard" },
                    { 43, null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 2, "Fantastic Metal Shoes" },
                    { 44, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 1, "Gorgeous Cotton Bike" },
                    { 45, null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, 2, "Intelligent Frozen Gloves" },
                    { 46, null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 1, "Fantastic Wooden Hat" },
                    { 47, null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 1, "Tasty Rubber Table" },
                    { 48, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 2, "Unbranded Soft Table" },
                    { 49, null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, 1, "Small Metal Pants" },
                    { 50, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 2, "Handcrafted Concrete Car" },
                    { 51, null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 2, "Fantastic Metal Bike" },
                    { 52, null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 2, "Fantastic Frozen Shoes" },
                    { 53, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 1, "Ergonomic Granite Bacon" },
                    { 54, null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 1, "Fantastic Frozen Shoes" },
                    { 55, null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 2, "Handmade Frozen Fish" },
                    { 56, null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, 2, "Awesome Rubber Chips" },
                    { 57, null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 2, "Rustic Plastic Towels" },
                    { 58, null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 1, "Unbranded Metal Salad" },
                    { 59, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 1, "Sleek Plastic Cheese" },
                    { 60, null, "The Football Is Good For Training And Recreational Purposes", null, 2, "Awesome Fresh Table" },
                    { 61, null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 2, "Handmade Concrete Bike" },
                    { 62, null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 1, "Practical Frozen Sausages" },
                    { 63, null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 2, "Sleek Concrete Hat" },
                    { 64, null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 2, "Practical Fresh Sausages" },
                    { 65, null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 2, "Licensed Soft Tuna" },
                    { 66, null, "The Football Is Good For Training And Recreational Purposes", null, 2, "Refined Granite Fish" },
                    { 67, null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 1, "Tasty Granite Car" },
                    { 68, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 2, "Practical Cotton Computer" },
                    { 69, null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 2, "Awesome Fresh Soap" },
                    { 70, null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 1, "Rustic Wooden Salad" },
                    { 71, null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 2, "Tasty Plastic Car" },
                    { 72, null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 2, "Sleek Cotton Pants" },
                    { 73, null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, 1, "Ergonomic Metal Fish" },
                    { 74, null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 2, "Handmade Frozen Chips" },
                    { 75, null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 1, "Unbranded Wooden Hat" },
                    { 76, null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, 2, "Unbranded Cotton Fish" },
                    { 77, null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 1, "Sleek Concrete Tuna" },
                    { 78, null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 1, "Small Soft Car" },
                    { 79, null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 1, "Sleek Wooden Chair" },
                    { 80, null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 2, "Handmade Wooden Cheese" },
                    { 81, null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 2, "Sleek Cotton Shoes" },
                    { 82, null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, 2, "Handmade Frozen Shoes" },
                    { 83, null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 1, "Ergonomic Frozen Gloves" },
                    { 84, null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 1, "Tasty Granite Chips" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DecimalPlaces",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "DecimalSeparator",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Formatting",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "GroupSeparator",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Sign",
                table: "Currencies");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "HashedPassword",
                value: "AQAAAAIAAYagAAAAELIG5gndRZO6rGKspQZoAfoMKMCvR0QsU2N8CilR1yw+9PjMG7itBsG0lDJZhwcOLw==");
        }
    }
}
