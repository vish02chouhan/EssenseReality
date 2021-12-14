namespace EssenceRealty.Web.API.Model
{
    public class EssencePaginationResponse<T> : EssenceResponse<T>
    {
        public int TotalCount { get; set; }

    }
}
