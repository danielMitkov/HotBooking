using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotBooking.Data.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RatingScore",
                table: "Reviews",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PublicId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "2dbc401f-3534-48f0-9935-26186ab4a8e2", "guest@mail.com", false, false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEBwdWIrkc0VeUVYy8z1dX0JwrvCT3YKOMo55pRrvRheBu6SHv5wg4D2wvGtaBSZtaw==", null, false, new Guid("1d1d65f8-045b-42f0-8250-84b3e99a52bf"), null, false, "guest@mail.com" },
                    { 2, 0, "8b613347-29f4-442d-9e80-3ebaceeafded", "two@mail.com", false, false, false, null, "two@mail.com", "two@mail.com", "AQAAAAEAACcQAAAAEGJL3xT3HbpqL7UP6j5PS0B4kgh0T3ZM1HhsaR9tQnbry6QW8VmsUeRO7cjI8Yzs5g==", null, false, new Guid("a7a7ef8a-b7a8-4666-8531-1a055549a966"), null, false, "two@mail.com" },
                    { 3, 0, "57774020-d008-45ac-87e8-86940ac3a6d2", "manager@mail.com", false, false, false, null, "manager@mail.com", "manager@mail.com", "AQAAAAEAACcQAAAAEFcxYcRWDTfCKjJoetsUURHMqKPWNRr3n5UowONTdDo09o6dvRPvV0ZzN+lRsVAwuA==", null, false, new Guid("3257d0d3-0edc-48b9-a6b8-14abbf63b911"), null, false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "IsActive", "Name", "PublicId", "SvgTag" },
                values: new object[,]
                {
                    { 1, true, "Spa", new Guid("758cfaee-4fb0-4168-bf3d-2ea25be57b98"), "" },
                    { 2, true, "Parking", new Guid("c9b9ca82-db23-4b4a-898f-f7711c3ea90a"), "" },
                    { 3, true, "WiFi", new Guid("0f4edc7f-a1bf-4425-b9f0-93a2cc023876"), "" },
                    { 4, true, "Restaurant", new Guid("bb6fcb42-3cfe-46c2-80c4-388038fce88d"), "" },
                    { 5, true, "Fitness", new Guid("769a1864-5e7c-49c9-8a84-b23bd5050659"), "" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "IsActive", "PhoneNumber", "PublicId", "UserId" },
                values: new object[] { 1, true, "08812345678", new Guid("a1bb9592-1b0d-43bc-81ca-05e770e7db8a"), 3 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 1, "London", "United Kingdom", "Less than a 5-minute walk from London Paddington Station and Hyde Park, this boutique hotel offers elegant rooms with free internet and satellite TV.", "The Chilworth London Paddington", true, 1, new Guid("85c2b324-8da1-4993-b556-7a526cba8d4e"), 5, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 2, "Bansko", "Bulgaria", "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Conveniently situated in the Bansko part of Bansko, this property puts you close to attractions and interesting dining options. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.", "Kempinski Hotel Grand Arena Bansko", true, 1, new Guid("69b9111a-0709-4c3d-8efb-aca1152c25ca"), 4, "#96 Pirin Street" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 3, "London", "United Kingdom", "Welcoming guests since 1909, the Strand Palace Hotel is located in London’s West End within just 2297 feet of the Adelphi and the Vaudeville theaters.", "Strand Palace Hotel", true, 1, new Guid("3233d5b7-5624-404d-a581-0bd5d0d86ea6"), 4, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "HotelImageUrls",
                columns: new[] { "Id", "HotelId", "IsActive", "PublicId", "Url" },
                values: new object[,]
                {
                    { 1, 1, true, new Guid("2fc03ead-386c-4ef1-8912-f3aa1f0d289e"), "https://www.w3schools.com/html/pic_trulli.jpg" },
                    { 2, 2, true, new Guid("b4b542de-b4ae-4f2a-ba7a-e03b1d3e6750"), "https://pix8.agoda.net/hotelImages/182146/-1/112f1fa0f38baf10800569462deb46cd.jpg" },
                    { 3, 3, true, new Guid("c7966147-fa29-4128-9ec6-69b1370eca73"), "https://cf.bstatic.com/xdata/images/hotel/max1024x768/260560238.jpg?k=1d14eb111d6a58d373d4139792c8c0545ec7014527bab0c00a98945e8df46879&o=&hp=1" }
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
                    { 4, 2 },
                    { 2, 3 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedsCount", "Description", "HotelId", "IsActive", "PricePerNight", "PublicId", "RoomSizeSquareMeters", "Title" },
                values: new object[,]
                {
                    { 1, 2, "A comfortable room for a relaxing stay.", 1, true, 75.50m, new Guid("a4b7f3c0-509a-4322-9f7b-ad27f2542b61"), 25, "Cozy Retreat" },
                    { 2, 1, "Luxurious suite with modern amenities.", 1, true, 120.75m, new Guid("ad9fc692-b274-4062-82a4-4f7f8838ae50"), 40, "Executive Suite" },
                    { 3, 3, "Spacious room suitable for families.", 2, true, 95.25m, new Guid("ea28e856-c46d-420c-a232-0ee5f965bef1"), 35, "Family Getaway" },
                    { 4, 1, "Enjoy breathtaking views of the ocean.", 2, true, 110.00m, new Guid("b5f60b6d-17ab-45c9-a451-2a1c615662ee"), 30, "Ocean View Paradise" },
                    { 5, 2, "Escape to a cozy lodge in the mountains.", 2, true, 85.80m, new Guid("73bcad48-004d-4b11-aaca-16fcb93fe35e"), 28, "Mountain Lodge" },
                    { 6, 3, "Luxurious room with a panoramic view.", 3, true, 250.00m, new Guid("c0bf47ac-d9a9-45a5-9853-470866cd585f"), 50, "Luxury Suite" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AdultsCount", "CheckIn", "CheckOut", "HotelId", "IsActive", "PublicId", "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("56310414-420a-48ba-abf1-2b47729eca70"), 1, 1 },
                    { 2, 3, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("1563c027-e405-4cc1-89ec-e72ddc5725dc"), 2, 1 },
                    { 3, 1, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("2498284a-2835-4009-96ae-152becb5cf43"), 3, 2 },
                    { 4, 4, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("6ceb67a5-ce24-429d-abb7-69670ba96c5c"), 4, 2 },
                    { 5, 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("536ad6d2-af47-42c2-8891-26b0da9dd599"), 5, 2 },
                    { 6, 3, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, new Guid("a1e4c88c-a92c-4138-8ec9-b37fac319e73"), 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookingId", "Comment", "HotelId", "IsActive", "PublicId", "RatingScore", "ReviewedOn", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "I love this product! It's exactly what I needed.", 1, true, new Guid("dab5b49a-f5fd-4044-ab52-c5d24fd63b0e"), 5m, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excellent Product", 1 },
                    { 2, 2, "The product was okay, but could be better.", 1, true, new Guid("272c24c0-c8f4-4c4f-ba14-77dd6a50fae4"), 3m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Average Experience", 1 },
                    { 3, 3, "I was very disappointed with this product.", 2, true, new Guid("2c2ffa58-fa6b-4f98-a9f2-c84653c1a051"), 1m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poor Quality", 2 },
                    { 4, 4, "I got my money's worth with this product.", 2, true, new Guid("aa083d76-3bad-467e-8284-a8518195eb62"), 4m, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Value", 2 },
                    { 5, 5, "This product is amazing! Highly recommended.", 2, true, new Guid("555d43d3-0aab-4aa5-a48a-444e3c220ac9"), 5m, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best Product Ever", 2 },
                    { 6, 6, "Great room and service overall!", 3, true, new Guid("26df34f5-5f71-4817-9d2b-20d2dfe1b29b"), 4.5m, new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Satisfactory", 3 }
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
                table: "HotelImageUrls",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "HotelsFacilities",
                keyColumns: new[] { "FacilityId", "HotelId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "HotelsFacilities",
                keyColumns: new[] { "FacilityId", "HotelId" },
                keyValues: new object[] { 3, 3 });

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
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

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
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

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
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "RatingScore",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
