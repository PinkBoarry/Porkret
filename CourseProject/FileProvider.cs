using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CourseProject
{
    public static class FileProvider
    {
        public static async Task<UploadResponse?> PostFileAsync(string fileServerUrl, string filePath)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            byte[] bytes = File.ReadAllBytes(filePath);
            ByteArrayContent fileContent = new ByteArrayContent(bytes);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            form.Add(fileContent, "uploadedFile", Path.GetFileName(filePath));

            using var httpClient = new HttpClient();

            HttpResponseMessage response = httpClient.PostAsync($"{fileServerUrl}/upload", form).Result;
            //response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("response :" + responseContent);

            return JsonSerializer.Deserialize<UploadResponse>(responseContent);
        }

        public record UploadResponse
        {
            public string? contentType { get; set; }
            public string? serializerSettings { get; set; }
            public string? statusCode { get; set; }
            public string? value { get; set; }
        }
    }
}

