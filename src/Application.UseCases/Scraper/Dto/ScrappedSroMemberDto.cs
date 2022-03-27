namespace SroParser.Application.UseCases.Scraper.Dto;

public class ScrappedSroMemberDto
{
    public string FullName { get; }
    public string ShortName { get; }
    public string IdentificationNumber { get; }
    
    public ScrappedSroMemberDto(string fullName, string shortName, string identificationNumber)
    {
        FullName = fullName;
        ShortName = shortName;
        IdentificationNumber = identificationNumber;
    }
}