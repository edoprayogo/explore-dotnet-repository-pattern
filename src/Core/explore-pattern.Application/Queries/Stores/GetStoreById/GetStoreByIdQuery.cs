namespace explore_pattern.Application.Queries.Stores.GetStoreById
{
    public class GetStoreByIdQuery
    {
        public Guid Id { get; set; }
        public GetStoreByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }

}
