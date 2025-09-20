namespace ServerSide.Services.Class
{
    public class AttachmentService
    {
        private static string BasePath = "\\workflowimages";

        public async Task<string> ConvertFileToPath(byte[] imageBytes, string extension, int userId)
        {
            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);

            string randomString = Guid.NewGuid().ToString();
            string filename = $"{userId}_{randomString}.{extension}";
            string fullpath = Path.Combine(BasePath, filename);

            await File.WriteAllBytesAsync(fullpath, imageBytes);

            return fullpath; 
        }
    }
}
