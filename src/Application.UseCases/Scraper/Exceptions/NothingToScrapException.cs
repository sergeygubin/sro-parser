using Application.Common;

namespace SroParser.Application.UseCases.Scraper.Exceptions;

public class NothingToScrapException : ScraperException
{
    public NothingToScrapException() : base(ExceptionMessage.Scraper.NothingToScrap)
    {
    }
}