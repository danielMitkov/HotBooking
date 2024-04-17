using HotBooking.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace HotBooking.Data;

public class DataSeeder
{
    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    public ICollection<Facility> Facilities { get; set; } = new List<Facility>();
    public ICollection<HotelFacility> HotelFacilities { get; set; } = new List<HotelFacility>();
    public ICollection<HotelImageUrl> HotelImageUrls { get; set; } = new List<HotelImageUrl>();
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
    public ICollection<RoomImageUrl> RoomImageUrls { get; set; } = new List<RoomImageUrl>();
    public ICollection<Feature> Features { get; set; } = new List<Feature>();
    public ICollection<RoomFeature> RoomFeatures { get; set; } = new List<RoomFeature>();
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public DataSeeder(bool fillObjectReferences = false)
    {
        SeedApplicationUsers();
        SeedHotels();
        SeedFacilities();
        SeedHotelFacilities();
        SeedHotelImageUrls();
        SeedRooms();
        SeedFeatures();
        SeedRoomFeatures();
        SeedRoomImageUrls();
        SeedBookings();
        SeedReviews();
    }

    public ApplicationUser User_Normal { get; set; } = null!;
    public ApplicationUser User_Second { get; set; } = null!;
    public ApplicationUser User_TobeManager { get; set; } = null!;
    private void SeedApplicationUsers()
    {
        int id = 0;
        var hasher = new PasswordHasher<ApplicationUser>();

        User_Normal = new ApplicationUser()
        {
            Id = ++id,
            UserName = "guest@mail.com",
            NormalizedUserName = "guest@mail.com",
            Email = "guest@mail.com",
            NormalizedEmail = "guest@mail.com",
            SecurityStamp = "db8f4118-4cc2-46dc-a5aa-f2a8c76c283e",
            ConcurrencyStamp = "1355be4d-cf39-4890-a52d-9f71f81edc8c"
        };
        User_Normal.PasswordHash = hasher.HashPassword(User_Normal, "secretpass");
        Users.Add(User_Normal);

        User_Second = new ApplicationUser()
        {
            Id = ++id,
            UserName = "two@mail.com",
            NormalizedUserName = "two@mail.com",
            Email = "two@mail.com",
            NormalizedEmail = "two@mail.com",
            SecurityStamp = "35cc41e6-30eb-4131-a3e5-214c628a45bc",
            ConcurrencyStamp = "6492eedf-dc19-4c73-83a2-8b0b19c56ffa"
        };
        User_Second.PasswordHash = hasher.HashPassword(User_Second, "otherpass");
        Users.Add(User_Second);

        User_TobeManager = new ApplicationUser()
        {
            Id = ++id,
            UserName = "manager@mail.com",
            NormalizedUserName = "manager@mail.com",
            Email = "manager@mail.com",
            NormalizedEmail = "manager@mail.com",
            SecurityStamp = "68c75553-2311-4508-8f97-57b35c275756",
            ConcurrencyStamp = "5dffdb66-294c-4ecb-a4e1-939c86c3602a"
        };
        User_TobeManager.PasswordHash = hasher.HashPassword(User_TobeManager, "managerpass");
        Users.Add(User_TobeManager);
    }

    public Hotel Hotel_ChilworthLondonPaddington { get; set; } = null!;
    public Hotel Hotel_KempinskiHotelGrandArena { get; set; } = null!;
    public Hotel Hotel_StrandPalace { get; set; } = null!;
    private void SeedHotels()
    {
        Hotel_ChilworthLondonPaddington = new Hotel()
        {
            Id = 1,
            PublicId = Guid.Parse("fe10a78f-423b-4e19-8c79-88cef52c46bd"),
            HotelName = "The Chilworth London Paddington",
            Description = "Less than a 5-minute walk from London Paddington Station and Hyde Park, this boutique hotel offers elegant rooms with free internet and satellite TV.",
            StreetAddress = "Westminster Borough",
            CityName = "London",
            CountryName = "United Kingdom",
            StarRating = 5
        };
        Hotels.Add(Hotel_ChilworthLondonPaddington);

        Hotel_KempinskiHotelGrandArena = new Hotel()
        {
            Id = 2,
            PublicId = Guid.Parse("e8efdf7b-5e4c-48ff-8417-ff57968f8cb8"),
            HotelName = "Kempinski Hotel Grand Arena Bansko",
            Description = "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Conveniently situated in the Bansko part of Bansko, this property puts you close to attractions and interesting dining options. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.",
            StreetAddress = "#96 Pirin Street",
            CityName = "Bansko",
            CountryName = "Bulgaria",
            StarRating = 4
        };
        Hotels.Add(Hotel_KempinskiHotelGrandArena);

        Hotel_StrandPalace = new Hotel()
        {
            Id = 3,
            PublicId = Guid.Parse("653faa7e-e19b-4430-94e7-555616cba66e"),
            HotelName = "Strand Palace Hotel",
            Description = "Welcoming guests since 1909, the Strand Palace Hotel is located in London’s West End within just 2297 feet of the Adelphi and the Vaudeville theaters.",
            StreetAddress = "Westminster Borough",
            CityName = "London",
            CountryName = "United Kingdom",
            StarRating = 4
        };
        Hotels.Add(Hotel_StrandPalace);
    }

    public Facility Facility_Spa { get; set; } = null!;
    public Facility Facility_Parking { get; set; } = null!;
    public Facility Facility_WiFi { get; set; } = null!;
    public Facility Facility_Restaurant { get; set; } = null!;
    public Facility Facility_Fitness { get; set; } = null!;
    private void SeedFacilities()
    {
        Facility_Spa = new Facility()
        {
            Id = 1,
            PublicId = Guid.Parse("bd77461c-f3bc-4fa9-97af-4b865e5ae1ad"),
            Name = "Spa",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_Spa);

        Facility_Parking = new Facility()
        {
            Id = 2,
            PublicId = Guid.Parse("e7a6ad8e-f8c1-4a28-9c9d-6b741f8abb21"),
            Name = "Parking",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_Parking);

        Facility_WiFi = new Facility()
        {
            Id = 3,
            PublicId = Guid.Parse("d443a26f-1b2c-4da6-b0e1-08668fed10bb"),
            Name = "WiFi",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_WiFi);

        Facility_Restaurant = new Facility()
        {
            Id = 4,
            PublicId = Guid.Parse("dd36efb6-0080-4fe7-b7d3-099c49bbfab3"),
            Name = "Restaurant",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_Restaurant);

        Facility_Fitness = new Facility()
        {
            Id = 5,
            PublicId = Guid.Parse("73324070-64ea-40b7-aadb-dd37821b1f8c"),
            Name = "Fitness",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_Fitness);
    }

    public HotelFacility HotelFacility_ChilworthLondonPaddington_WiFi { get; set; } = null!;
    public HotelFacility HotelFacility_ChilworthLondonPaddington_Parking { get; set; } = null!;
    public HotelFacility HotelFacility_ChilworthLondonPaddington_Spa { get; set; } = null!;
    public HotelFacility HotelFacility_ChilworthLondonPaddington_Fitness { get; set; } = null!;
    public HotelFacility HotelFacility_KempinskiHotelGrandArena_WiFi { get; set; } = null!;
    public HotelFacility HotelFacility_KempinskiHotelGrandArena_Parking { get; set; } = null!;
    public HotelFacility HotelFacility_KempinskiHotelGrandArena_Restaurant { get; set; } = null!;
    public HotelFacility HotelFacility_StrandPalace_WiFi { get; set; } = null!;
    public HotelFacility HotelFacility_StrandPalace_Parking { get; set; } = null!;
    private void SeedHotelFacilities()
    {
        HotelFacility_ChilworthLondonPaddington_WiFi = new HotelFacility()
        {
            HotelId = Hotel_ChilworthLondonPaddington.Id,
            FacilityId = Facility_WiFi.Id
        };
        HotelFacilities.Add(HotelFacility_ChilworthLondonPaddington_WiFi);

        HotelFacility_ChilworthLondonPaddington_Parking = new HotelFacility()
        {
            HotelId = Hotel_ChilworthLondonPaddington.Id,
            FacilityId = Facility_Parking.Id
        };
        HotelFacilities.Add(HotelFacility_ChilworthLondonPaddington_Parking);

        HotelFacility_ChilworthLondonPaddington_Spa = new HotelFacility()
        {
            HotelId = Hotel_ChilworthLondonPaddington.Id,
            FacilityId = Facility_Spa.Id
        };
        HotelFacilities.Add(HotelFacility_ChilworthLondonPaddington_Spa);

        HotelFacility_ChilworthLondonPaddington_Fitness = new HotelFacility()
        {
            HotelId = Hotel_ChilworthLondonPaddington.Id,
            FacilityId = Facility_Fitness.Id
        };
        HotelFacilities.Add(HotelFacility_ChilworthLondonPaddington_Fitness);
        //
        HotelFacility_KempinskiHotelGrandArena_WiFi = new HotelFacility()
        {
            HotelId = Hotel_KempinskiHotelGrandArena.Id,
            FacilityId = Facility_WiFi.Id
        };
        HotelFacilities.Add(HotelFacility_KempinskiHotelGrandArena_WiFi);

        HotelFacility_KempinskiHotelGrandArena_Parking = new HotelFacility()
        {
            HotelId = Hotel_KempinskiHotelGrandArena.Id,
            FacilityId = Facility_Parking.Id
        };
        HotelFacilities.Add(HotelFacility_KempinskiHotelGrandArena_Parking);

        HotelFacility_KempinskiHotelGrandArena_Restaurant = new HotelFacility()
        {
            HotelId = Hotel_KempinskiHotelGrandArena.Id,
            FacilityId = Facility_Restaurant.Id
        };
        HotelFacilities.Add(HotelFacility_KempinskiHotelGrandArena_Restaurant);
        //
        HotelFacility_StrandPalace_WiFi = new HotelFacility()
        {
            HotelId = Hotel_StrandPalace.Id,
            FacilityId = Facility_WiFi.Id
        };
        HotelFacilities.Add(HotelFacility_StrandPalace_WiFi);

        HotelFacility_StrandPalace_Parking = new HotelFacility()
        {
            HotelId = Hotel_StrandPalace.Id,
            FacilityId = Facility_Parking.Id
        };
        HotelFacilities.Add(HotelFacility_StrandPalace_Parking);
    }

    public HotelImageUrl HotelImageUrl_ThreeWhiteHouses { get; set; } = null!;
    public HotelImageUrl HotelImageUrl_NightLights { get; set; } = null!;
    public HotelImageUrl HotelImageUrl_MultiHotels { get; set; } = null!;
    public HotelImageUrl HotelImageUrl_OldCentral { get; set; } = null!;
    private void SeedHotelImageUrls()
    {
        int id = 0;

        HotelImageUrl_ThreeWhiteHouses = new HotelImageUrl()
        {
            Id = ++id,
            PublicId = Guid.Parse("52746a70-1f95-4295-9c3f-8b3d755b4dc9"),
            Url = "https://www.w3schools.com/html/pic_trulli.jpg",
            HotelId = Hotel_ChilworthLondonPaddington.Id
        };
        HotelImageUrls.Add(HotelImageUrl_ThreeWhiteHouses);

        HotelImageUrl_NightLights = new HotelImageUrl()
        {
            Id = ++id,
            PublicId = Guid.Parse("3221e44c-11b4-4724-b021-a531e3fd27a0"),
            Url = "https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
            HotelId = Hotel_ChilworthLondonPaddington.Id
        };
        HotelImageUrls.Add(HotelImageUrl_NightLights);

        HotelImageUrl_MultiHotels = new HotelImageUrl()
        {
            Id = ++id,
            PublicId = Guid.Parse("38a6ce9d-086d-4df2-a84c-59b45968f4a7"),
            Url = "https://pix8.agoda.net/hotelImages/182146/-1/112f1fa0f38baf10800569462deb46cd.jpg",
            HotelId = Hotel_KempinskiHotelGrandArena.Id
        };
        HotelImageUrls.Add(HotelImageUrl_MultiHotels);

        HotelImageUrl_OldCentral = new HotelImageUrl()
        {
            Id = ++id,
            PublicId = Guid.Parse("10c18e2c-d32f-465d-b33c-ee4b82bfbef9"),
            Url = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/260560238.jpg?k=1d14eb111d6a58d373d4139792c8c0545ec7014527bab0c00a98945e8df46879&o=&hp=1",
            HotelId = Hotel_StrandPalace.Id
        };
        HotelImageUrls.Add(HotelImageUrl_OldCentral);
    }

    public Room Room_ChilworthLondonPaddington_CozyRetreat { get; set; } = null!;
    public Room Room_ChilworthLondonPaddington_ExecutiveSuite { get; set; } = null!;
    public Room Room_KempinskiHotelGrandArena_FamilyGetaway { get; set; } = null!;
    public Room Room_KempinskiHotelGrandArena_OceanViewParadise { get; set; } = null!;
    public Room Room_KempinskiHotelGrandArena_MountainLodge { get; set; } = null!;
    public Room Room_StrandPalace_LuxurySuite { get; set; } = null!;
    private void SeedRooms()
    {
        int id = 0;

        Room_ChilworthLondonPaddington_CozyRetreat = new Room
        {
            Id = ++id,
            PublicId = Guid.Parse("ea5886f1-08ee-4bdc-86c4-dfd0970b4ad4"),
            Title = "Cozy Retreat",
            Description = "A comfortable room for a relaxing stay.",
            BedsCount = 2,
            RoomSizeSquareMeters = 25,
            PricePerNight = 75.50m,
            HotelId = Hotel_ChilworthLondonPaddington.Id
        };
        Rooms.Add(Room_ChilworthLondonPaddington_CozyRetreat);

        Room_ChilworthLondonPaddington_ExecutiveSuite = new Room
        {
            Id = ++id,
            PublicId = Guid.Parse("67672e92-dc82-44c1-a1f3-18c0531dcb50"),
            Title = "Executive Suite",
            Description = "Luxurious suite with modern amenities.",
            BedsCount = 1,
            RoomSizeSquareMeters = 40,
            PricePerNight = 120.75m,
            HotelId = Hotel_ChilworthLondonPaddington.Id
        };
        Rooms.Add(Room_ChilworthLondonPaddington_ExecutiveSuite);

        Room_KempinskiHotelGrandArena_FamilyGetaway = new Room
        {
            Id = ++id,
            PublicId = Guid.Parse("2a101aaa-c55d-4e1e-afaf-cf8ff13e50f5"),
            Title = "Family Getaway",
            Description = "Spacious room suitable for families.",
            BedsCount = 3,
            RoomSizeSquareMeters = 35,
            PricePerNight = 95.25m,
            HotelId = Hotel_KempinskiHotelGrandArena.Id
        };
        Rooms.Add(Room_KempinskiHotelGrandArena_FamilyGetaway);

        Room_KempinskiHotelGrandArena_OceanViewParadise = new Room
        {
            Id = ++id,
            PublicId = Guid.Parse("a5ac419c-ad5f-4292-be03-36a9881620ef"),
            Title = "Ocean View Paradise",
            Description = "Enjoy breathtaking views of the ocean.",
            BedsCount = 1,
            RoomSizeSquareMeters = 30,
            PricePerNight = 110.00m,
            HotelId = Hotel_KempinskiHotelGrandArena.Id
        };
        Rooms.Add(Room_KempinskiHotelGrandArena_OceanViewParadise);

        Room_KempinskiHotelGrandArena_MountainLodge = new Room
        {
            Id = ++id,
            PublicId = Guid.Parse("42c617a2-2cf7-4baa-ab23-6c25b7358f8a"),
            Title = "Mountain Lodge",
            Description = "Escape to a cozy lodge in the mountains.",
            BedsCount = 2,
            RoomSizeSquareMeters = 28,
            PricePerNight = 85.80m,
            HotelId = Hotel_KempinskiHotelGrandArena.Id
        };
        Rooms.Add(Room_KempinskiHotelGrandArena_MountainLodge);

        Room_StrandPalace_LuxurySuite = new Room
        {
            Id = ++id,
            PublicId = Guid.Parse("e872559a-05c6-4fe3-925c-4462e5de20c7"),
            Title = "Luxury Suite",
            Description = "Luxurious room with a panoramic view.",
            BedsCount = 3,
            RoomSizeSquareMeters = 50,
            PricePerNight = 250.00m,
            HotelId = Hotel_StrandPalace.Id
        };
        Rooms.Add(Room_StrandPalace_LuxurySuite);
    }

    public Feature Feature_TV { get; set; } = null!;
    public Feature Feature_Refrigerator { get; set; } = null!;
    public Feature Feature_Hairdryer { get; set; } = null!;
    public Feature Feature_Towels { get; set; } = null!;
    public Feature Feature_Slippers { get; set; } = null!;
    public Feature Feature_Bathtub { get; set; } = null!;
    private void SeedFeatures()
    {
        int id = 0;

        Feature_TV = new Feature
        {
            Id = ++id,
            PublicId = Guid.Parse("b2f23b10-6219-46c4-9e05-4a7f2022d91e"),
            Name = "TV",
            SvgTag = string.Empty
        };
        Features.Add(Feature_TV);

        Feature_Refrigerator = new Feature
        {
            Id = ++id,
            PublicId = Guid.Parse("9f4f658a-6d84-46b4-8d52-6db5238b760b"),
            Name = "Refrigerator",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Refrigerator);

        Feature_Hairdryer = new Feature
        {
            Id = ++id,
            PublicId = Guid.Parse("41fd8a74-4f85-4fe4-aa02-f1cd4b922e53"),
            Name = "Hairdryer",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Hairdryer);

        Feature_Towels = new Feature
        {
            Id = ++id,
            PublicId = Guid.Parse("41233a4d-2b06-4a17-a03e-d83b8afe6b58"),
            Name = "Towels",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Towels);

        Feature_Slippers = new Feature
        {
            Id = ++id,
            PublicId = Guid.Parse("8b5dbbe9-a33e-454a-b604-34a55bffe057"),
            Name = "Slippers",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Slippers);

        Feature_Bathtub = new Feature
        {
            Id = ++id,
            PublicId = Guid.Parse("1b9d6d74-c620-4895-9030-52a6a75d6e80"),
            Name = "Bathtub",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Bathtub);
    }

    public RoomFeature RoomFeature_FamilyGetaway_Bathtub { get; set; } = null!;
    public RoomFeature RoomFeature_FamilyGetaway_Slippers { get; set; } = null!;
    public RoomFeature RoomFeature_MountainLodge_TV { get; set; } = null!;
    public RoomFeature RoomFeature_MountainLodge_Refrigerator { get; set; } = null!;
    private void SeedRoomFeatures()
    {
        RoomFeature_FamilyGetaway_Bathtub = new RoomFeature
        {
            FeatureId = Feature_Bathtub.Id,
            RoomId = Room_KempinskiHotelGrandArena_FamilyGetaway.Id
        };
        RoomFeatures.Add(RoomFeature_FamilyGetaway_Bathtub);

        RoomFeature_FamilyGetaway_Slippers = new RoomFeature
        {
            FeatureId = Feature_Slippers.Id,
            RoomId = Room_KempinskiHotelGrandArena_FamilyGetaway.Id
        };
        RoomFeatures.Add(RoomFeature_FamilyGetaway_Slippers);

        RoomFeature_MountainLodge_TV = new RoomFeature
        {
            FeatureId = Feature_TV.Id,
            RoomId = Room_KempinskiHotelGrandArena_MountainLodge.Id
        };
        RoomFeatures.Add(RoomFeature_MountainLodge_TV);

        RoomFeature_MountainLodge_Refrigerator = new RoomFeature
        {
            FeatureId = Feature_Refrigerator.Id,
            RoomId = Room_KempinskiHotelGrandArena_MountainLodge.Id
        };
        RoomFeatures.Add(RoomFeature_MountainLodge_Refrigerator);
    }

    public RoomImageUrl RoomImageUrl_FamilyGetaway_LuxuryClassicModern { get; set; } = null!;
    public RoomImageUrl RoomImageUrl_FamilyGetaway_BlueView { get; set; } = null!;
    public RoomImageUrl RoomImageUrl_MountainLodge_MountainResort { get; set; } = null!;
    public RoomImageUrl RoomImageUrl_MountainLodge_CabinInterior { get; set; } = null!;
    public RoomImageUrl RoomImageUrl_LuxurySuite_Golden { get; set; } = null!;
    private void SeedRoomImageUrls()
    {
        int id = 0;

        RoomImageUrl_FamilyGetaway_LuxuryClassicModern = new RoomImageUrl
        {
            Id = ++id,
            PublicId = Guid.Parse("7cf5117f-613c-4155-9e04-872d21480b3b"),
            Url = "https://img.freepik.com/free-photo/luxury-classic-modern-bedroom-suite-hotel_105762-1787.jpg?size=626&ext=jpg&ga=GA1.1.2008272138.1712707200&semt=ais",
            RoomId = Room_KempinskiHotelGrandArena_FamilyGetaway.Id
        };
        RoomImageUrls.Add(RoomImageUrl_FamilyGetaway_LuxuryClassicModern);

        RoomImageUrl_FamilyGetaway_BlueView = new RoomImageUrl
        {
            Id = ++id,
            PublicId = Guid.Parse("7a8d852b-6abe-4d72-858d-cd0ad426d672"),
            Url = "https://images.trvl-media.com/lodging/96000000/95770000/95768000/95767989/5674f5e3.jpg?impolicy=resizecrop&rw=1200&ra=fit",
            RoomId = Room_KempinskiHotelGrandArena_FamilyGetaway.Id
        };
        RoomImageUrls.Add(RoomImageUrl_FamilyGetaway_BlueView);

        RoomImageUrl_MountainLodge_MountainResort = new RoomImageUrl
        {
            Id = ++id,
            PublicId = Guid.Parse("e292412d-b6ca-43ba-9a8c-9c54d2c53c57"),
            Url = "https://st.depositphotos.com/1007581/1700/i/600/depositphotos_17000573-stock-photo-mountain-resort-house.jpg",
            RoomId = Room_KempinskiHotelGrandArena_MountainLodge.Id
        };
        RoomImageUrls.Add(RoomImageUrl_MountainLodge_MountainResort);

        RoomImageUrl_MountainLodge_CabinInterior = new RoomImageUrl
        {
            Id = ++id,
            PublicId = Guid.Parse("42636c85-9261-41ff-9520-a7bb9130bd00"),
            Url = "https://whiteface.com/wp-content/uploads/sites/3/2023/08/Cobble-Mountain-Lodge-Cabin-Interior-768x511-1.jpg",
            RoomId = Room_KempinskiHotelGrandArena_MountainLodge.Id
        };
        RoomImageUrls.Add(RoomImageUrl_MountainLodge_CabinInterior);

        RoomImageUrl_LuxurySuite_Golden = new RoomImageUrl
        {
            Id = ++id,
            PublicId = Guid.Parse("6b9b2f72-b469-445f-9cd5-4e38add74435"),
            Url = "https://marriott.cdn.tambourine.com/royalton-resorts/media/royalton_riviera_cancun_luxury_junior_suite_ocean_vew-4-6230a7dfdaf78.jpg",
            RoomId = Room_StrandPalace_LuxurySuite.Id
        };
        RoomImageUrls.Add(RoomImageUrl_LuxurySuite_Golden);
    }

    public Booking Booking_NormalUser_ChilworthPaddington_CozyRetreat { get; set; } = null!;
    public Booking Booking_NormalUser_ChilworthPaddington_ExecutiveSuite { get; set; } = null!;
    public Booking Booking_NormalUser_KempinskiHotel_FamilyGetaway { get; set; } = null!;
    public Booking Booking_SecondUser_KempinskiHotel_FamilyGetaway { get; set; } = null!;
    public Booking Booking_SecondUser_KempinskiHotel_OceanViewParadise { get; set; } = null!;
    public Booking Booking_SecondUser_KempinskiHotel_MountainLodge { get; set; } = null!;
    public Booking Booking_TobeManagerUser_StrandPalaceHotel_LuxurySuite { get; set; } = null!;
    private void SeedBookings()
    {
        int id = 0;

        Booking_NormalUser_ChilworthPaddington_CozyRetreat = new Booking
        {
            Id = ++id,
            PublicId = Guid.Parse("361a33dc-f063-4edd-b666-4397cfb3efda"),
            CheckIn = new DateTime(2023, 5, 1),
            CheckOut = new DateTime(2023, 5, 5),
            AdultsCount = Room_ChilworthLondonPaddington_CozyRetreat.BedsCount,
            UserId = User_Normal.Id,
            RoomId = Room_ChilworthLondonPaddington_CozyRetreat.Id,
            HotelId = Room_ChilworthLondonPaddington_CozyRetreat.HotelId
        };
        Bookings.Add(Booking_NormalUser_ChilworthPaddington_CozyRetreat);

        Booking_NormalUser_ChilworthPaddington_ExecutiveSuite = new Booking
        {
            Id = ++id,
            PublicId = Guid.Parse("e78c3b41-be48-4ee1-9661-c3a1a5c1361f"),
            CheckIn = new DateTime(2023, 6, 10),
            CheckOut = new DateTime(2023, 6, 15),
            AdultsCount = Room_ChilworthLondonPaddington_ExecutiveSuite.BedsCount,
            UserId = User_Normal.Id,
            RoomId = Room_ChilworthLondonPaddington_ExecutiveSuite.Id,
            HotelId = Room_ChilworthLondonPaddington_ExecutiveSuite.HotelId
        };
        Bookings.Add(Booking_NormalUser_ChilworthPaddington_ExecutiveSuite);

        Booking_NormalUser_KempinskiHotel_FamilyGetaway = new Booking
        {
            Id = ++id,
            PublicId = Guid.Parse("376b5caf-bd6d-40d8-a458-2298bf370b83"),
            CheckIn = new DateTime(2023, 10, 3),
            CheckOut = new DateTime(2023, 10, 10),
            AdultsCount = Room_KempinskiHotelGrandArena_FamilyGetaway.BedsCount,
            UserId = User_Normal.Id,
            RoomId = Room_KempinskiHotelGrandArena_FamilyGetaway.Id,
            HotelId = Room_KempinskiHotelGrandArena_FamilyGetaway.HotelId
        };
        Bookings.Add(Booking_NormalUser_KempinskiHotel_FamilyGetaway);

        Booking_SecondUser_KempinskiHotel_FamilyGetaway = new Booking
        {
            Id = ++id,
            PublicId = Guid.Parse("615910cd-f26e-45d7-9eee-3e3ff2ba5ba6"),
            CheckIn = new DateTime(2023, 7, 20),
            CheckOut = new DateTime(2023, 7, 25),
            AdultsCount = Room_KempinskiHotelGrandArena_FamilyGetaway.BedsCount,
            UserId = User_Second.Id,
            RoomId = Room_KempinskiHotelGrandArena_FamilyGetaway.Id,
            HotelId = Room_KempinskiHotelGrandArena_FamilyGetaway.HotelId
        };
        Bookings.Add(Booking_SecondUser_KempinskiHotel_FamilyGetaway);

        Booking_SecondUser_KempinskiHotel_OceanViewParadise = new Booking
        {
            Id = ++id,
            PublicId = Guid.Parse("a8f22cc2-1555-4ba0-864b-0c11fd3cc73b"),
            CheckIn = new DateTime(2023, 8, 5),
            CheckOut = new DateTime(2023, 8, 10),
            AdultsCount = Room_KempinskiHotelGrandArena_OceanViewParadise.BedsCount,
            UserId = User_Second.Id,
            RoomId = Room_KempinskiHotelGrandArena_OceanViewParadise.Id,
            HotelId = Room_KempinskiHotelGrandArena_OceanViewParadise.HotelId
        };
        Bookings.Add(Booking_SecondUser_KempinskiHotel_OceanViewParadise);

        Booking_SecondUser_KempinskiHotel_MountainLodge = new Booking
        {
            Id = ++id,
            PublicId = Guid.Parse("3a84eb18-1265-4a9e-9b4d-3c58da91520d"),
            CheckIn = new DateTime(2023, 9, 15),
            CheckOut = new DateTime(2023, 9, 20),
            AdultsCount = Room_KempinskiHotelGrandArena_MountainLodge.BedsCount,
            UserId = User_Second.Id,
            RoomId = Room_KempinskiHotelGrandArena_MountainLodge.Id,
            HotelId = Room_KempinskiHotelGrandArena_MountainLodge.HotelId
        };
        Bookings.Add(Booking_SecondUser_KempinskiHotel_MountainLodge);

        Booking_TobeManagerUser_StrandPalaceHotel_LuxurySuite = new Booking
        {
            Id = ++id,
            PublicId = Guid.Parse("076fa9df-7309-4979-a1d8-2ec7da0cc2da"),
            CheckIn = new DateTime(2023, 10, 17),
            CheckOut = new DateTime(2023, 10, 21),
            AdultsCount = Room_StrandPalace_LuxurySuite.BedsCount,
            UserId = User_TobeManager.Id,
            RoomId = Room_StrandPalace_LuxurySuite.Id,
            HotelId = Room_StrandPalace_LuxurySuite.HotelId
        };
        Bookings.Add(Booking_TobeManagerUser_StrandPalaceHotel_LuxurySuite);
    }

    public Review Review_NormalUser_ChilworthLondonPaddington { get; set; } = null!;
    public Review Review_SecondUser_KempinskiHotelGrandArena { get; set; } = null!;
    public Review Review_TobeManagerUser_StrandPalace { get; set; } = null!;
    private void SeedReviews()
    {
        int id = 0;

        Review_NormalUser_ChilworthLondonPaddington = new Review
        {
            Id = ++id,
            PublicId = Guid.Parse("2ed88941-af52-4449-9e2f-8e554ebe83ea"),
            RatingScore = 7,
            Title = "Solid Stay, Room for Improvement",
            Comment = "Overall, my stay was satisfactory.",
            ReviewedOn = Booking_NormalUser_ChilworthPaddington_CozyRetreat.CheckOut.AddDays(1),
            HotelId = Hotel_ChilworthLondonPaddington.Id,
            BookingId = Booking_NormalUser_ChilworthPaddington_CozyRetreat.Id,
            AuthorId = User_Normal.Id
        };
        Reviews.Add(Review_NormalUser_ChilworthLondonPaddington);

        Review_SecondUser_KempinskiHotelGrandArena = new Review
        {
            Id = ++id,
            PublicId = Guid.Parse("9b76e5a5-fdec-40e8-9208-116f78957656"),
            RatingScore = 10,
            Title = "A Stay to Remember",
            Comment = "My recent stay was nothing short of exceptional.",
            ReviewedOn = Booking_SecondUser_KempinskiHotel_FamilyGetaway.CheckOut.AddDays(1),
            HotelId = Hotel_KempinskiHotelGrandArena.Id,
            BookingId = Booking_SecondUser_KempinskiHotel_FamilyGetaway.Id,
            AuthorId = User_Second.Id
        };
        Reviews.Add(Review_SecondUser_KempinskiHotelGrandArena);

        Review_TobeManagerUser_StrandPalace = new Review
        {
            Id = ++id,
            PublicId = Guid.Parse("b0d6f424-371e-49af-b48e-cb8706c9c65c"),
            RatingScore = 6.5m,
            Title = "Satisfactory",
            Comment = "Great room and service overall!",
            ReviewedOn = Booking_TobeManagerUser_StrandPalaceHotel_LuxurySuite.CheckOut.AddDays(1),
            HotelId = Hotel_StrandPalace.Id,
            BookingId = Booking_TobeManagerUser_StrandPalaceHotel_LuxurySuite.Id,
            AuthorId = User_TobeManager.Id
        };
        Reviews.Add(Review_TobeManagerUser_StrandPalace);
    }
}
