using HotBooking.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace HotBooking.Data;

public class DataSeeder
{
    public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    public ICollection<Manager> Managers { get; set; } = new List<Manager>();
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
        SeedManagers();
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

        if (fillObjectReferences)
        {
            SetReferencesApplicationUsers();
            SetReferencesManagers();
            SetReferencesHotels();
            SetReferencesFacilities();
            SetReferencesHotelFacilities();
            SetReferencesHotelImageUrls();
            SetReferencesRooms();
            SetReferencesFeatures();
            SetReferencesRoomFeatures();
            SetReferencesRoomImageUrls();
            SetReferencesBookings();
            SetReferencesReviews();
        }
    }

    public ApplicationUser User_Normal { get; set; } = null!;
    public ApplicationUser User_Second { get; set; } = null!;
    public ApplicationUser User_TobeManager { get; set; } = null!;
    private void SeedApplicationUsers()
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        User_Normal = new ApplicationUser()
        {
            Id = 1,
            UserName = "guest@mail.com",
            NormalizedUserName = "guest@mail.com",
            Email = "guest@mail.com",
            NormalizedEmail = "guest@mail.com",
            SecurityStamp = Guid.NewGuid().ToString()
        };
        User_Normal.PasswordHash = hasher.HashPassword(User_Normal, "secretpass");
        ApplicationUsers.Add(User_Normal);

        User_Second = new ApplicationUser()
        {
            Id = 2,
            UserName = "two@mail.com",
            NormalizedUserName = "two@mail.com",
            Email = "two@mail.com",
            NormalizedEmail = "two@mail.com",
            SecurityStamp = Guid.NewGuid().ToString()
        };
        User_Second.PasswordHash = hasher.HashPassword(User_Second, "otherpass");
        ApplicationUsers.Add(User_Second);

        User_TobeManager = new ApplicationUser()
        {
            Id = 3,
            UserName = "manager@mail.com",
            NormalizedUserName = "manager@mail.com",
            Email = "manager@mail.com",
            NormalizedEmail = "manager@mail.com",
            SecurityStamp = Guid.NewGuid().ToString()
        };
        User_TobeManager.PasswordHash = hasher.HashPassword(User_TobeManager, "managerpass");
        ApplicationUsers.Add(User_TobeManager);
    }
    private void SetReferencesApplicationUsers()
    {
        User_Normal.Bookings = Bookings.Where(b => b.UserId == User_Normal.Id).ToList();
        User_Normal.Reviews = Reviews.Where(r => r.UserId == User_Normal.Id).ToList();

        User_Second.Bookings = Bookings.Where(b => b.UserId == User_Second.Id).ToList();
        User_Second.Reviews = Reviews.Where(r => r.UserId == User_Second.Id).ToList();

        User_TobeManager.Bookings = Bookings.Where(b => b.UserId == User_TobeManager.Id).ToList();
        User_TobeManager.Reviews = Reviews.Where(r => r.UserId == User_TobeManager.Id).ToList();
    }

    public Manager Manager_First { get; set; } = null!;
    private void SeedManagers()
    {
        Manager_First = new Manager()
        {
            Id = 1,
            PhoneNumber = "08812345678",
            UserId = User_TobeManager.Id
        };
        Managers.Add(Manager_First);
    }
    private void SetReferencesManagers()
    {
        Manager_First.User = User_TobeManager;
        Manager_First.Hotels = Hotels.Where(h => h.ManagerId == Manager_First.Id).ToList();
    }

    public Hotel Hotel_ChilworthLondonPaddington { get; set; } = null!;
    public Hotel Hotel_KempinskiHotelGrandArena { get; set; } = null!;
    public Hotel Hotel_StrandPalace { get; set; } = null!;
    private void SeedHotels()
    {
        Hotel_ChilworthLondonPaddington = new Hotel()
        {
            Id = 1,
            HotelName = "The Chilworth London Paddington",
            Description = "Less than a 5-minute walk from London Paddington Station and Hyde Park, this boutique hotel offers elegant rooms with free internet and satellite TV.",
            StreetAddress = "Westminster Borough",
            CityName = "London",
            CountryName = "United Kingdom",
            StarRating = 5,
            ManagerId = Manager_First.Id
        };
        Hotels.Add(Hotel_ChilworthLondonPaddington);

        Hotel_KempinskiHotelGrandArena = new Hotel()
        {
            Id = 2,
            HotelName = "Kempinski Hotel Grand Arena Bansko",
            Description = "Get your trip off to a great start with a stay at this property, which offers free Wi-Fi in all rooms. Conveniently situated in the Bansko part of Bansko, this property puts you close to attractions and interesting dining options. Rated with 5 stars, this high-quality property provides guests with access to massage, restaurant and hot tub on-site.",
            StreetAddress = "#96 Pirin Street",
            CityName = "Bansko",
            CountryName = "Bulgaria",
            StarRating = 4,
            ManagerId = Manager_First.Id
        };
        Hotels.Add(Hotel_KempinskiHotelGrandArena);

        Hotel_StrandPalace = new Hotel()
        {
            Id = 3,
            HotelName = "Strand Palace Hotel",
            Description = "Welcoming guests since 1909, the Strand Palace Hotel is located in London’s West End within just 2297 feet of the Adelphi and the Vaudeville theaters.",
            StreetAddress = "Westminster Borough",
            CityName = "London",
            CountryName = "United Kingdom",
            StarRating = 4,
            ManagerId = Manager_First.Id
        };
        Hotels.Add(Hotel_StrandPalace);
    }
    private void SetReferencesHotels()
    {
        Hotel_ChilworthLondonPaddington.Manager = Manager_First;
        Hotel_ChilworthLondonPaddington.HotelsFacilities = HotelFacilities.Where(hf => hf.HotelId == Hotel_ChilworthLondonPaddington.Id).ToList();
        Hotel_ChilworthLondonPaddington.Rooms = Rooms.Where(r => r.HotelId == Hotel_ChilworthLondonPaddington.Id).ToList();
        Hotel_ChilworthLondonPaddington.HotelImages = HotelImageUrls.Where(i => i.HotelId == Hotel_ChilworthLondonPaddington.Id).ToList();
        Hotel_ChilworthLondonPaddington.Reviews = Reviews.Where(r => r.HotelId == Hotel_ChilworthLondonPaddington.Id).ToList();
        Hotel_ChilworthLondonPaddington.Bookings = Bookings.Where(b => b.HotelId == Hotel_ChilworthLondonPaddington.Id).ToList();

        Hotel_KempinskiHotelGrandArena.Manager = Manager_First;
        Hotel_KempinskiHotelGrandArena.HotelsFacilities = HotelFacilities.Where(hf => hf.HotelId == Hotel_KempinskiHotelGrandArena.Id).ToList();
        Hotel_KempinskiHotelGrandArena.Rooms = Rooms.Where(r => r.HotelId == Hotel_KempinskiHotelGrandArena.Id).ToList();
        Hotel_KempinskiHotelGrandArena.HotelImages = HotelImageUrls.Where(i => i.HotelId == Hotel_KempinskiHotelGrandArena.Id).ToList();
        Hotel_KempinskiHotelGrandArena.Reviews = Reviews.Where(r => r.HotelId == Hotel_KempinskiHotelGrandArena.Id).ToList();
        Hotel_KempinskiHotelGrandArena.Bookings = Bookings.Where(b => b.HotelId == Hotel_KempinskiHotelGrandArena.Id).ToList();

        Hotel_StrandPalace.Manager = Manager_First;
        Hotel_StrandPalace.HotelsFacilities = HotelFacilities.Where(hf => hf.HotelId == Hotel_StrandPalace.Id).ToList();
        Hotel_StrandPalace.Rooms = Rooms.Where(r => r.HotelId == Hotel_StrandPalace.Id).ToList();
        Hotel_StrandPalace.HotelImages = HotelImageUrls.Where(i => i.HotelId == Hotel_StrandPalace.Id).ToList();
        Hotel_StrandPalace.Reviews = Reviews.Where(r => r.HotelId == Hotel_StrandPalace.Id).ToList();
        Hotel_StrandPalace.Bookings = Bookings.Where(b => b.HotelId == Hotel_StrandPalace.Id).ToList();
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
            Name = "Spa",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_Spa);

        Facility_Parking = new Facility()
        {
            Id = 2,
            Name = "Parking",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_Parking);

        Facility_WiFi = new Facility()
        {
            Id = 3,
            Name = "WiFi",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_WiFi);

        Facility_Restaurant = new Facility()
        {
            Id = 4,
            Name = "Restaurant",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_Restaurant);

        Facility_Fitness = new Facility()
        {
            Id = 5,
            Name = "Fitness",
            SvgTag = string.Empty
        };
        Facilities.Add(Facility_Fitness);
    }
    private void SetReferencesFacilities()
    {
        Facility_Spa.HotelsFacilities = HotelFacilities.Where(hf => hf.FacilityId == Facility_Spa.Id).ToList();

        Facility_Parking.HotelsFacilities = HotelFacilities.Where(hf => hf.FacilityId == Facility_Parking.Id).ToList();

        Facility_WiFi.HotelsFacilities = HotelFacilities.Where(hf => hf.FacilityId == Facility_WiFi.Id).ToList();

        Facility_Restaurant.HotelsFacilities = HotelFacilities.Where(hf => hf.FacilityId == Facility_Restaurant.Id).ToList();

        Facility_Fitness.HotelsFacilities = HotelFacilities.Where(hf => hf.FacilityId == Facility_Fitness.Id).ToList();
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
    private void SetReferencesHotelFacilities()
    {
        HotelFacility_ChilworthLondonPaddington_WiFi.Hotel = Hotel_ChilworthLondonPaddington;
        HotelFacility_ChilworthLondonPaddington_WiFi.Facility = Facility_WiFi;

        HotelFacility_ChilworthLondonPaddington_Parking.Hotel = Hotel_ChilworthLondonPaddington;
        HotelFacility_ChilworthLondonPaddington_Parking.Facility = Facility_Parking;

        HotelFacility_ChilworthLondonPaddington_Spa.Hotel = Hotel_ChilworthLondonPaddington;
        HotelFacility_ChilworthLondonPaddington_Spa.Facility = Facility_Spa;

        HotelFacility_ChilworthLondonPaddington_Fitness.Hotel = Hotel_ChilworthLondonPaddington;
        HotelFacility_ChilworthLondonPaddington_Fitness.Facility = Facility_Fitness;
        //
        HotelFacility_KempinskiHotelGrandArena_WiFi.Hotel = Hotel_KempinskiHotelGrandArena;
        HotelFacility_KempinskiHotelGrandArena_WiFi.Facility = Facility_WiFi;

        HotelFacility_KempinskiHotelGrandArena_Parking.Hotel = Hotel_KempinskiHotelGrandArena;
        HotelFacility_KempinskiHotelGrandArena_Parking.Facility = Facility_Parking;

        HotelFacility_KempinskiHotelGrandArena_Restaurant.Hotel = Hotel_KempinskiHotelGrandArena;
        HotelFacility_KempinskiHotelGrandArena_Restaurant.Facility = Facility_Restaurant;
        //
        HotelFacility_StrandPalace_WiFi.Hotel = Hotel_StrandPalace;
        HotelFacility_StrandPalace_WiFi.Facility = Facility_WiFi;

        HotelFacility_StrandPalace_Parking.Hotel = Hotel_StrandPalace;
        HotelFacility_StrandPalace_Parking.Facility = Facility_Parking;
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
            Url = "https://www.w3schools.com/html/pic_trulli.jpg",
            HotelId = Hotel_ChilworthLondonPaddington.Id
        };
        HotelImageUrls.Add(HotelImageUrl_ThreeWhiteHouses);

        HotelImageUrl_NightLights = new HotelImageUrl()
        {
            Id = ++id,
            Url = "https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
            HotelId = Hotel_ChilworthLondonPaddington.Id
        };
        HotelImageUrls.Add(HotelImageUrl_NightLights);

        HotelImageUrl_MultiHotels = new HotelImageUrl()
        {
            Id = ++id,
            Url = "https://pix8.agoda.net/hotelImages/182146/-1/112f1fa0f38baf10800569462deb46cd.jpg",
            HotelId = Hotel_KempinskiHotelGrandArena.Id
        };
        HotelImageUrls.Add(HotelImageUrl_MultiHotels);

        HotelImageUrl_OldCentral = new HotelImageUrl()
        {
            Id = ++id,
            Url = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/260560238.jpg?k=1d14eb111d6a58d373d4139792c8c0545ec7014527bab0c00a98945e8df46879&o=&hp=1",
            HotelId = Hotel_StrandPalace.Id
        };
        HotelImageUrls.Add(HotelImageUrl_OldCentral);
    }
    private void SetReferencesHotelImageUrls()
    {
        HotelImageUrl_ThreeWhiteHouses.Hotel = Hotel_ChilworthLondonPaddington;

        HotelImageUrl_NightLights.Hotel = Hotel_ChilworthLondonPaddington;

        HotelImageUrl_MultiHotels.Hotel = Hotel_KempinskiHotelGrandArena;

        HotelImageUrl_OldCentral.Hotel = Hotel_StrandPalace;
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
            Title = "Luxury Suite",
            Description = "Luxurious room with a panoramic view.",
            BedsCount = 3,
            RoomSizeSquareMeters = 50,
            PricePerNight = 250.00m,
            HotelId = Hotel_StrandPalace.Id
        };
        Rooms.Add(Room_StrandPalace_LuxurySuite);
    }
    private void SetReferencesRooms()
    {
        Room_ChilworthLondonPaddington_CozyRetreat.Hotel = Hotel_ChilworthLondonPaddington;
        Room_ChilworthLondonPaddington_CozyRetreat.Bookings = Bookings
            .Where(b => b.RoomId == Room_ChilworthLondonPaddington_CozyRetreat.Id).ToList();
        //RoomFeatures
        Room_ChilworthLondonPaddington_CozyRetreat.RoomImages = RoomImageUrls
            .Where(i => i.RoomId == Room_ChilworthLondonPaddington_CozyRetreat.Id).ToList();

        Room_ChilworthLondonPaddington_ExecutiveSuite.Hotel = Hotel_ChilworthLondonPaddington;
        Room_ChilworthLondonPaddington_ExecutiveSuite.Bookings = Bookings
            .Where(b => b.RoomId == Room_ChilworthLondonPaddington_ExecutiveSuite.Id).ToList();
        //RoomFeatures
        Room_ChilworthLondonPaddington_ExecutiveSuite.RoomImages = RoomImageUrls
            .Where(i => i.RoomId == Room_ChilworthLondonPaddington_ExecutiveSuite.Id).ToList();

        Room_KempinskiHotelGrandArena_FamilyGetaway.Hotel = Hotel_KempinskiHotelGrandArena;
        Room_KempinskiHotelGrandArena_FamilyGetaway.Bookings = Bookings
            .Where(b => b.RoomId == Room_KempinskiHotelGrandArena_FamilyGetaway.Id).ToList();
        //RoomFeatures
        Room_KempinskiHotelGrandArena_FamilyGetaway.RoomImages = RoomImageUrls
            .Where(i => i.RoomId == Room_KempinskiHotelGrandArena_FamilyGetaway.Id).ToList();

        Room_KempinskiHotelGrandArena_OceanViewParadise.Hotel = Hotel_KempinskiHotelGrandArena;
        Room_KempinskiHotelGrandArena_OceanViewParadise.Bookings = Bookings
            .Where(b => b.RoomId == Room_KempinskiHotelGrandArena_OceanViewParadise.Id).ToList();
        //RoomFeatures
        Room_KempinskiHotelGrandArena_OceanViewParadise.RoomImages = RoomImageUrls
            .Where(i => i.RoomId == Room_KempinskiHotelGrandArena_OceanViewParadise.Id).ToList();

        Room_KempinskiHotelGrandArena_MountainLodge.Hotel = Hotel_KempinskiHotelGrandArena;
        Room_KempinskiHotelGrandArena_MountainLodge.Bookings = Bookings
            .Where(b => b.RoomId == Room_KempinskiHotelGrandArena_MountainLodge.Id).ToList();
        //RoomFeatures
        Room_KempinskiHotelGrandArena_MountainLodge.RoomImages = RoomImageUrls
            .Where(i => i.RoomId == Room_KempinskiHotelGrandArena_MountainLodge.Id).ToList();

        Room_StrandPalace_LuxurySuite.Hotel = Hotel_StrandPalace;
        Room_StrandPalace_LuxurySuite.Bookings = Bookings
            .Where(b => b.RoomId == Room_StrandPalace_LuxurySuite.Id).ToList();
        //RoomFeatures
        Room_StrandPalace_LuxurySuite.RoomImages = RoomImageUrls
            .Where(i => i.RoomId == Room_StrandPalace_LuxurySuite.Id).ToList();
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
            Name = "TV",
            SvgTag = string.Empty
        };
        Features.Add(Feature_TV);

        Feature_Refrigerator = new Feature
        {
            Id = ++id,
            Name = "Refrigerator",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Refrigerator);

        Feature_Hairdryer = new Feature
        {
            Id = ++id,
            Name = "Hairdryer",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Hairdryer);

        Feature_Towels = new Feature
        {
            Id = ++id,
            Name = "Towels",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Towels);

        Feature_Slippers = new Feature
        {
            Id = ++id,
            Name = "Slippers",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Slippers);

        Feature_Bathtub = new Feature
        {
            Id = ++id,
            Name = "Bathtub",
            SvgTag = string.Empty
        };
        Features.Add(Feature_Bathtub);
    }
    private void SetReferencesFeatures()
    {
        Feature_TV.RoomsFeatures = RoomFeatures
            .Where(rf => rf.FeatureId == Feature_TV.Id).ToList();

        Feature_Refrigerator.RoomsFeatures = RoomFeatures
            .Where(rf => rf.FeatureId == Feature_Refrigerator.Id).ToList();

        Feature_Hairdryer.RoomsFeatures = RoomFeatures
            .Where(rf => rf.FeatureId == Feature_Hairdryer.Id).ToList();

        Feature_Towels.RoomsFeatures = RoomFeatures
            .Where(rf => rf.FeatureId == Feature_Towels.Id).ToList();

        Feature_Slippers.RoomsFeatures = RoomFeatures
            .Where(rf => rf.FeatureId == Feature_Slippers.Id).ToList();

        Feature_Bathtub.RoomsFeatures = RoomFeatures
            .Where(rf => rf.FeatureId == Feature_Bathtub.Id).ToList();
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
    private void SetReferencesRoomFeatures()
    {
        RoomFeature_FamilyGetaway_Bathtub.Feature = Feature_Bathtub;
        RoomFeature_FamilyGetaway_Bathtub.Room = Room_KempinskiHotelGrandArena_FamilyGetaway;

        RoomFeature_FamilyGetaway_Slippers.Feature = Feature_Slippers;
        RoomFeature_FamilyGetaway_Slippers.Room = Room_KempinskiHotelGrandArena_FamilyGetaway;

        RoomFeature_MountainLodge_TV.Feature = Feature_TV;
        RoomFeature_MountainLodge_TV.Room = Room_KempinskiHotelGrandArena_MountainLodge;

        RoomFeature_MountainLodge_Refrigerator.Feature = Feature_Refrigerator;
        RoomFeature_MountainLodge_Refrigerator.Room = Room_KempinskiHotelGrandArena_MountainLodge;
    }

    public RoomImageUrl RoomImageUrl_FamilyGetaway_LuxuryClassicModern { get; set; } = null!;
    public RoomImageUrl RoomImageUrl_FamilyGetaway_BlueView { get; set; } = null!;
    public RoomImageUrl RoomImageUrl_MountainLodge_MountainResort { get; set; } = null!;
    public RoomImageUrl RoomImageUrl_MountainLodge_CabinInterior { get; set; } = null!;
    private void SeedRoomImageUrls()
    {
        int id = 0;

        RoomImageUrl_FamilyGetaway_LuxuryClassicModern = new RoomImageUrl
        {
            Id = ++id,
            Url = "https://img.freepik.com/free-photo/luxury-classic-modern-bedroom-suite-hotel_105762-1787.jpg?size=626&ext=jpg&ga=GA1.1.2008272138.1712707200&semt=ais",
            RoomId = Room_KempinskiHotelGrandArena_FamilyGetaway.Id
        };
        RoomImageUrls.Add(RoomImageUrl_FamilyGetaway_LuxuryClassicModern);

        RoomImageUrl_FamilyGetaway_BlueView = new RoomImageUrl
        {
            Id = ++id,
            Url = "https://images.trvl-media.com/lodging/96000000/95770000/95768000/95767989/5674f5e3.jpg?impolicy=resizecrop&rw=1200&ra=fit",
            RoomId = Room_KempinskiHotelGrandArena_FamilyGetaway.Id
        };
        RoomImageUrls.Add(RoomImageUrl_FamilyGetaway_BlueView);

        RoomImageUrl_MountainLodge_MountainResort = new RoomImageUrl
        {
            Id = ++id,
            Url = "https://st.depositphotos.com/1007581/1700/i/600/depositphotos_17000573-stock-photo-mountain-resort-house.jpg",
            RoomId = Room_KempinskiHotelGrandArena_MountainLodge.Id
        };
        RoomImageUrls.Add(RoomImageUrl_MountainLodge_MountainResort);

        RoomImageUrl_MountainLodge_CabinInterior = new RoomImageUrl
        {
            Id = ++id,
            Url = "https://whiteface.com/wp-content/uploads/sites/3/2023/08/Cobble-Mountain-Lodge-Cabin-Interior-768x511-1.jpg",
            RoomId = Room_KempinskiHotelGrandArena_MountainLodge.Id
        };
        RoomImageUrls.Add(RoomImageUrl_MountainLodge_CabinInterior);
    }
    private void SetReferencesRoomImageUrls()
    {
        RoomImageUrl_FamilyGetaway_LuxuryClassicModern.Room = Room_KempinskiHotelGrandArena_FamilyGetaway;

        RoomImageUrl_FamilyGetaway_BlueView.Room = Room_KempinskiHotelGrandArena_FamilyGetaway;

        RoomImageUrl_MountainLodge_MountainResort.Room = Room_KempinskiHotelGrandArena_MountainLodge;

        RoomImageUrl_MountainLodge_CabinInterior.Room = Room_KempinskiHotelGrandArena_MountainLodge;
    }

    public Booking Booking_ChilworthLondonPaddington_CozyRetreat { get; set; } = null!;
    public Booking Booking_ChilworthLondonPaddington_ExecutiveSuite { get; set; } = null!;
    public Booking Booking_KempinskiHotelGrandArena_FamilyGetaway { get; set; } = null!;
    public Booking Booking_KempinskiHotelGrandArena_OceanViewParadise { get; set; } = null!;
    public Booking Booking_KempinskiHotelGrandArena_MountainLodge { get; set; } = null!;
    public Booking Booking_StrandPalace_LuxurySuite { get; set; } = null!;
    private void SeedBookings()
    {
        Booking_ChilworthLondonPaddington_CozyRetreat = new Booking
        {
            Id = 1,
            CheckIn = new DateTime(2023, 5, 1),
            CheckOut = new DateTime(2023, 5, 5),
            AdultsCount = 2,
            UserId = User_Normal.Id,
            RoomId = Room_ChilworthLondonPaddington_CozyRetreat.Id,
            HotelId = Hotel_ChilworthLondonPaddington.Id
        };
        Bookings.Add(Booking_ChilworthLondonPaddington_CozyRetreat);

        Booking_ChilworthLondonPaddington_ExecutiveSuite = new Booking
        {
            Id = 2,
            CheckIn = new DateTime(2023, 6, 10),
            CheckOut = new DateTime(2023, 6, 15),
            AdultsCount = 3,
            UserId = User_Normal.Id,
            RoomId = Room_ChilworthLondonPaddington_ExecutiveSuite.Id,
            HotelId = Hotel_ChilworthLondonPaddington.Id
        };
        Bookings.Add(Booking_ChilworthLondonPaddington_ExecutiveSuite);

        Booking_KempinskiHotelGrandArena_FamilyGetaway = new Booking
        {
            Id = 3,
            CheckIn = new DateTime(2023, 7, 20),
            CheckOut = new DateTime(2023, 7, 25),
            AdultsCount = 1,
            UserId = User_Second.Id,
            RoomId = Room_KempinskiHotelGrandArena_FamilyGetaway.Id,
            HotelId = Hotel_KempinskiHotelGrandArena.Id
        };
        Bookings.Add(Booking_KempinskiHotelGrandArena_FamilyGetaway);

        Booking_KempinskiHotelGrandArena_OceanViewParadise = new Booking
        {
            Id = 4,
            CheckIn = new DateTime(2023, 8, 5),
            CheckOut = new DateTime(2023, 8, 10),
            AdultsCount = 4,
            UserId = User_Second.Id,
            RoomId = Room_KempinskiHotelGrandArena_OceanViewParadise.Id,
            HotelId = Hotel_KempinskiHotelGrandArena.Id
        };
        Bookings.Add(Booking_KempinskiHotelGrandArena_OceanViewParadise);

        Booking_KempinskiHotelGrandArena_MountainLodge = new Booking
        {
            Id = 5,
            CheckIn = new DateTime(2023, 9, 15),
            CheckOut = new DateTime(2023, 9, 20),
            AdultsCount = 2,
            UserId = User_Second.Id,
            RoomId = Room_KempinskiHotelGrandArena_MountainLodge.Id,
            HotelId = Hotel_KempinskiHotelGrandArena.Id
        };
        Bookings.Add(Booking_KempinskiHotelGrandArena_MountainLodge);

        Booking_StrandPalace_LuxurySuite = new Booking
        {
            Id = 6,
            CheckIn = new DateTime(2023, 10, 17),
            CheckOut = new DateTime(2023, 10, 21),
            AdultsCount = 3,
            UserId = User_TobeManager.Id,
            RoomId = Room_StrandPalace_LuxurySuite.Id,
            HotelId = Hotel_StrandPalace.Id
        };
        Bookings.Add(Booking_StrandPalace_LuxurySuite);
    }
    private void SetReferencesBookings()
    {
        Booking_ChilworthLondonPaddington_CozyRetreat.User = User_Normal;
        Booking_ChilworthLondonPaddington_CozyRetreat.Room = Room_ChilworthLondonPaddington_CozyRetreat;
        Booking_ChilworthLondonPaddington_CozyRetreat.Hotel = Hotel_ChilworthLondonPaddington;

        Booking_ChilworthLondonPaddington_ExecutiveSuite.User = User_Normal;
        Booking_ChilworthLondonPaddington_ExecutiveSuite.Room = Room_ChilworthLondonPaddington_ExecutiveSuite;
        Booking_ChilworthLondonPaddington_ExecutiveSuite.Hotel = Hotel_ChilworthLondonPaddington;

        Booking_KempinskiHotelGrandArena_FamilyGetaway.User = User_Second;
        Booking_KempinskiHotelGrandArena_FamilyGetaway.Room = Room_KempinskiHotelGrandArena_FamilyGetaway;
        Booking_KempinskiHotelGrandArena_FamilyGetaway.Hotel = Hotel_KempinskiHotelGrandArena;

        Booking_KempinskiHotelGrandArena_OceanViewParadise.User = User_Second;
        Booking_KempinskiHotelGrandArena_OceanViewParadise.Room = Room_KempinskiHotelGrandArena_OceanViewParadise;
        Booking_KempinskiHotelGrandArena_OceanViewParadise.Hotel = Hotel_KempinskiHotelGrandArena;

        Booking_KempinskiHotelGrandArena_MountainLodge.User = User_Second;
        Booking_KempinskiHotelGrandArena_MountainLodge.Room = Room_KempinskiHotelGrandArena_MountainLodge;
        Booking_KempinskiHotelGrandArena_MountainLodge.Hotel = Hotel_KempinskiHotelGrandArena;

        Booking_StrandPalace_LuxurySuite.User = User_TobeManager;
        Booking_StrandPalace_LuxurySuite.Room = Room_StrandPalace_LuxurySuite;
        Booking_StrandPalace_LuxurySuite.Hotel = Hotel_StrandPalace;
    }

    public Review Review_ExcellentProduct { get; set; } = null!;
    public Review Review_AverageExperience { get; set; } = null!;
    public Review Review_PoorQuality { get; set; } = null!;
    public Review Review_GoodValue { get; set; } = null!;
    public Review Review_BestProductEver { get; set; } = null!;
    public Review Review_Satisfactory { get; set; } = null!;
    private void SeedReviews()
    {
        Review_ExcellentProduct = new Review
        {
            Id = 1,
            RatingScore = 5,
            Title = "Excellent Product",
            Comment = "I love this product! It's exactly what I needed.",
            ReviewedOn = new DateTime(2023, 4, 1),
            HotelId = Hotel_ChilworthLondonPaddington.Id,
            BookingId = Booking_ChilworthLondonPaddington_CozyRetreat.Id,
            UserId = User_Normal.Id
        };
        Reviews.Add(Review_ExcellentProduct);

        Review_AverageExperience = new Review
        {
            Id = 2,
            RatingScore = 3,
            Title = "Average Experience",
            Comment = "The product was okay, but could be better.",
            ReviewedOn = new DateTime(2023, 3, 28),
            HotelId = Hotel_ChilworthLondonPaddington.Id,
            BookingId = Booking_ChilworthLondonPaddington_ExecutiveSuite.Id,
            UserId = User_Normal.Id
        };
        Reviews.Add(Review_AverageExperience);

        Review_PoorQuality = new Review
        {
            Id = 3,
            RatingScore = 1,
            Title = "Poor Quality",
            Comment = "I was very disappointed with this product.",
            ReviewedOn = new DateTime(2023, 3, 27),
            HotelId = Hotel_KempinskiHotelGrandArena.Id,
            BookingId = Booking_KempinskiHotelGrandArena_FamilyGetaway.Id,
            UserId = User_Second.Id
        };
        Reviews.Add(Review_PoorQuality);

        Review_GoodValue = new Review
        {
            Id = 4,
            RatingScore = 4,
            Title = "Good Value",
            Comment = "I got my money's worth with this product.",
            ReviewedOn = new DateTime(2023, 3, 26),
            HotelId = Hotel_KempinskiHotelGrandArena.Id,
            BookingId = Booking_KempinskiHotelGrandArena_OceanViewParadise.Id,
            UserId = User_Second.Id
        };
        Reviews.Add(Review_GoodValue);

        Review_BestProductEver = new Review
        {
            Id = 5,
            RatingScore = 5,
            Title = "Best Product Ever",
            Comment = "This product is amazing! Highly recommended.",
            ReviewedOn = new DateTime(2023, 3, 25),
            HotelId = Hotel_KempinskiHotelGrandArena.Id,
            BookingId = Booking_KempinskiHotelGrandArena_MountainLodge.Id,
            UserId = User_Second.Id
        };
        Reviews.Add(Review_BestProductEver);

        Review_Satisfactory = new Review
        {
            Id = 6,
            RatingScore = 4.5m,
            Title = "Satisfactory",
            Comment = "Great room and service overall!",
            ReviewedOn = new DateTime(2023, 10, 30),
            HotelId = Hotel_StrandPalace.Id,
            BookingId = Booking_StrandPalace_LuxurySuite.Id,
            UserId = User_TobeManager.Id
        };
        Reviews.Add(Review_Satisfactory);
    }
    private void SetReferencesReviews()
    {
        Review_ExcellentProduct.Hotel = Hotel_ChilworthLondonPaddington;
        Review_ExcellentProduct.Booking = Booking_ChilworthLondonPaddington_CozyRetreat;
        Review_ExcellentProduct.User = User_Normal;

        Review_AverageExperience.Hotel = Hotel_ChilworthLondonPaddington;
        Review_AverageExperience.Booking = Booking_ChilworthLondonPaddington_ExecutiveSuite;
        Review_AverageExperience.User = User_Normal;

        Review_PoorQuality.Hotel = Hotel_KempinskiHotelGrandArena;
        Review_PoorQuality.Booking = Booking_KempinskiHotelGrandArena_FamilyGetaway;
        Review_PoorQuality.User = User_Second;

        Review_GoodValue.Hotel = Hotel_KempinskiHotelGrandArena;
        Review_GoodValue.Booking = Booking_KempinskiHotelGrandArena_OceanViewParadise;
        Review_GoodValue.User = User_Second;

        Review_BestProductEver.Hotel = Hotel_KempinskiHotelGrandArena;
        Review_BestProductEver.Booking = Booking_KempinskiHotelGrandArena_MountainLodge;
        Review_BestProductEver.User = User_Second;

        Review_Satisfactory.Hotel = Hotel_StrandPalace;
        Review_Satisfactory.Booking = Booking_StrandPalace_LuxurySuite;
        Review_Satisfactory.User = User_TobeManager;
    }
}
