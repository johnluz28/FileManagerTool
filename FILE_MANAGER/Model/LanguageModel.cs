namespace FILE_MANAGER
{
    public class LanguageModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Key => $"-{Id}.";

    }
}
