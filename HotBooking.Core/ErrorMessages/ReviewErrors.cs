namespace HotBooking.Core.ErrorMessages;

public static class ReviewErrors
{
    public const string NotFound = "The Review is not found!";
    public const string AlreadyHasReview = "You already have a review!";
    public const string DoesNotHaveBooking = "You don't have a booking to review!";
    public const string NotTheAuthorOfReview = "You are not the author of this review!";
}
