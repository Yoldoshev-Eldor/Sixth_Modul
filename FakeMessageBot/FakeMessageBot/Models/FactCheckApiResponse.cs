namespace FakeMessageBot.Models;

public class FactCheckApiResponse
{
    public Claim[] Claims { get; set; }
}

public class Claim
{
    public string Text { get; set; }
    public ClaimReview[] ClaimReview { get; set; }
}

public class ClaimReview
{
    public string PublisherName { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public string ReviewDate { get; set; }
}
