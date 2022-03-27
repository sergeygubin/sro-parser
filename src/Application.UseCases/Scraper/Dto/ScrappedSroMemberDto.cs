namespace SroParser.Application.UseCases.Scraper.Dto;

public class ScrapedSroMemberDto
{
    public string FullName { get; }
    public string ShortName { get; }
    public long IdentificationNumber { get; }
    
    public ScrapedSroMemberDto(string fullName, string shortName, long identificationNumber)
    {
        FullName = fullName;
        ShortName = shortName;
        IdentificationNumber = identificationNumber;
    }
}