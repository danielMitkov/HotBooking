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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PublicId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "a378097f-afaf-475e-bdae-af4793d7bec1", "guest@mail.com", false, false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEE9BMQbbKHPJTNpjKEZomWfLPWCmC9uTvfPNZYicHFIUFZ3woNibMK4AatxUkbbx3g==", null, false, new Guid("01ad4d28-b18b-4dfe-8304-fd268f8e201e"), null, false, "guest@mail.com" },
                    { 2, 0, "045f2f7f-cac7-4e01-8053-c24769779445", "two@mail.com", false, false, false, null, "two@mail.com", "two@mail.com", "AQAAAAEAACcQAAAAEP7nPLR57t7D6J6BjxxiSminBUuMDQg4J5ifWSrY14sq8AJ7F15EmO6zJOlsujsF5A==", null, false, new Guid("639927bc-b78f-48d8-9394-9f88d96db5a6"), null, false, "two@mail.com" },
                    { 3, 0, "16c6a7a9-d3b8-4ad2-9d3a-14b83e8730d1", "manager@mail.com", false, false, false, null, "manager@mail.com", "manager@mail.com", "AQAAAAEAACcQAAAAEEsH+ClzVWWQlT5hMJmHhppIgNIo+vNROr1Ls5yQav8kBKXVPIjVNVlk33T2+N+cdA==", null, false, new Guid("b10f8fda-63ae-4754-b0af-36649d48e1b8"), null, false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "IsActive", "Name", "PublicId", "SvgTag" },
                values: new object[,]
                {
                    { 1, true, "Spa", new Guid("f025f578-ab76-4791-afc7-95fd9885bcb8"), "" },
                    { 2, true, "Parking", new Guid("f8eb22f4-570c-4320-9d7e-898a53ed4ab1"), "" },
                    { 3, true, "Free WiFi", new Guid("d7849412-023b-4d7b-b539-e0cb3a8d0e13"), "" },
                    { 4, true, "Restaurant", new Guid("5dd10fd2-2386-4f82-9232-eb0d4e8083a3"), "" },
                    { 5, true, "Fitness center", new Guid("accbea50-b1a9-4b95-a759-2b873e29587b"), "" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "IsActive", "PhoneNumber", "PublicId", "UserId" },
                values: new object[] { 1, true, "08812345678", new Guid("531c4d5b-dc33-4908-8453-a5935185a6fa"), 3 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 1, "London", "United Kingdom", "Less than a 5-minute walk from London Paddington Station and Hyde Park, this boutique hotel offers elegant rooms with free internet and satellite TV.", "The Chilworth London Paddington", true, 1, new Guid("4c8182b4-1024-4982-b747-4226c32b2526"), 5, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 2, "Bansko", "Bulgaria", "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Conveniently situated in the Bansko part of Bansko, this property puts you close to attractions and interesting dining options. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.", "Kempinski Hotel Grand Arena Bansko", true, 1, new Guid("e124b718-8e06-466f-9ad3-b3c709dac5a8"), 4, "#96 Pirin Street" });

            migrationBuilder.InsertData(
                table: "HotelImageUrls",
                columns: new[] { "Id", "HotelId", "IsActive", "PublicId", "Url" },
                values: new object[,]
                {
                    { 1, 1, true, new Guid("900c8995-4f25-46bc-b49c-673b632fe70e"), "https://www.w3schools.com/html/pic_trulli.jpg" },
                    { 2, 2, true, new Guid("7315fef2-e31e-4eb0-a9e4-15cce6a1d6bb"), "https://pix8.agoda.net/hotelImages/182146/-1/112f1fa0f38baf10800569462deb46cd.jpg" }
                });

            migrationBuilder.InsertData(
                table: "HotelsFacilities",
                columns: new[] { "FacilityId", "HotelId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedsCount", "Description", "HotelId", "IsActive", "PricePerNight", "PublicId", "RoomSizeSquareMeters", "Title" },
                values: new object[,]
                {
                    { 1, 2, "A comfortable room for a relaxing stay.", 1, true, 75.50m, new Guid("2b859437-b1b4-4ffc-8ca2-1a1ce19a24c1"), 25, "Cozy Retreat" },
                    { 2, 1, "Luxurious suite with modern amenities.", 1, true, 120.75m, new Guid("6a68b40f-c538-43b6-bcfa-179e3e1e1b2f"), 40, "Executive Suite" },
                    { 3, 3, "Spacious room suitable for families.", 2, true, 95.25m, new Guid("a31ed7c2-aa0a-49f3-aafb-4d1de4b55ee1"), 35, "Family Getaway" },
                    { 4, 1, "Enjoy breathtaking views of the ocean.", 2, true, 110.00m, new Guid("cef829ab-ce12-48df-95a5-a562a7f7a14f"), 30, "Ocean View Paradise" },
                    { 5, 2, "Escape to a cozy lodge in the mountains.", 2, true, 85.80m, new Guid("e3676883-75fb-4173-9c49-a3268447443f"), 28, "Mountain Lodge" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AdultsCount", "CheckIn", "CheckOut", "HotelId", "IsActive", "PublicId", "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("b08ba484-87b0-4729-bb94-6601b41efb41"), 1, 1 },
                    { 2, 3, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("5c2cff67-3a35-47f3-bb1d-f7857b43ccfe"), 2, 1 },
                    { 3, 1, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("23948e7a-1398-4853-aeb8-efb3730a57b1"), 3, 2 },
                    { 4, 4, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("d6c008d1-f227-4168-8628-5301079c8fb1"), 4, 2 },
                    { 5, 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("4246cd1a-5c81-4162-b79f-b0c13891a0f1"), 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookingId", "Comment", "HotelId", "IsActive", "PublicId", "RatingScore", "ReviewedOn", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "I love this product! It's exactly what I needed.", 1, true, new Guid("e92bd9db-55d5-4aa8-9284-94f0e0eee7f6"), 5, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excellent Product", 1 },
                    { 2, 2, "The product was okay, but could be better.", 1, true, new Guid("d9e45511-61f6-4dbf-b2eb-8f8715c6526d"), 3, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Average Experience", 1 },
                    { 3, 3, "I was very disappointed with this product.", 2, true, new Guid("013fd383-4696-41b9-9138-68f198e255f1"), 1, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poor Quality", 2 },
                    { 4, 4, "I got my money's worth with this product.", 2, true, new Guid("814ca1ff-80de-4ff7-b964-70942ae9b748"), 4, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Value", 2 },
                    { 5, 5, "This product is amazing! Highly recommended.", 2, true, new Guid("e792368f-be0e-47f8-bc31-8be75011a959"), 5, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best Product Ever", 2 }
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
                table: "HotelsFacilities",
                keyColumns: new[] { "FacilityId", "HotelId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "HotelsFacilities",
                keyColumns: new[] { "FacilityId", "HotelId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "HotelsFacilities",
                keyColumns: new[] { "FacilityId", "HotelId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "HotelsFacilities",
                keyColumns: new[] { "FacilityId", "HotelId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "HotelsFacilities",
                keyColumns: new[] { "FacilityId", "HotelId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "HotelsFacilities",
                keyColumns: new[] { "FacilityId", "HotelId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "HotelsFacilities",
                keyColumns: new[] { "FacilityId", "HotelId" },
                keyValues: new object[] { 4, 2 });

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
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Facilities",
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
