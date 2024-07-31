

# Azure Blob Storage API

This ASP.NET Core Web API provides endpoints to interact with Azure Blob Storage. It supports operations for uploading, downloading, modifying, deleting blobs, and checking blob existence.

## Features

- **Upload Blob**: Upload a JSON file to Azure Blob Storage.
- **Download Blob**: Download a JSON file from Azure Blob Storage.
- **Modify Blob**: Modify an existing blob in Azure Blob Storage.
- **Delete Blob**: Delete a blob from Azure Blob Storage.
- **Check Blob Existence**: Check if a specific blob exists in Azure Blob Storage.

## Prerequisites

- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Azure Subscription
- Azure Blob Storage account and container

## Setup

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/your-repository-name.git
   cd your-repository-name
   ```

2. **Install Dependencies**

   Make sure you have [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed. Run the following command to restore the dependencies:

   ```bash
   dotnet restore
   ```

3. **Configure Azure Blob Storage**

   Update the `appsettings.json` file with your Azure Blob Storage connection string and container name:

   ```json
   {
     "AzureBlobStorage": {
       "ConnectionString": "YourAzureBlobStorageConnectionString",
       "ContainerName": "YourContainerName"
     }
   }
   ```

   **Or**, configure these settings as environment variables:
   
   ```bash
   export AZURE_BLOB_CONNECTION_STRING="YourAzureBlobStorageConnectionString"
   export AZURE_BLOB_CONTAINER_NAME="YourContainerName"
   ```

## Running the Application

1. **Build and Run**

   ```bash
   dotnet build
   dotnet run
   ```

   The API will be available at `https://localhost:5001` by default.

2. **Access the Swagger UI**

   Open your browser and navigate to `https://localhost:5001/swagger` to interact with the API endpoints via Swagger UI.

## API Endpoints

### Upload Blob

- **Endpoint**: `POST /api/blob/upload`
- **Headers**:
  - `connectionString`: Your Azure Blob Storage connection string
  - `containerName`: Your container name
- **Query Parameters**:
  - `blobName`: The name of the blob to upload
- **Body**: JSON content to upload

### Download Blob

- **Endpoint**: `GET /api/blob/download`
- **Headers**:
  - `connectionString`: Your Azure Blob Storage connection string
  - `containerName`: Your container name
- **Query Parameters**:
  - `blobName`: The name of the blob to download

### Modify Blob

- **Endpoint**: `PUT /api/blob/modify`
- **Headers**:
  - `connectionString`: Your Azure Blob Storage connection string
  - `containerName`: Your container name
- **Query Parameters**:
  - `blobName`: The name of the blob to modify
- **Body**: JSON content to update

### Delete Blob

- **Endpoint**: `DELETE /api/blob/delete`
- **Headers**:
  - `connectionString`: Your Azure Blob Storage connection string
  - `containerName`: Your container name
- **Query Parameters**:
  - `blobName`: The name of the blob to delete

### Check Blob Existence

- **Endpoint**: `GET /api/blob/exists`
- **Headers**:
  - `connectionString`: Your Azure Blob Storage connection string
  - `containerName`: Your container name
- **Query Parameters**:
  - `blobName`: The name of the blob to check

## Deployment

To deploy this API to Azure App Service:

1. **Publish the Application**:
   In Visual Studio, right-click the project and select `Publish`. Choose `Azure` and `Azure App Service (Windows)`.

2. **Configure Azure App Service**:
   Follow the instructions provided by Azure Portal to create and configure an App Service.

## Contributing

If you wish to contribute to this project, please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any questions or support, please contact [Ritik](mailto:ritikkumar262@gmail.com).
