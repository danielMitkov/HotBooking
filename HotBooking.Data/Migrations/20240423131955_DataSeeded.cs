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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "1355be4d-cf39-4890-a52d-9f71f81edc8c", new DateTime(2024, 4, 23, 16, 19, 54, 985, DateTimeKind.Local).AddTicks(3281), "guest@mail.com", false, true, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEGrlANWq2eFcCrgZKwkXqaUkJK97pIKUlS+I5Io/5INCnvMyywJsV/T97Kt/P8d76g==", null, false, "db8f4118-4cc2-46dc-a5aa-f2a8c76c283e", false, "guest@mail.com" },
                    { 2, 0, "6492eedf-dc19-4c73-83a2-8b0b19c56ffa", new DateTime(2024, 4, 23, 16, 19, 54, 986, DateTimeKind.Local).AddTicks(4501), "two@mail.com", false, true, false, null, "two@mail.com", "two@mail.com", "AQAAAAEAACcQAAAAEAD3G3aYxyNrBZVysGEr4SeXslNCK0k5ZbKoBtWPPIv8PwC/+NkmwaYZyFFiPqG42w==", null, false, "35cc41e6-30eb-4131-a3e5-214c628a45bc", false, "two@mail.com" },
                    { 3, 0, "5dffdb66-294c-4ecb-a4e1-939c86c3602a", new DateTime(2024, 4, 23, 16, 19, 54, 987, DateTimeKind.Local).AddTicks(5018), "manager@mail.com", false, true, false, null, "manager@mail.com", "manager@mail.com", "AQAAAAEAACcQAAAAEE36Yq011BzwLuK+TuRIC/uzCOEoOKLyVYFntT/AMowndzMh3Vpty35rsSvoqRZP8A==", null, false, "68c75553-2311-4508-8f97-57b35c275756", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CreatedOn", "IsActive", "Name", "PublicId", "SvgTag" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(5891), true, "Spa", new Guid("bd77461c-f3bc-4fa9-97af-4b865e5ae1ad"), "" },
                    { 2, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(5902), true, "Parking", new Guid("e7a6ad8e-f8c1-4a28-9c9d-6b741f8abb21"), "" },
                    { 3, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(5908), true, "WiFi", new Guid("d443a26f-1b2c-4da6-b0e1-08668fed10bb"), "" },
                    { 4, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(5915), true, "Restaurant", new Guid("dd36efb6-0080-4fe7-b7d3-099c49bbfab3"), "" },
                    { 5, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(5919), true, "Fitness", new Guid("73324070-64ea-40b7-aadb-dd37821b1f8c"), "" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "CreatedOn", "IsActive", "Name", "PublicId", "SvgTag" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6046), true, "TV", new Guid("b2f23b10-6219-46c4-9e05-4a7f2022d91e"), "" },
                    { 2, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6055), true, "Refrigerator", new Guid("9f4f658a-6d84-46b4-8d52-6db5238b760b"), "" },
                    { 3, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6059), true, "Hairdryer", new Guid("41fd8a74-4f85-4fe4-aa02-f1cd4b922e53"), "" },
                    { 4, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6063), true, "Towels", new Guid("41233a4d-2b06-4a17-a03e-d83b8afe6b58"), "" },
                    { 5, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6069), true, "Slippers", new Guid("8b5dbbe9-a33e-454a-b604-34a55bffe057"), "" },
                    { 6, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6074), true, "Bathtub", new Guid("1b9d6d74-c620-4895-9030-52a6a75d6e80"), "" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "CompanyName", "Department", "IsActive", "PhoneNumber", "PublicId", "UserId" },
                values: new object[] { 1, "Test Company Name", "Test Department", true, "08888888888", new Guid("1a7399f1-9439-433b-af61-0a114da3f704"), 3 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 1, "London", "United Kingdom", "Less than a 5-minute walk from London Paddington Station and Hyde Park, this boutique hotel offers elegant rooms with free internet and satellite TV.", "The Chilworth London Paddington", true, 1, new Guid("fe10a78f-423b-4e19-8c79-88cef52c46bd"), 5, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 2, "Bansko", "Bulgaria", "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Conveniently situated in the Bansko part of Bansko, this property puts you close to attractions and interesting dining options. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.", "Kempinski Hotel Grand Arena Bansko", true, 1, new Guid("e8efdf7b-5e4c-48ff-8417-ff57968f8cb8"), 4, "#96 Pirin Street" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CityName", "CountryName", "Description", "HotelName", "IsActive", "ManagerId", "PublicId", "StarRating", "StreetAddress" },
                values: new object[] { 3, "London", "United Kingdom", "Welcoming guests since 1909, the Strand Palace Hotel is located in London’s West End within just 2297 feet of the Adelphi and the Vaudeville theaters.", "Strand Palace Hotel", true, 1, new Guid("653faa7e-e19b-4430-94e7-555616cba66e"), 4, "Westminster Borough" });

            migrationBuilder.InsertData(
                table: "HotelImageUrls",
                columns: new[] { "Id", "CreatedOn", "HotelId", "IsActive", "PublicId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(5945), 1, true, new Guid("52746a70-1f95-4295-9c3f-8b3d755b4dc9"), "https://www.w3schools.com/html/pic_trulli.jpg" },
                    { 2, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(5954), 1, true, new Guid("3221e44c-11b4-4724-b021-a531e3fd27a0"), "https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2" },
                    { 3, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(5960), 2, true, new Guid("38a6ce9d-086d-4df2-a84c-59b45968f4a7"), "https://pix8.agoda.net/hotelImages/182146/-1/112f1fa0f38baf10800569462deb46cd.jpg" },
                    { 4, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(5965), 3, true, new Guid("10c18e2c-d32f-465d-b33c-ee4b82bfbef9"), "https://cf.bstatic.com/xdata/images/hotel/max1024x768/260560238.jpg?k=1d14eb111d6a58d373d4139792c8c0545ec7014527bab0c00a98945e8df46879&o=&hp=1" }
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
                    { 1, 2, "A comfortable room for a relaxing stay.", 1, true, 75.50m, new Guid("ea5886f1-08ee-4bdc-86c4-dfd0970b4ad4"), 25, "Cozy Retreat" },
                    { 2, 1, "Luxurious suite with modern amenities.", 1, true, 120.75m, new Guid("67672e92-dc82-44c1-a1f3-18c0531dcb50"), 40, "Executive Suite" },
                    { 3, 3, "Spacious room suitable for families.", 2, true, 95.25m, new Guid("2a101aaa-c55d-4e1e-afaf-cf8ff13e50f5"), 35, "Family Getaway" },
                    { 4, 1, "Enjoy breathtaking views of the ocean.", 2, true, 110.00m, new Guid("a5ac419c-ad5f-4292-be03-36a9881620ef"), 30, "Ocean View Paradise" },
                    { 5, 2, "Escape to a cozy lodge in the mountains.", 2, true, 85.80m, new Guid("42c617a2-2cf7-4baa-ab23-6c25b7358f8a"), 28, "Mountain Lodge" },
                    { 6, 3, "Luxurious room with a panoramic view.", 3, true, 250.00m, new Guid("e872559a-05c6-4fe3-925c-4462e5de20c7"), 50, "Luxury Suite" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AdultsCount", "CheckIn", "CheckOut", "CreatedOn", "HotelId", "IsActive", "PublicId", "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6117), 1, true, new Guid("361a33dc-f063-4edd-b666-4397cfb3efda"), 1, 1 },
                    { 2, 1, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6135), 1, true, new Guid("e78c3b41-be48-4ee1-9661-c3a1a5c1361f"), 2, 1 },
                    { 3, 3, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6142), 2, true, new Guid("376b5caf-bd6d-40d8-a458-2298bf370b83"), 3, 1 },
                    { 4, 3, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6146), 2, true, new Guid("615910cd-f26e-45d7-9eee-3e3ff2ba5ba6"), 3, 2 },
                    { 5, 1, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6153), 2, true, new Guid("a8f22cc2-1555-4ba0-864b-0c11fd3cc73b"), 4, 2 },
                    { 6, 2, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6158), 2, true, new Guid("3a84eb18-1265-4a9e-9b4d-3c58da91520d"), 5, 2 },
                    { 7, 3, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6165), 3, true, new Guid("076fa9df-7309-4979-a1d8-2ec7da0cc2da"), 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoomImageUrls",
                columns: new[] { "Id", "CreatedOn", "IsActive", "PublicId", "RoomId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6089), true, new Guid("7cf5117f-613c-4155-9e04-872d21480b3b"), 3, "https://img.freepik.com/free-photo/luxury-classic-modern-bedroom-suite-hotel_105762-1787.jpg?size=626&ext=jpg&ga=GA1.1.2008272138.1712707200&semt=ais" },
                    { 2, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6097), true, new Guid("7a8d852b-6abe-4d72-858d-cd0ad426d672"), 3, "https://images.trvl-media.com/lodging/96000000/95770000/95768000/95767989/5674f5e3.jpg?impolicy=resizecrop&rw=1200&ra=fit" },
                    { 3, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6102), true, new Guid("e292412d-b6ca-43ba-9a8c-9c54d2c53c57"), 5, "https://st.depositphotos.com/1007581/1700/i/600/depositphotos_17000573-stock-photo-mountain-resort-house.jpg" },
                    { 4, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6106), true, new Guid("42636c85-9261-41ff-9520-a7bb9130bd00"), 5, "https://whiteface.com/wp-content/uploads/sites/3/2023/08/Cobble-Mountain-Lodge-Cabin-Interior-768x511-1.jpg" },
                    { 5, new DateTime(2024, 4, 23, 16, 19, 54, 988, DateTimeKind.Local).AddTicks(6109), true, new Guid("6b9b2f72-b469-445f-9cd5-4e38add74435"), 6, "https://marriott.cdn.tambourine.com/royalton-resorts/media/royalton_riviera_cancun_luxury_junior_suite_ocean_vew-4-6230a7dfdaf78.jpg" }
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
                columns: new[] { "Id", "AuthorId", "BookingId", "Comment", "HotelId", "IsActive", "PublicId", "RatingScore", "ReviewedOn", "Title" },
                values: new object[] { 1, 1, 1, "Overall, my stay was satisfactory.", 1, true, new Guid("2ed88941-af52-4449-9e2f-8e554ebe83ea"), 7m, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solid Stay, Room for Improvement" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorId", "BookingId", "Comment", "HotelId", "IsActive", "PublicId", "RatingScore", "ReviewedOn", "Title" },
                values: new object[] { 2, 2, 4, "My recent stay was nothing short of exceptional.", 2, true, new Guid("9b76e5a5-fdec-40e8-9208-116f78957656"), 10m, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Stay to Remember" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorId", "BookingId", "Comment", "HotelId", "IsActive", "PublicId", "RatingScore", "ReviewedOn", "Title" },
                values: new object[] { 3, 3, 7, "Great room and service overall!", 3, true, new Guid("b0d6f424-371e-49af-b48e-cb8706c9c65c"), 6.5m, new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Satisfactory" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

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
                table: "RoomImageUrls",
                keyColumn: "Id",
                keyValue: 5);

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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7);

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
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
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
                keyValue: 3);

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
