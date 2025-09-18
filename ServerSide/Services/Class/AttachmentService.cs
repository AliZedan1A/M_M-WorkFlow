namespace ServerSide.Services.Class
{
    public class AttachmentService
    {
        private static string BasePath = "\\workflowimages";

        public async Task<string> ConvertFileToPath(IFormFile file)
        {
            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);
            string randomString = Guid.NewGuid().ToString();
            string fullpath = Path.Combine(BasePath, randomString + file.FileName);
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(stream);
                    return fullpath;

                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }
    }
}
