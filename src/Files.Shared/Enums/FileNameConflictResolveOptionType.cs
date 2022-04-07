namespace Files.Shared.Enums
{
    public enum FileNameConflictResolveOptionType : int
    {
        GenerateNewName = 0,
        ReplaceExisting = 1,
        Skip = 2,
        NotAConflict = 4
    }
}