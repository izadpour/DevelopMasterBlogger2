namespace MB.Domain.ArticleCategoryAgg.Service
{
    public interface IArticleCategoryValidatorService
    {
        void CheckThatThisRecordAlreadyExists(string title);

    }
}