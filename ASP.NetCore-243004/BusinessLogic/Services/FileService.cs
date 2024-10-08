using BusinessLogic.Contracts;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace BusinessLogic.Services
{
    public class FileServiceOptions
    {
        public string BaseUrl { get; set; }
    }

    public class FileService : IPhotoService
    {
        private readonly HttpClient _httpClient;

        public FileService(IOptions<FileServiceOptions> options, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<string> UploadFile(string fileName, Stream stream)
        {
            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Octet);

            var formContent = new MultipartFormDataContent
            {
                { content, "file", fileName }
            };

            var response = await _httpClient.PostAsync("/files/upload", formContent);
            if (response.IsSuccessStatusCode)
            {
                var resourceUrl = await response.Content.ReadAsStringAsync();
                return resourceUrl;
            } 
            else
            {
                throw new InvalidOperationException(response.ReasonPhrase);
            }

        }
    }
}
