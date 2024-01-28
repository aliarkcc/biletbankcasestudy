namespace BiletBankCaseStudy.Core.Utilities.Messages
{
    public enum ResultCodes
    {
        HTTP_OK = 200,
        HTTP_InternalServerError = 500,
        HTTP_BadRequest = 400,
        HTTP_Unauthorized = 401,
        HTTP_Forbidden = 403,
        HTTP_NotFound = 404,
        HTTP_Conflict = 409,
    }
}