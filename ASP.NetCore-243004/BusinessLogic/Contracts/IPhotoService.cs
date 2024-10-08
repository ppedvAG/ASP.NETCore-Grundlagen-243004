namespace BusinessLogic.Contracts
{
    public interface IPhotoService
    {
        Task<string> UploadFile(string fileName, Stream stream);
    }
}