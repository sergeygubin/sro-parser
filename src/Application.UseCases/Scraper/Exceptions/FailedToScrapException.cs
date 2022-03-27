using Application.Common;

namespace SroParser.Application.UseCases.Scraper.Exceptions;

public class FailedToScrapException : ScraperException
{
    public FailedToScrapException(string details) : base($"{ExceptionMessage.Scraper.FailedToScrap}. Details: {details}")
    {
    }
}