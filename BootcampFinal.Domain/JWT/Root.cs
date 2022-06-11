namespace BootcampFinal.Domain.JWT
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Root
    {
        public Body body { get; set; }
        public Header header { get; set; }
    }
}