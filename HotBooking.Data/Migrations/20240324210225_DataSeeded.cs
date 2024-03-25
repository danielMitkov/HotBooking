using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotBooking.Data.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PublicId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "7fe8fa0f-0386-404c-8f54-e4550bef1a7d", "guest@mail.com", true, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEMAhdQwud82rG2+Ngn11U+oAuryScS8GYhboVI1cZJETapvi594UPWtMBn9KpbXTHA==", null, false, new Guid("d5edba6e-8118-4bc7-aa2b-039c8aa4170e"), null, false, "guest@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PublicId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "bf43d447-3916-4421-9e1a-28b4fad80ae9", "two@mail.com", true, false, null, "two@mail.com", "two@mail.com", "AQAAAAEAACcQAAAAEDSH0RwxJuK1nBzb0xKMCMN6RYBXbAwffyAaL2fqvrjBQo/HsJieS8e2aCVIY+oduA==", null, false, new Guid("355804ae-44e0-47c5-b957-712f6358699b"), null, false, "two@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PublicId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, 0, "8a83d33a-4fe7-451c-9141-894d50be5f97", "manager@mail.com", true, false, null, "manager@mail.com", "manager@mail.com", "AQAAAAEAACcQAAAAEE8bEgmpXWv1a3QkdCxeZH7f+byvCZgUxk8OReJpW+j7ZHjIB/JmuQwxnYwj67cECw==", null, false, new Guid("9938d5c1-c9fa-4fe3-929c-00cc4a07a6fb"), null, false, "manager@mail.com" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "IsActive", "PhoneNumber", "PublicId", "UserId" },
                values: new object[] { 1, true, "08812345678", new Guid("e348896d-4a9d-404c-9135-bb9f6faf5e79"), 3 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 1, "London", "United Kingdom", "Less than a 5-minute walk from London Paddington Station and Hyde Park, this boutique hotel offers elegant rooms with free internet and satellite TV.", "The Chilworth London Paddington", true, 1, new Guid("171a4019-7d45-4c6d-a261-f00db7fa83b4"), 5, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 2, "Bansko", "Bulgaria", "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Conveniently situated in the Bansko part of Bansko, this property puts you close to attractions and interesting dining options. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.", "Kempinski Hotel Grand Arena Bansko", true, 1, new Guid("4ef091d3-c76c-4192-a6e1-f942ef9b78e3"), 4, "#96 Pirin Street" });

            migrationBuilder.InsertData(
                table: "HotelImageUrls",
                columns: new[] { "Id", "HotelId", "IsActive", "PublicId", "Url" },
                values: new object[,]
                {
                    { 1, 1, true, new Guid("aa391ed8-40f2-4b6f-a56c-0d7df41a9884"), "https://www.w3schools.com/html/pic_trulli.jpg" },
                    { 2, 2, true, new Guid("dfd5e0d6-6810-4dee-9534-e3a08b174a7b"), "https://pix8.agoda.net/hotelImages/182146/-1/112f1fa0f38baf10800569462deb46cd.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedsCount", "Description", "HotelId", "IsActive", "PricePerNight", "PublicId", "RoomSizeSquareMeters", "Title" },
                values: new object[,]
                {
                    { 1, 2, "A comfortable room for a relaxing stay.", 1, true, 75.50m, new Guid("9488d92c-1e7c-412e-a1c4-bbf75589d3ab"), 25, "Cozy Retreat" },
                    { 2, 1, "Luxurious suite with modern amenities.", 1, true, 120.75m, new Guid("1a6c9c67-a0ee-4ecf-aeac-8493fbb14cde"), 40, "Executive Suite" },
                    { 3, 3, "Spacious room suitable for families.", 2, true, 95.25m, new Guid("f7877525-7295-4797-b959-a21ab5651509"), 35, "Family Getaway" },
                    { 4, 1, "Enjoy breathtaking views of the ocean.", 2, true, 110.00m, new Guid("899c5472-086d-4ac4-9c6c-01063172dbfd"), 30, "Ocean View Paradise" },
                    { 5, 2, "Escape to a cozy lodge in the mountains.", 2, true, 85.80m, new Guid("c4a35862-d208-4c56-aa96-a4f78dcc3216"), 28, "Mountain Lodge" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AdultsCount", "CheckIn", "CheckOut", "HotelId", "IsActive", "PublicId", "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("29990315-0438-4194-9af1-bec4b63dee97"), 1, 1 },
                    { 2, 3, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("f3c9e591-e263-4ef2-9a01-6ee6eb04a1aa"), 2, 1 },
                    { 3, 1, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("41026578-ad0f-4d55-9ae7-7d9af446eb03"), 3, 2 },
                    { 4, 4, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("6217c6e5-4c6e-4451-a1b5-571e1c6d3ffc"), 4, 2 },
                    { 5, 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("07dfd588-b5d5-42e2-a932-f54880420ba8"), 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookingId", "Comment", "HotelId", "IsActive", "PublicId", "RatingScore", "ReviewedOn", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "I love this product! It's exactly what I needed.", 1, true, new Guid("b779720f-8d63-4526-8231-36bc20f02125"), 5, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excellent Product", 1 },
                    { 2, 2, "The product was okay, but could be better.", 1, true, new Guid("cad243ad-1741-4b03-b550-b024838cdbfb"), 3, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Average Experience", 1 },
                    { 3, 3, "I was very disappointed with this product.", 2, true, new Guid("873ab8cf-8d54-45b8-8905-bae31a402da4"), 1, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poor Quality", 2 },
                    { 4, 4, "I got my money's worth with this product.", 2, true, new Guid("6475ca60-f736-46ac-b2c2-7abbbc6985c3"), 4, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Value", 2 },
                    { 5, 5, "This product is amazing! Highly recommended.", 2, true, new Guid("d2597811-33b2-4717-bcca-c108b9c9a974"), 5, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best Product Ever", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelImageUrls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelImageUrls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
