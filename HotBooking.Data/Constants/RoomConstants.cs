namespace HotBooking.Data.Constants;
public static class RoomConstants
{
    public const int TitleLengthMin = 5;
    public const int TitleLengthMax = 50;

    public const int DescriptionLengthMin = 10;
    public const int DescriptionLengthMax = 1000;

    public const int BedsCountMin = 1;
    public const int BedsCountMax = 100;

    public const int RoomSizeSquareMetersMin = 5;
    public const int RoomSizeSquareMetersMax = 500;

    public const int PricePerNightMin = 1;
    public const int PricePerNightMax = 100000;
}
