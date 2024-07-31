using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace AzureBlobServices.Services
{
    public class BlobStorageService
    {
        public async Task UploadBlobAsync(string connectionString, string containerName, string blobName, string jsonContent)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonContent)))
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }
        }

        public async Task<string> DownloadBlobAsync(string connectionString, string containerName, string blobName)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            if (await blobClient.ExistsAsync())
            {
                var response = await blobClient.DownloadAsync();
                using (var streamReader = new StreamReader(response.Value.Content))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
            throw new Exception("Blob not found");
        }

        public async Task ModifyBlobAsync(string connectionString, string containerName, string blobName, string jsonContent)
        {
            await UploadBlobAsync(connectionString, containerName, blobName, jsonContent);
        }

        public async Task<bool> BlobExistsAsync(string connectionString, string containerName, string blobName)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            return await blobClient.ExistsAsync();
        }

        public async Task DeleteBlobAsync(string connectionString, string containerName, string blobName)
        {
            // Create a BlobServiceClient to connect to the Azure Blob Storage account
            var blobServiceClient = new BlobServiceClient(connectionString);

            // Get the container client
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Get the blob client
            var blobClient = containerClient.GetBlobClient(blobName);

            // Delete the blob
            await blobClient.DeleteIfExistsAsync();
        }
    }
}
