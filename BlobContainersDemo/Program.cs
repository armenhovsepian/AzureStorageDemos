// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

// Create an Azure storage blob container named 'images' and upload a few images to it

Console.WriteLine("Azure Blob Containers Demo!");


string connectionString = "UseDevelopmentStorage=true";
string containerName = "images";

BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
blobContainerClient.CreateIfNotExists();

Pageable<BlobItem> blobs = blobContainerClient.GetBlobs();
foreach (BlobItem item in blobs)
{
    Console.WriteLine(item.Name);
}