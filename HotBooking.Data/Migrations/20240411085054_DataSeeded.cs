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
                    { 1, 0, "3f548c81-df01-4fdf-b4f6-2ef53e7dea44", "guest@mail.com", false, false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEGnAc4itFkwd17qkMr8q+htrNp5dKaxH2j9JeTuPJmxObhDNb1vwRZmSGw+v5EBaxg==", null, false, new Guid("d79b26ee-7bc9-4483-a82b-00f6d8456cba"), "0902dcbc-3dd3-4c81-b6ba-19b0633ca756", false, "guest@mail.com" },
                    { 2, 0, "c4ee40cb-5207-4475-be9a-ac95cd0727ee", "two@mail.com", false, false, false, null, "two@mail.com", "two@mail.com", "AQAAAAEAACcQAAAAEJ+YzOpGV50vYPF7dnPEgZ9DX5W9rf+yEKWOsl2SiSgOy/Swrc/29jZnCdRsTmYeLA==", null, false, new Guid("0bfd6c11-58d3-47f5-9134-08fe42800584"), "732fa801-5c6a-4bb5-b679-efe78d9bc787", false, "two@mail.com" },
                    { 3, 0, "b4bc5b46-9e3e-4e2e-a8a9-394631f74fe8", "manager@mail.com", false, false, false, null, "manager@mail.com", "manager@mail.com", "AQAAAAEAACcQAAAAEF/tYRvXebXkiX2RTXq4+5owMHunaTQNPcF28IUxnjm9FHFGJmUmOMm+3mdHp2pXfw==", null, false, new Guid("e163f2e0-90e4-4603-b321-269c0e1c20f1"), "92a738c9-66fc-4e0f-aa81-944989adfb55", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "IsActive", "Name", "PublicId", "SvgTag" },
                values: new object[,]
                {
                    { 1, true, "Spa", new Guid("cc8b43ed-8e97-4305-a338-79d9a30658f3"), "" },
                    { 2, true, "Parking", new Guid("18d03b14-87f9-497b-a3d7-9f954a81c2b7"), "" },
                    { 3, true, "WiFi", new Guid("ba9220e6-2299-4277-b4a7-e32782e1ea0e"), "" },
                    { 4, true, "Restaurant", new Guid("798af0dd-5534-4bac-82a4-7ebe4ed01d59"), "" },
                    { 5, true, "Fitness", new Guid("5459a8a4-ae04-428c-87aa-21e5d0553ce8"), "" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "IsActive", "Name", "PublicId", "SvgTag" },
                values: new object[,]
                {
                    { 1, true, "TV", new Guid("69c128a9-8114-4fd8-818b-be93482fd4c5"), "" },
                    { 2, true, "Refrigerator", new Guid("c27a83a7-8d51-4f46-80fc-b513599f1f61"), "" },
                    { 3, true, "Hairdryer", new Guid("bbf59675-0cbb-422f-8deb-84ed6b7d4a4e"), "" },
                    { 4, true, "Towels", new Guid("f2bfd7b2-1bf2-4ee1-b140-9fda55e4b095"), "" },
                    { 5, true, "Slippers", new Guid("15e47ba9-e997-4b3e-9c74-bf309b12c6e3"), "" },
                    { 6, true, "Bathtub", new Guid("4fed8d7c-fc8d-41e0-b68d-b05def392708"), "" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "IsActive", "PhoneNumber", "PublicId", "UserId" },
                values: new object[] { 1, true, "08812345678", new Guid("349c1444-6f5a-4c24-9aba-416139f4c564"), 3 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 1, "London", "United Kingdom", "Less than a 5-minute walk from London Paddington Station and Hyde Park, this boutique hotel offers elegant rooms with free internet and satellite TV.", "The Chilworth London Paddington", true, 1, new Guid("779235b2-93c2-4d70-8d59-4cf16b29b3a5"), 5, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 2, "Bansko", "Bulgaria", "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Conveniently situated in the Bansko part of Bansko, this property puts you close to attractions and interesting dining options. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.", "Kempinski Hotel Grand Arena Bansko", true, 1, new Guid("dd06d9d2-cb92-439c-8f9b-ca3f1d72ff2c"), 4, "#96 Pirin Street" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 3, "London", "United Kingdom", "Welcoming guests since 1909, the Strand Palace Hotel is located in London’s West End within just 2297 feet of the Adelphi and the Vaudeville theaters.", "Strand Palace Hotel", true, 1, new Guid("41df433c-62cb-4cc2-a611-492db4fad37e"), 4, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "HotelImageUrls",
                columns: new[] { "Id", "HotelId", "IsActive", "PublicId", "Url" },
                values: new object[,]
                {
                    { 1, 1, true, new Guid("87260c1b-7020-4cef-8f9c-9d471ea3bc49"), "https://www.w3schools.com/html/pic_trulli.jpg" },
                    { 2, 1, true, new Guid("100fbd6d-e49b-4608-b8ec-c53de9a1b23e"), "https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2" },
                    { 3, 2, true, new Guid("8f3caf0e-bece-41d3-8b8f-54c81c87aac8"), "https://pix8.agoda.net/hotelImages/182146/-1/112f1fa0f38baf10800569462deb46cd.jpg" },
                    { 4, 3, true, new Guid("a7209bb4-0b65-4cf7-813a-73464162bc52"), "https://cf.bstatic.com/xdata/images/hotel/max1024x768/260560238.jpg?k=1d14eb111d6a58d373d4139792c8c0545ec7014527bab0c00a98945e8df46879&o=&hp=1" }
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
                    { 1, 2, "A comfortable room for a relaxing stay.", 1, true, 75.50m, new Guid("2868bbb7-bcf6-412c-9243-bceda038a62b"), 25, "Cozy Retreat" },
                    { 2, 1, "Luxurious suite with modern amenities.", 1, true, 120.75m, new Guid("13b72b99-5b94-4d8f-88f4-a73ea4e40195"), 40, "Executive Suite" },
                    { 3, 3, "Spacious room suitable for families.", 2, true, 95.25m, new Guid("a5d3fb32-b426-49bd-aee8-07ed93ce0668"), 35, "Family Getaway" },
                    { 4, 1, "Enjoy breathtaking views of the ocean.", 2, true, 110.00m, new Guid("4e7da082-a8bb-4d97-93eb-aa42f80f8671"), 30, "Ocean View Paradise" },
                    { 5, 2, "Escape to a cozy lodge in the mountains.", 2, true, 85.80m, new Guid("742e7bee-c8d1-4cf7-9af2-9f53034d2144"), 28, "Mountain Lodge" },
                    { 6, 3, "Luxurious room with a panoramic view.", 3, true, 250.00m, new Guid("9cd344c0-a451-4226-97e1-49ca6173bf82"), 50, "Luxury Suite" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AdultsCount", "CheckIn", "CheckOut", "HotelId", "IsActive", "PublicId", "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("79d4e688-bd40-47aa-ae69-47e7b4b2ae37"), 1, 1 },
                    { 2, 3, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("a325ca71-4183-4cd0-a54d-7da9aee5c33f"), 2, 1 },
                    { 3, 1, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("558bd04c-12da-42e4-a79a-c3256fbcdcfd"), 3, 2 },
                    { 4, 4, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("fcaae798-e4c3-493d-a707-cc8dacdc6bcf"), 4, 2 },
                    { 5, 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("2198b34b-9125-4853-9d0e-11fddec44ffe"), 5, 2 },
                    { 6, 3, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, new Guid("3edab4ad-2dbc-4b7a-a85f-baab38c957b7"), 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoomImageUrls",
                columns: new[] { "Id", "IsActive", "PublicId", "RoomId", "Url" },
                values: new object[,]
                {
                    { 1, true, new Guid("b053a64c-250c-45ea-b4fd-9e38f3d58e99"), 3, "https://img.freepik.com/free-photo/luxury-classic-modern-bedroom-suite-hotel_105762-1787.jpg?size=626&ext=jpg&ga=GA1.1.2008272138.1712707200&semt=ais" },
                    { 2, true, new Guid("b93dbc91-72ad-4050-8468-600aa21d367b"), 3, "https://images.trvl-media.com/lodging/96000000/95770000/95768000/95767989/5674f5e3.jpg?impolicy=resizecrop&rw=1200&ra=fit" },
                    { 3, true, new Guid("545065c0-ff8a-4c12-b028-ca91dd9e4f78"), 5, "https://st.depositphotos.com/1007581/1700/i/600/depositphotos_17000573-stock-photo-mountain-resort-house.jpg" },
                    { 4, true, new Guid("0d791dc3-d20c-435d-8a17-e960584481dc"), 5, "https://whiteface.com/wp-content/uploads/sites/3/2023/08/Cobble-Mountain-Lodge-Cabin-Interior-768x511-1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "RoomsFeatures",
                columns: new[] { "FeatureId", "RoomId" },
                values: new object[,]
                {
                    { 5, 3 },
                    { 6, 3 },
                    { 1, 5 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookingId", "Comment", "HotelId", "IsActive", "PublicId", "RatingScore", "ReviewedOn", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "I love this product! It's exactly what I needed.", 1, true, new Guid("0f1641ef-24a2-4fe3-90f0-aaf6ff398648"), 5m, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excellent Product", 1 },
                    { 2, 2, "The product was okay, but could be better.", 1, true, new Guid("e26e6d26-8f82-4e21-98af-ddafa18deab3"), 3m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Average Experience", 1 },
                    { 3, 3, "I was very disappointed with this product.", 2, true, new Guid("4c462ea4-a925-432d-9bf5-a67e220c0d91"), 1m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poor Quality", 2 },
                    { 4, 4, "I got my money's worth with this product.", 2, true, new Guid("8c5d8f78-3a87-4459-9970-e7e2d4328d05"), 4m, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Value", 2 },
                    { 5, 5, "This product is amazing! Highly recommended.", 2, true, new Guid("881b0c7d-e059-4ebf-b1aa-52da0dada58c"), 5m, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best Product Ever", 2 },
                    { 6, 6, "Great room and service overall!", 3, true, new Guid("8728510f-5d9b-450e-b9c2-964044f96b5d"), 4.5m, new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Satisfactory", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4);

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
                table: "HotelImageUrls",
                keyColumn: "Id",
                keyValue: 4);

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
                table: "RoomImageUrls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomImageUrls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomImageUrls",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomImageUrls",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomsFeatures",
                keyColumns: new[] { "FeatureId", "RoomId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "RoomsFeatures",
                keyColumns: new[] { "FeatureId", "RoomId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "RoomsFeatures",
                keyColumns: new[] { "FeatureId", "RoomId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "RoomsFeatures",
                keyColumns: new[] { "FeatureId", "RoomId" },
                keyValues: new object[] { 2, 5 });

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
                table: "Features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 6);

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
        }
    }
}
