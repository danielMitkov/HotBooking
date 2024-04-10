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
                    { 1, 0, "21af0cf5-3fb0-4251-8be0-ade4580e80a4", "guest@mail.com", false, false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAELLAa0kRu6XFejM7+8Gc0nYdQWns4U8aDISn5TQICPk/voSqBq7KYmPFvLS6jb4csg==", null, false, new Guid("70f28475-14a6-4e75-aa86-d74b4cb49f2f"), null, false, "guest@mail.com" },
                    { 2, 0, "644d7295-6727-4679-a797-a0e80638639d", "two@mail.com", false, false, false, null, "two@mail.com", "two@mail.com", "AQAAAAEAACcQAAAAEC9Y6LXjzm6ssGhYo7KTvri9gZ8YAgcQTq8de3m7jcp2OSQS16VGdB5IEyIg8ti/rA==", null, false, new Guid("bf3134a9-66cb-4d8b-9706-3917cb3553bb"), null, false, "two@mail.com" },
                    { 3, 0, "caec14c5-c2e8-4918-9343-b76a9d8275ff", "manager@mail.com", false, false, false, null, "manager@mail.com", "manager@mail.com", "AQAAAAEAACcQAAAAEKgsoNpbLWou3xtPmPpmaw+oul4FylmrP+ZOkk1FhcLRMlRaJa3eFZpV8oipq6jUpg==", null, false, new Guid("c5a5c71f-fcfd-4480-8527-ac4ae3cfc5b4"), null, false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "IsActive", "Name", "PublicId", "SvgTag" },
                values: new object[,]
                {
                    { 1, true, "Spa", new Guid("90620688-bbc1-4074-8271-131fef7f962d"), "" },
                    { 2, true, "Parking", new Guid("c34fa9d0-0465-477d-8fe3-a6272b79f368"), "" },
                    { 3, true, "WiFi", new Guid("94fc2542-f882-4654-85da-e40c6803cdc2"), "" },
                    { 4, true, "Restaurant", new Guid("decc6830-41d5-4811-811d-ab7ea0fddb54"), "" },
                    { 5, true, "Fitness", new Guid("db38eb92-b115-4aac-bac0-70dc4206f3a0"), "" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "IsActive", "Name", "PublicId", "SvgTag" },
                values: new object[,]
                {
                    { 1, true, "TV", new Guid("746510b3-e883-469e-8066-952b52a772c6"), "" },
                    { 2, true, "Refrigerator", new Guid("7e1d4615-90cf-4afa-b22a-73a300ce2d9b"), "" },
                    { 3, true, "Hairdryer", new Guid("04f8bb85-9124-4d3d-b772-fd696b7cc4e8"), "" },
                    { 4, true, "Towels", new Guid("74bbbd57-42a3-4a10-b29c-1af7ed2672f4"), "" },
                    { 5, true, "Slippers", new Guid("81b5ff60-6fb1-4124-8434-d6aef69efb3a"), "" },
                    { 6, true, "Bathtub", new Guid("29c9dede-4b99-4dbd-a921-c46ef7c3dd99"), "" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "IsActive", "PhoneNumber", "PublicId", "UserId" },
                values: new object[] { 1, true, "08812345678", new Guid("ae83eaf2-d337-42f0-bc04-eb213d4767db"), 3 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 1, "London", "United Kingdom", "Less than a 5-minute walk from London Paddington Station and Hyde Park, this boutique hotel offers elegant rooms with free internet and satellite TV.", "The Chilworth London Paddington", true, 1, new Guid("39bb8873-8c1c-4eb6-b0ea-1ca7d9c47a68"), 5, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 2, "Bansko", "Bulgaria", "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Conveniently situated in the Bansko part of Bansko, this property puts you close to attractions and interesting dining options. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.", "Kempinski Hotel Grand Arena Bansko", true, 1, new Guid("9b10e59f-eca1-4a1b-af2a-edf065e6207a"), 4, "#96 Pirin Street" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 3, "London", "United Kingdom", "Welcoming guests since 1909, the Strand Palace Hotel is located in London’s West End within just 2297 feet of the Adelphi and the Vaudeville theaters.", "Strand Palace Hotel", true, 1, new Guid("d8659e6e-f7ea-45b2-89fe-137f7f384b19"), 4, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "HotelImageUrls",
                columns: new[] { "Id", "HotelId", "IsActive", "PublicId", "Url" },
                values: new object[,]
                {
                    { 1, 1, true, new Guid("5f7ef972-9824-46ae-b1b9-19f17b4270c1"), "https://www.w3schools.com/html/pic_trulli.jpg" },
                    { 2, 1, true, new Guid("747abad5-7ae1-445e-9c75-16658e9c1270"), "https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2" },
                    { 3, 2, true, new Guid("093f8cdd-aabe-480d-a6b9-0a0c3e4dcb02"), "https://pix8.agoda.net/hotelImages/182146/-1/112f1fa0f38baf10800569462deb46cd.jpg" },
                    { 4, 3, true, new Guid("bd57b735-eafd-4583-a33d-3482dbc22e36"), "https://cf.bstatic.com/xdata/images/hotel/max1024x768/260560238.jpg?k=1d14eb111d6a58d373d4139792c8c0545ec7014527bab0c00a98945e8df46879&o=&hp=1" }
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
                    { 1, 2, "A comfortable room for a relaxing stay.", 1, true, 75.50m, new Guid("964713d2-79c9-4527-8a63-20a70fecc865"), 25, "Cozy Retreat" },
                    { 2, 1, "Luxurious suite with modern amenities.", 1, true, 120.75m, new Guid("4a1baf6b-569a-441c-a0ce-afe3b9304608"), 40, "Executive Suite" },
                    { 3, 3, "Spacious room suitable for families.", 2, true, 95.25m, new Guid("5694eeec-4b8c-4c6f-908d-e0e433291c7e"), 35, "Family Getaway" },
                    { 4, 1, "Enjoy breathtaking views of the ocean.", 2, true, 110.00m, new Guid("18bd4d6c-f130-46c8-8a0f-f3797312ed6a"), 30, "Ocean View Paradise" },
                    { 5, 2, "Escape to a cozy lodge in the mountains.", 2, true, 85.80m, new Guid("e7ea351b-3659-4df7-a3d9-8c6f37227314"), 28, "Mountain Lodge" },
                    { 6, 3, "Luxurious room with a panoramic view.", 3, true, 250.00m, new Guid("21a19247-04d8-4487-bd01-5b4cb03adee2"), 50, "Luxury Suite" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AdultsCount", "CheckIn", "CheckOut", "HotelId", "IsActive", "PublicId", "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("553d182d-e9cd-4bad-baf5-57a811f9ab54"), 1, 1 },
                    { 2, 3, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new Guid("8249b34a-1495-4a20-98aa-e6b810b284bd"), 2, 1 },
                    { 3, 1, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("80627a12-2a3d-4bec-8776-d7e8ac2f7dba"), 3, 2 },
                    { 4, 4, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("eeaa9011-718e-4139-ac07-c05728d5ee31"), 4, 2 },
                    { 5, 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new Guid("b328f0b3-205c-4c71-a3aa-4079088ca314"), 5, 2 },
                    { 6, 3, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, new Guid("8ca62b69-83b6-4ff7-9c99-724d297ad478"), 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoomImageUrls",
                columns: new[] { "Id", "IsActive", "PublicId", "RoomId", "Url" },
                values: new object[,]
                {
                    { 1, true, new Guid("07d483af-0a92-4f9c-b46d-f7aff60a3e41"), 3, "https://img.freepik.com/free-photo/luxury-classic-modern-bedroom-suite-hotel_105762-1787.jpg?size=626&ext=jpg&ga=GA1.1.2008272138.1712707200&semt=ais" },
                    { 2, true, new Guid("cfd01ba0-3970-4772-bbdd-17d9d2b7c03f"), 3, "https://images.trvl-media.com/lodging/96000000/95770000/95768000/95767989/5674f5e3.jpg?impolicy=resizecrop&rw=1200&ra=fit" },
                    { 3, true, new Guid("a5edde04-c59f-4084-ac97-15d8ce0643fb"), 5, "https://st.depositphotos.com/1007581/1700/i/600/depositphotos_17000573-stock-photo-mountain-resort-house.jpg" },
                    { 4, true, new Guid("c46eaec1-5455-4ec4-9484-4d1f4991f032"), 5, "https://whiteface.com/wp-content/uploads/sites/3/2023/08/Cobble-Mountain-Lodge-Cabin-Interior-768x511-1.jpg" }
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
                    { 1, 1, "I love this product! It's exactly what I needed.", 1, true, new Guid("da080a4b-d9f0-411c-921e-8bfed97580a8"), 5m, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excellent Product", 1 },
                    { 2, 2, "The product was okay, but could be better.", 1, true, new Guid("39c2f952-4347-4842-bd62-6e56a7714c5a"), 3m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Average Experience", 1 },
                    { 3, 3, "I was very disappointed with this product.", 2, true, new Guid("60d6f693-ee97-4804-a8b0-ffdef450d2df"), 1m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poor Quality", 2 },
                    { 4, 4, "I got my money's worth with this product.", 2, true, new Guid("e8244d3d-04a2-45c2-a260-0d43273d1ff0"), 4m, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Value", 2 },
                    { 5, 5, "This product is amazing! Highly recommended.", 2, true, new Guid("2c8be67b-ef71-4861-a1e6-1e294c42de7c"), 5m, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best Product Ever", 2 },
                    { 6, 6, "Great room and service overall!", 3, true, new Guid("a37535e6-3c84-42f9-9c51-e8a5b6c72694"), 4.5m, new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Satisfactory", 3 }
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
