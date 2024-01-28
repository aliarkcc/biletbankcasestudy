namespace BiletBankCaseStudy.Core.Application.Requests;

public class PageRequest
{
    public int Page { get; set; }
    public int PageSize { get; set; }

    public PageRequest()
    {
        Page = 0;
        PageSize = 10;
    }
}