using System.Net.Http;
using System.Text.Json;
using FakeMessageBot.Models;

namespace FakeMessageBot.Services
{
    public class GoogleFactCheckService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public GoogleFactCheckService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
        }

        public async Task<List<ClaimReviewResult>> CheckMessageAsync(string messageText)
        {
            if (string.IsNullOrWhiteSpace(messageText))
                return new List<ClaimReviewResult>();

            string apiUrl = $"https://factchecktools.googleapis.com/v1alpha1/claims:search?query={Uri.EscapeDataString(messageText)}&key={_apiKey}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return new List<ClaimReviewResult>();

            var jsonString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var apiResponse = JsonSerializer.Deserialize<FactCheckApiResponse>(jsonString, options);

            var results = new List<ClaimReviewResult>();

            if (apiResponse?.Claims != null)
            {
                foreach (var claim in apiResponse.Claims)
                {
                    if (claim.ClaimReview != null)
                    {
                        foreach (var review in claim.ClaimReview)
                        {
                            results.Add(new ClaimReviewResult
                            {
                                Title = review.Title,
                                Url = review.Url
                            });
                        }
                    }
                }
            }

            return results;
        }
    }

    // Qulaylik uchun ClaimReviewResult kichik model
    public class ClaimReviewResult
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
