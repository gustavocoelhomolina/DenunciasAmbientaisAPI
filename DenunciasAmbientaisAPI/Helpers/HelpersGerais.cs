namespace DenunciasAmbientaisAPI.Helpers
{
    public class HelpersGerais
    {
        public string ConvertToBase64(IFormFile file)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] byteImage = ms.ToArray();
                return Convert.ToBase64String(byteImage);
            }
        }
    }
}
